using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeArenaTwitch.NET.Data.Models.Entities;

namespace PokeArenaTwitch.NET.Data.Configurations.Configurations
{
    public class TwitchuserConfiguration : IEntityTypeConfiguration<Twitchuser>
    {
        public void Configure(EntityTypeBuilder<Twitchuser> builder)
        {
            builder.ToTable("Twitchuser").HasKey(a => a.Twitchuser_Id);
        }
    }
}