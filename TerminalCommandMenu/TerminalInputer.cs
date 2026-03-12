using System;
using System.Collections.Generic;
using System.Text;
using TerminalCommandMenu.Abstractions;

namespace TerminalCommandMenu
{
    public class TerminalInputer : ITerminalInputer
    {
        private bool _isTerminalActive = false;
        private Dictionary<string, List<ITerminalCommand>> _commands = [];
        private ITerminal _terminal;
        private ICommandParser _commandParser;
        private IErrorSender _errorSender;

        private string Title { get; set {
                ArgumentException.ThrowIfNullOrEmpty(value, nameof(Title));
                
                field = value;
            } 
        }

        public TerminalInputer(string title, 
            ITerminal terminal, ICommandParser commandParser, IErrorSender errorSender)
        {
            Title = title;
            _terminal = terminal;
            _commandParser = commandParser;
            _errorSender = errorSender;
        }

        public void RegisterCommand(ITerminalCommand command)
        {
            if (_commands.ContainsKey(command.Title))
            {
                // Need check to dublicate command

                _commands[command.Title].Add(command);
            }
            else
            {
                _commands[command.Title] = new List<ITerminalCommand> { command };
            }
        }

        public void Show()
        {
            _isTerminalActive = true;

            while (_isTerminalActive)
            {
                _terminal.Write($"{Title}>");
                string? input = _terminal.Read();

                if (input == null || input == string.Empty)
                {
                    _errorSender.NotifyOnError("Input cannot be empty.");
                    continue;
                }

                (string command, string arguments) = _commandParser.Parse(input);

                if (!_commands.ContainsKey(command))
                {
                    _errorSender.NotifyOnError("Command name is incorrect.");
                    continue;
                }

                // Add check redefinition command

                var comm = _commands[command][0];

                string[] parseCommands;

                if (!comm.TryParseArguments(arguments, out parseCommands))
                {
                    _errorSender.NotifyOnError("Arguments is incorrect.");
                    continue;
                }

                comm.Execute(parseCommands);
            }
        }

        public void Close()
        {
            _isTerminalActive = false;
        }
    }
}
