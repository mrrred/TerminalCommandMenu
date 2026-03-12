using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCommandMenu.Abstractionsb
{
    public interface ICommandParser
    {
        (string Command, string[] arguments) Parse(string input);
    }
}
