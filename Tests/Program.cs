using System;
using TerminalCommandMenu;
using TerminalCommandMenu.Abstractions;

namespace Prog
{
    class Program
    {
        static void Main()
        {
            ITerminal terminal = new Terminal();
            ICommandParser commandParse = new CommandParser();
            IArgumentParser argumentParser = new ArgumentSeparatorParser(" ");
            IErrorSender errorSender = new ErrorSender(terminal);

            TerminalInputer terminalInputer = new("$root", terminal, commandParse, errorSender);

            ICommand<string[]> comm1 = new Command((string[] x) => { terminal.Write("FristCommand\n"); });
            ICommand<string[]> comm2 = new Command((string[] x) => { terminal.Write("SecondCommand\n"); });
            ICommand<string[]> comm3 = new Command((string[] x) => { 
                foreach (var a in x)
                {
                    terminal.Write(a + "\n");
                }
            });
            ICommand<string[]> exitComm = new Command((string[] x) => { terminalInputer.Close(); });

            ITerminalCommand command1 = new TerminalCommand("Command1", argumentParser, comm1);
            ITerminalCommand command2 = new TerminalCommand("Command2", argumentParser, comm2);
            ITerminalCommand command3 = new TerminalCommand("Command3", argumentParser, comm3);
            ITerminalCommand exitCommand = new TerminalCommand("Exit", argumentParser, exitComm);

            IArgumentParser formatParser = new ArgumentFormatParser("%a(%a)");
            ICommand<string[]> comm4 = new Command((string[] x) => { terminal.Write($"{x[0]}|{x[1]}" + "\n"); });
            ITerminalCommand commandWithFormatParser = new TerminalCommand("Command4", formatParser, comm4);

            terminalInputer.RegisterCommand(command1);
            terminalInputer.RegisterCommand(command2);
            terminalInputer.RegisterCommand(command3);
            terminalInputer.RegisterCommand(exitCommand);

            terminalInputer.RegisterCommand(commandWithFormatParser);

            terminalInputer.Show();
        }
    }
}