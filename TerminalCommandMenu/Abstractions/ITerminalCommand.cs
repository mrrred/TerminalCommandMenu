using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCommandMenu.Abstractions
{
    public interface ITerminalCommand
    {
        event EventHandler CanExecuteChanged { add { } remove { } }

        void Execute(string[] arguments);

        bool CanExecute();
    }
}
