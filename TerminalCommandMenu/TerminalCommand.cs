using System;
using System.Collections.Generic;
using System.Text;
using TerminalCommandMenu.Abstractions;

namespace TerminalCommandMenu
{
    public class TerminalCommand : ITerminalCommand
    {
        private readonly Action<string[]> _executeAction;
        private readonly Func<bool> _canExecute;

        public string Title { get; private set 
            {
                ArgumentException.ThrowIfNullOrEmpty(value, "Command name can't be null or Empty");

                if (value.Contains(' ')) throw new ArgumentException("Comman name can't contain white space");

                field = value;
            } 
        }
        public event EventHandler CanExecuteChanged { add { } remove { } }

        public TerminalCommand(string title, Action<string[]> executeAction, Func<bool>? canExecute = null)
        {


            _executeAction = executeAction;
            _canExecute = canExecute ?? (() => true);
        }

        public void Execute(string[] arguments) => _executeAction(arguments);

        public bool CanExecute() => _canExecute();
    }
}
