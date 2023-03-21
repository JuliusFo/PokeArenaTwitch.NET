﻿using PokeArenaTwitch.NET.Data.Models.Entities;
using PokeArenaTwitch.NET.Models.Transfer;

namespace PokeArenaTwitch.NET.Models.Extensions
{
    public static class TransferPokemonExtensions
    {
        public static TransferPokemon ConvertToTransfer(this SdPokemon entity)
        {
            return new TransferPokemon(entity.SdPokemon_Id, entity.Name, entity.Description, entity.HP, entity.Rarity, entity.Type, entity.ATK);
        }

        public static TransferCatchedPokemon ConvertToTransfer(this CatchedPokemon entity)
        {
            return new TransferCatchedPokemon(entity.SdPokemon.ConvertToTransfer(), entity.Pokemon_AmountCatched, entity.Pokemon_AmountOnFightingTeam);
        }
    }
}