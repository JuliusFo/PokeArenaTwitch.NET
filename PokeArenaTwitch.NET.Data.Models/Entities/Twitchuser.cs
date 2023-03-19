namespace PokeArenaTwitch.NET.Data.Models.Entities
{
    public class Twitchuser
    {
        #region Fields



        #endregion

        #region Constructor

        public Twitchuser(string displayName, bool kz_Log_Enabled)
        {
            DisplayName = displayName;
            Kz_Log_Enabled = kz_Log_Enabled;
        }

        #endregion

        #region Properties

        public decimal Twitchuser_Id { get; set; }

        public string DisplayName { get; set; }

        public bool Kz_Log_Enabled { get; set; }

        public virtual ICollection<CatchedPokemon> CatchedPokemon { get; set; } = new List<CatchedPokemon>();

        public virtual ICollection<Achievements> Achievements { get; set; } = new List<Achievements>();

        #endregion

        #region Methods



        #endregion
    }
}