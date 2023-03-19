using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeArenaTwitch.NET.Data.Models.Entities;

namespace PokeArenaTwitch.NET.Data.Configurations.Configurations
{
    public class AchievementsConfiguration : IEntityTypeConfiguration<Achievements>
    {
        public void Configure(EntityTypeBuilder<Achievements> builder)
        {
            builder.ToTable("Achievements").HasKey(a => a.Achievement_Id);

            builder.HasOne(a => a.SdAchievement).WithMany().HasForeignKey(a => a.SdAchievment_Id);
        }
    }
}