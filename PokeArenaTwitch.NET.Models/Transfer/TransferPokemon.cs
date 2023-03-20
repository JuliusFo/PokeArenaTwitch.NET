using PokeArenaTwitch.NET.Common.Models.Codes;

namespace PokeArenaTwitch.NET.Models.Transfer
{
    public class TransferPokemon
    {
        #region Fields



        #endregion

        #region Constructor

        public TransferPokemon(decimal id, string name, string description, float hP, PokemonRarity rarity, PokemonType type, float aTK)
        {
            Id = id;
            Name = name;
            Description = description;
            HP = hP;
            Rarity = rarity;
            Type = type;
            ATK = aTK;
        }

        #endregion

        #region Properties

        public decimal Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float HP { get; set; }

        public PokemonRarity Rarity { get; set; }

        public PokemonType Type { get; set; }

        public float ATK { get; set; }

        #endregion

        #region Methods

        public override bool Equals(object? obj)
        {
            var item = obj as TransferPokemon;

            if (item == null)
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}