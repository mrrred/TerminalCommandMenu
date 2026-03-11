using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCommandMenu.Abstractions
{
    public interface ITerminalCommand
    {
        void Execute(string[] arguments);

        bool CanExecute();
    }
}
