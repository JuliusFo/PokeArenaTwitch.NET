using PokeArenaTwitch.NET.Data.Models.Entities;

namespace PokeArenaTwitch.NET.Models.Transfer.Extensions
{
    public static class TransferUserExtensions
    {
        public static TransferTwitchUser ConvertToTransfer(this Twitchuser entity)
        {
            return new TransferTwitchUser(entity.Twitchuser_Id, entity.DisplayName, entity.Kz_Log_Enabled, entity.CatchedPokemon.Select(c => c.ConvertToTransfer()).ToList(), DateTime.Now);
        }
    }
}