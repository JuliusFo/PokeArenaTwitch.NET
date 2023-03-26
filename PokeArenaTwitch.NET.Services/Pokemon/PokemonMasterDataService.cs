using Microsoft.EntityFrameworkCore;
using PokeArenaTwitch.NET.Common.Models.Codes;
using PokeArenaTwitch.NET.Common.Models.Constants;
using PokeArenaTwitch.NET.Data;
using PokeArenaTwitch.NET.Data.Models.Entities;
using PokeArenaTwitch.NET.Models.Transfer;
using PokeArenaTwitch.NET.Models.Transfer.Extensions;

namespace PokeArenaTwitch.NET.Services.Pokemon
{
    public class PokemonMasterDataService
    {
        #region Fields

        private readonly AppDbContext db;

        #endregion

        #region Constructor

        public PokemonMasterDataService(AppDbContext db)
        {
            this.db = db;
        }

        #endregion

        #region Methods

        public async Task<TransferPokemon?> GetPokemonByNameAsync(string pokemonName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(pokemonName))
            {
                return null;
            }

            SdPokemon? entity = await db.SdPokemon.FirstOrDefaultAsync(p => p.Name == pokemonName, cancellationToken);

            if (entity == null)
            {
                return null;
            }
            else
            {
                return entity.ConvertToTransfer();
            }
        }

        public async Task<TransferPokemon?> GetPokemonByRandomAsync(PokemonRarity? rarity = null)
        {
            Random rnd = new Random();
            IEnumerable<SdPokemon> entityList;
            if (null == rarity)
            {
                entityList = await db.SdPokemon.ToListAsync();
            }
            else
            {
                entityList = await db.SdPokemon.Where(p => p.Rarity == rarity.Value).ToListAsync();
            }


            if (entityList.Any())
            {
                return entityList.ElementAt(rnd.Next(0, entityList.Count())).ConvertToTransfer();
            }

            return null;
        }

        public async Task<TransferPokemon?> GetPokemonByParticipantCount(int participantCount)
        {
            Dictionary<PokemonRarity, int> rarityChances = new Dictionary<PokemonRarity, int>();
            Random rnd = new Random();
            int commonChance;
            int rareChance;
            int ultrarareChance;
            int legendaryChance;

            if (participantCount >= 15)
            {
                rarityChances.Add(PokemonRarity.Legendary, 8);
                rarityChances.Add(PokemonRarity.Ultrarare, 25);
                rarityChances.Add(PokemonRarity.Rare, 37);
                rarityChances.Add(PokemonRarity.Common, 30);
            }
            else
            {
                rarityChances.Add(PokemonRarity.Legendary, 5 + Convert.ToInt32(participantCount * 0.2));
                rarityChances.Add(PokemonRarity.Ultrarare, 20 + Convert.ToInt32(participantCount * 0.2));
                rarityChances.Add(PokemonRarity.Rare, 30 + Convert.ToInt32(participantCount * 0.2));
                rarityChances.Add(PokemonRarity.Common, 45 - 3 * (Convert.ToInt32(participantCount * 0.2)));
            }

            rarityChances.TryGetValue(PokemonRarity.Common, out commonChance);
            rarityChances.TryGetValue(PokemonRarity.Rare, out rareChance);
            rarityChances.TryGetValue(PokemonRarity.Ultrarare, out ultrarareChance);
            rarityChances.TryGetValue(PokemonRarity.Legendary, out legendaryChance);

            int percent = rnd.Next(1, 101);

            if (percent < legendaryChance)
            {
                return await GetPokemonByRandomAsync(PokemonRarity.Legendary);
            }
            else if (percent < (legendaryChance + ultrarareChance))
            {
                return await GetPokemonByRandomAsync(PokemonRarity.Ultrarare);
            }
            else if (percent < (legendaryChance + ultrarareChance + rareChance))
            {
                return await GetPokemonByRandomAsync(PokemonRarity.Rare);
            }
            else if (percent < (legendaryChance + ultrarareChance + rareChance + commonChance))
            {
                return await GetPokemonByRandomAsync(PokemonRarity.Common);
            }

            return await GetPokemonByRandomAsync();
        }

        public float GetTypeAdvantageMultiplikator(PokemonType Attacker, PokemonType Defender)
        {
            if (Attacker == PokemonType.Normal)
            {
                switch (Defender)
                {
                    case PokemonType.Rock: return PokemonTypeAdvantage.DISADV;
                    case PokemonType.Ghost: return PokemonTypeAdvantage.DISADV;
                    default: return PokemonTypeAdvantage.NORMAL;
                }
            }

            if (Attacker == PokemonType.Fight)
            {
                switch (Defender)
                {
                    case PokemonType.Normal: return PokemonTypeAdvantage.ADV;
                    case PokemonType.Flying: return PokemonTypeAdvantage.DISADV;
                    default: return PokemonTypeAdvantage.NORMAL;
                }
            }

            return PokemonTypeAdvantage.NORMAL;
        }

        #endregion
    }
}