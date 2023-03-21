using Microsoft.EntityFrameworkCore;
using PokeArenaTwitch.NET.Data;
using PokeArenaTwitch.NET.Data.Models.Entities;
using PokeArenaTwitch.NET.Models.Extensions;
using PokeArenaTwitch.NET.Models.Transfer;

namespace PokeArenaTwitch.NET.Services.Twitch
{
    public class TwitchUserService
    {
        #region Fields

        private readonly AppDbContext db;

        #endregion

        #region Constructor

        public TwitchUserService(AppDbContext db)
        {
            this.db = db;
        }

        #endregion

        #region Properties



        #endregion

        #region Methods

        public async Task<bool> IsUserRegisteredAsync(string userid, CancellationToken cancellationToken)
        {
            return await db.Twitchuser.AnyAsync(tu => tu.Twitchuser_Id == userid, cancellationToken);
        }

        public async Task RegisterUserAsync(string userid, string displayname, SdPokemon starter, CancellationToken cancellationToken)
        {
            if (!await IsUserRegisteredAsync(userid, cancellationToken))
            {
                Twitchuser newUser = new Twitchuser(userid, displayname, true);
                _ = await db.Set<Twitchuser>().AddAsync(newUser, cancellationToken);

                await AddCatchedPokemonAsync(userid, starter, false, cancellationToken);
                _ = await db.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteUserAsync(string userId, CancellationToken cancellationToken)
        {
            if (await IsUserRegisteredAsync(userId, cancellationToken))
            {
                db.CatchedPokemon.RemoveRange(db.CatchedPokemon.Where(cp => cp.Twitchuser_Id == userId));
                db.Achievements.RemoveRange(db.Achievements.Where(a => a.Twitchuser_Id == userId));
                _ = db.Twitchuser.Remove(db.Twitchuser.Where(tu => tu.Twitchuser_Id == userId).First());

                _ = await db.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<TransferTwitchUser?> GetUserAsync(string userid, CancellationToken cancellationToken)
        {
            Twitchuser? entity = await db.Twitchuser.FirstOrDefaultAsync(tw => tw.Twitchuser_Id == userid, cancellationToken);

            if (null == entity)
            {
                return null;
            }

            return entity.ConvertToTransfer();
        }

        public async Task AddCatchedPokemonAsync(string userId, SdPokemon catchedPokemon, bool withSave, CancellationToken cancellationToken)
        {
            if (!await IsUserRegisteredAsync(userId, cancellationToken))
            {
                return;
            }

            CatchedPokemon? existingPokemonEntry = await db.CatchedPokemon.FirstOrDefaultAsync(cp => cp.Twitchuser_Id == userId && cp.SdPokemon.Name == catchedPokemon.Name, cancellationToken);

            if (null == existingPokemonEntry)
            {
                SdPokemon? pokemon = await db.SdPokemon.FirstOrDefaultAsync(pkm => pkm.Name == catchedPokemon.Name, cancellationToken);

                if (null == pokemon)
                {
                    return;
                }

                _ = await db.Set<CatchedPokemon>().AddAsync(new CatchedPokemon(1, 0, pokemon.SdPokemon_Id, userId), cancellationToken);
            }
            else
            {
                _ = existingPokemonEntry.Pokemon_AmountCatched += 1;
            }

            if (withSave)
            {
                _ = await db.SaveChangesAsync(cancellationToken);
            }
        }

        #endregion
    }
}