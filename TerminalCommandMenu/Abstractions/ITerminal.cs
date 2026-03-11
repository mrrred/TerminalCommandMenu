using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCommandMenu.Abstractions
{
    public interface ITerminal
    {
        void Write(string text);
        
        string Read();
    }
}
