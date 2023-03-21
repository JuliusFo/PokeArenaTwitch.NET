namespace PokeArenaTwitch.NET.Data.Models.Entities;

public class CatchedPokemon
{
    #region Fields



    #endregion

    #region Constructor

    public CatchedPokemon(int pokemon_AmountCatched, int pokemon_AmountOnFightingTeam, decimal sdPokemon_Id, string twitchuser_Id)
    {
        Pokemon_AmountCatched = pokemon_AmountCatched;
        Pokemon_AmountOnFightingTeam = pokemon_AmountOnFightingTeam;
        SdPokemon_Id = sdPokemon_Id;
        Twitchuser_Id = twitchuser_Id;
    }

    #endregion

    #region Properties

    public decimal CatchedPokemon_Id { get; set; }

    public int Pokemon_AmountCatched { get; set; }

    public int Pokemon_AmountOnFightingTeam { get; set; }

    public decimal SdPokemon_Id { get; set; }

    public string Twitchuser_Id { get; set; }

    public virtual SdPokemon? SdPokemon { get; set; }

    public virtual Twitchuser? Twitchuser { get; set; }

    #endregion

    #region Methods



    #endregion
}