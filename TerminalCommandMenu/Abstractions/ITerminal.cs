using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCommandMenu.Abstractions
{
    public interface IWriteble
    {
        void Write(string text);
    }

    public interface IReadeble
    {
        string? Read();
    }

    public interface ITerminal : IWriteble, IReadeble { }
}
