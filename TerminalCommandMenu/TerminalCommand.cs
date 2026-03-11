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

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public TerminalCommand(Action<string[]> executeAction, Func<bool>? canExecute = null)
        {
            _executeAction = executeAction;
            _canExecute = canExecute ?? (() => true);
        }

        public void Execute(string[] arguments) => _executeAction(arguments);

        public bool CanExecute() => _canExecute();
    }
}
