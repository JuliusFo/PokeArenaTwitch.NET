namespace PokeArenaTwitch.NET.Models.Transfer
{
    public class TransferCatchedPokemon
    {
        #region Fields



        #endregion

        #region Constructor

        public TransferCatchedPokemon(TransferPokemon pokemon, int amountCatched, int amountOnFightingTeam)
        {
            Pokemon = pokemon;
            AmountCatched = amountCatched;
            AmountOnFightingTeam = amountOnFightingTeam;
        }

        #endregion

        #region Properties

        public TransferPokemon Pokemon { get; }

        public int AmountCatched { get; }

        public int AmountOnFightingTeam { get; }

        #endregion

        #region Methods



        #endregion
    }
}