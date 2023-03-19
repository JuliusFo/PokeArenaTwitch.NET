using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeArenaTwitch.NET.Data.Models.Entities;

namespace PokeArenaTwitch.NET.Data.Configurations.Configurations
{
    public class SdPokemonConfiguration : IEntityTypeConfiguration<SdPokemon>
    {
        public void Configure(EntityTypeBuilder<SdPokemon> builder)
        {
            builder.ToTable("SdPokemon").HasKey(a => a.SdPokemon_Id);
        }
    }
}