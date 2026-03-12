using System;
using TerminalCommandMenu;
using TerminalCommandMenu.Abstractions;

namespace Test
{
    public class Application
    {
        static void Main(string[] args)
        {
            ITerminal termianl = new Terminal();
            ICommandParser commandParser = new CommandParser();
            IErrorSender errorSender = new ErrorSender(termianl);

            var Menu = new TerminalInputer(
                termianl, commandParser, errorSender,
                new List<ITerminalCommand>
                {
                    new TerminalCommand("Command1", ((string[] args) => termianl.Write("com1\n"))),
                    new TerminalCommand("Command2", ((string[] args) => termianl.Write("com2\n")))
                }, "$root");

            Menu.Show();
        }
    }
}