using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCommandMenu.Abstractions
{
    public interface IErrorSender
    {
        void NotifyOnError(string message);
    }
}
