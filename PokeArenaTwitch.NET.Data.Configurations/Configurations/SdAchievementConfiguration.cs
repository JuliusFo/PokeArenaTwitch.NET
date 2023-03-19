using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeArenaTwitch.NET.Data.Models.Entities;

namespace PokeArenaTwitch.NET.Data.Configurations.Configurations
{
    public class SdAchievementConfiguration : IEntityTypeConfiguration<SdAchievement>
    {
        public void Configure(EntityTypeBuilder<SdAchievement> builder)
        {
            builder.ToTable("SdAchievement").HasKey(a => a.SdAchievement_Id);
        }
    }
}