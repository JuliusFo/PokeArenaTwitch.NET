using System.Text;

namespace PokeArenaTwitch.NET.Services.Twitch
{
    public class TwitchAccessService
    {
        #region Fields

        private readonly string path = "C:/Temp/creds.txt";

        #endregion

        #region Constructor

        public TwitchAccessService()
        {

        }

        #endregion

        #region Properties



        #endregion

        #region Methods

        public string GetTwitchClientID()
        {
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            string text;

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            return text.Split(' ')[0];
        }

        public string GetTwitchAccessToken()
        {
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            string text;

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            return text.Split(' ')[1];
        }

        #endregion
    }
}