using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCommandMenu.Abstractionsb
{
    public interface IErrorSender
    {
        void NotifyOnError(string message);
    }
}
