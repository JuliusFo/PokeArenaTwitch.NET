using PokeArenaTwitch.NET.Models.Commands.Common;

namespace PokeArenaTwitch.NET.Models.Contracts
{
    public interface ITwitchCommandSolver
    {
        public string CommandStart { get; }

        public Task<CommandResult> Execute(string commandParameter);
    }
}