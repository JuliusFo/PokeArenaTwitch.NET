using PokeArenaTwitch.NET.Data.Models.Entities;
using PokeArenaTwitch.NET.Models.Transfer;

namespace PokeArenaTwitch.NET.Models.Extensions
{
    public static class TransferPokemonExtensions
    {
        public static TransferPokemon ConvertToTransfer(this SdPokemon entity)
        {
            return new TransferPokemon(entity.SdPokemon_Id, entity.Name, entity.Description, entity.HP, entity.Rarity, entity.Type, entity.ATK);
        }
    }
}