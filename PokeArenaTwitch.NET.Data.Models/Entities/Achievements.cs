namespace PokeArenaTwitch.NET.Data.Models.Entities
{
    public class Achievements
    {
        #region Fields



        #endregion

        #region Constructor

        public Achievements(string twitchuser_Id, DateTime lastFight, decimal sdAchievment_Id, SdAchievement sdAchievement, Twitchuser twitchuser)
        {
            Twitchuser_Id = twitchuser_Id;
            LastFight = lastFight;
            SdAchievment_Id = sdAchievment_Id;
            SdAchievement = sdAchievement;
            Twitchuser = twitchuser;
        }

        #endregion

        #region Properties

        public decimal Achievement_Id { get; set; }

        public string Twitchuser_Id { get; set; }

        public DateTime LastFight { get; set; }

        public decimal SdAchievment_Id { get; set; }

        public virtual SdAchievement SdAchievement { get; set; }

        public virtual Twitchuser Twitchuser { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}