using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeArenaTwitch.NET.Data.Models.Entities;

namespace PokeArenaTwitch.NET.Data.Configurations.Configurations
{
    public class CatchedPokemonConfiguration : IEntityTypeConfiguration<CatchedPokemon>
    {
        public void Configure(EntityTypeBuilder<CatchedPokemon> builder)
        {
            builder.ToTable("CatchedPokemon").HasKey(c => c.CatchedPokemon_Id);

            builder.HasOne(c => c.SdPokemon).WithMany().HasForeignKey(c => c.SdPokemon_Id);
            builder.HasOne(c => c.Twitchuser).WithMany(u => u.CatchedPokemon).HasForeignKey(c => c.Twitchuser_Id);
        }
    }
}