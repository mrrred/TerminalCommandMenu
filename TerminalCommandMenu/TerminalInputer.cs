using System;
using System.Collections.Generic;
using System.Text;
using TerminalCommandMenu.Abstractions;

namespace TerminalCommandMenu
{
    public class TerminalInputer : ITerminalInputer
    {
        protected readonly ITerminal _terminal;
        protected readonly ICommandParser _commandParser;
        protected readonly IErrorSender _errorSender;
        protected readonly Dictionary<string, ITerminalCommand> _commands = [];

        private bool IsTerminalActive = false;
        private string _inputTitle;

        public TerminalInputer(ITerminal terminal,
            ICommandParser commandParser,
            IErrorSender errorSender,
            List<ITerminalCommand> commands, 
            string inputTitle = null)
        {
            _terminal = terminal;
            _commandParser = commandParser;
            _errorSender = errorSender;
            
            foreach (ITerminalCommand command in commands) _commands.Add(command.Title, command);

            _inputTitle = inputTitle ?? "";
        }

        public void Show()
        {
            IsTerminalActive = true;

            while (IsTerminalActive)
            {
                _terminal.Write($"{_inputTitle}>");

                (string command, string[] arguments)
                    = _commandParser.Parse(_terminal.Read() ?? "");

                CallCommand(command, arguments);
            }
        }

        public void Close()
        {
            IsTerminalActive = false;
        }

        private void CallCommand(string command, string[] arguments)
        {
            if (IsCommandExist(command))
            {
                _commands[command].Execute(arguments);
            }
            else
            {
                _errorSender.NotifyOnError("Command doesn't exist\n");
            }
        }

        private bool IsCommandExist(string command)
        {
            return _commands.ContainsKey(command);
        }
    }
}
