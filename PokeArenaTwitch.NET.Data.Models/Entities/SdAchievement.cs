namespace PokeArenaTwitch.NET.Data.Models.Entities
{
    public class SdAchievement
    {
        #region Fields



        #endregion

        #region Constructor

        public SdAchievement(string name, string description, string nPCName, short? unlockedOnCount)
        {
            Name = name;
            Description = description;
            NPCName = nPCName;
            UnlockedOnCount = unlockedOnCount;
        }

        #endregion

        #region Properties

        public decimal SdAchievement_Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string NPCName { get; set; }

        public short? UnlockedOnCount { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}