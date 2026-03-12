using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCommandMenu.Abstractionsb
{
    public interface ITerminalCommand
    {
        string Title { get; }

        event EventHandler CanExecuteChanged { add { } remove { } }

        void Execute(string[] arguments);

        bool CanExecute();
    }
}
