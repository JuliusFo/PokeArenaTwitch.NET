namespace PokeArenaTwitch.NET.Models.Transfer
{
    public class TransferTwitchUser
    {
        #region Fields



        #endregion

        #region Constructor

        public TransferTwitchUser(string id, string displayName, bool kzLogEnabled, List<TransferCatchedPokemon> catchedPokemonList, DateTime lastUserFight)
        {
            Id = id;
            DisplayName = displayName;
            KzLogEnabled = kzLogEnabled;
            CatchedPokemonList = catchedPokemonList;
            LastUserFight = lastUserFight;
        }

        #endregion

        #region Properties

        public string Id { get; }

        public string DisplayName { get; }

        public bool KzLogEnabled { get; }

        public List<TransferCatchedPokemon> CatchedPokemonList { get; } = new List<TransferCatchedPokemon>();

        public DateTime LastUserFight { get; }

        #endregion Properties

        #region Methods



        #endregion
    }
}