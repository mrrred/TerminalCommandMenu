using TerminalCommandMenu.Abstractions;

namespace TerminalCommandMenu
{
    public class Command : ICommand<string[]>
    {
        Action<string[]> _action;

        public Command()
        {
            
        }

        public void Execute(string[] arguments)
        {
            
        }
    }
}
