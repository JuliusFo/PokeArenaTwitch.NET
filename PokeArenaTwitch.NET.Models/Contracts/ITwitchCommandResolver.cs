using PokeArenaTwitch.NET.Models.Commands.Base;

namespace PokeArenaTwitch.NET.Models.Contracts
{
    public interface ITwitchCommandResolver
    {
        public string CommandStart { get; }

        public Task<CommandResult> Resolve(string commandParameter);
    }
}