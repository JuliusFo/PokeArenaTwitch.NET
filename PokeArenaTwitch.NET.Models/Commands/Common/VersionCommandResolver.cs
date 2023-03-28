using PokeArenaTwitch.NET.Models.Commands.Base;
using PokeArenaTwitch.NET.Models.Contracts;

namespace PokeArenaTwitch.NET.Models.Commands.Common
{
    public class VersionCommandResolver : ITwitchCommandResolver
    {
        #region Fields

        private readonly string currentMajor = "1";
        private readonly string currentMinor = "0";
        private readonly string currentPatch = "0";
        private readonly string currentPatchVersion = "0";

        #endregion

        #region Constructor

        public VersionCommandResolver()
        {
            CommandStart = "!version";
        }

        #endregion

        #region Properties

        public string CommandStart { get; set; }

        #endregion

        #region Methods

        public async Task<CommandResult> Resolve(string command)
        {
            return await Task.FromResult(new CommandResult($"PokeArena Version {currentMajor}.{currentMinor}.{currentPatch}.{currentPatchVersion}", CommandResultType.Success));
        }

        #endregion
    }
}