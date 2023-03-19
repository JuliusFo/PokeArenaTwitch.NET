using Microsoft.EntityFrameworkCore;
using PokeArenaTwitch.NET.Data.Configurations;
using PokeArenaTwitch.NET.Data.Models.Entities;

namespace PokeArenaTwitch.NET.Data
{
    public class AppDbContext : DbContext
    {
        #region Fields



        #endregion

        #region Constructor

        public AppDbContext()
        {

        }

        #endregion

        #region Properties

        public virtual DbSet<CatchedPokemon> CatchedPokemon { get; set; }

        public virtual DbSet<Twitchuser> Twitchuser { get; set; }

        public virtual DbSet<Achievements> Achievements { get; set; }

        public virtual DbSet<SdAchievement> SdAchievement { get; set; }

        public virtual DbSet<SdPokemon> SdPokemon { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataConfigurations).Assembly);
        }

        #endregion
    }
}