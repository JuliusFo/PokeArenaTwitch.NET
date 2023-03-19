using PokeArenaTwitch.NET.Common.Models.Codes;

namespace PokeArenaTwitch.NET.Data.Models.Entities;

public class SdPokemon
{
    #region Fields



    #endregion

    #region Constructor

    public SdPokemon(string name, string description, PokemonType type, float hP, PokemonRarity rarity, float aTK)
    {
        Name = name;
        Description = description;
        Type = type;
        HP = hP;
        Rarity = rarity;
        ATK = aTK;
    }

    #endregion

    #region Properties

    public decimal SdPokemon_Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public PokemonType Type { get; set; }

    public float HP { get; set; }

    public PokemonRarity Rarity { get; set; }

    public float ATK { get; set; }

    #endregion

    #region Methods



    #endregion
}