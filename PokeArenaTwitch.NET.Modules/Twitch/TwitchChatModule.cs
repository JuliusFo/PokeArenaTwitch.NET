using PokeArenaTwitch.NET.Models.Commands.Base;
using PokeArenaTwitch.NET.Models.Contracts;
using PokeArenaTwitch.NET.Modules.Common;
using PokeArenaTwitch.NET.Resources;
using PokeArenaTwitch.NET.Services.Twitch;
using TwitchLib.Api;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

namespace PokeArenaTwitch.NET.Modules.Twitch
{
    public class TwitchChatModule : IPokeArenaModule
    {
        #region Fields

        private readonly TwitchAPI twitchAPI;
        private readonly TwitchClient twitchclient;
        private readonly TwitchAccessService twitchAccessService;

        private readonly string botName = "p_ArenaBot";
        private readonly string channelName = "Skei7";

        private bool automaticreconnect = true;
        private int reconnectTries = 0;
        private readonly int reconnectTriesMAX = 3;
        private readonly int reconnectWaitTime = 120;

        private readonly IEnumerable<ITwitchCommandResolver> commandResolvers;

        #endregion

        #region Constructor

        public TwitchChatModule(
            TwitchAccessService twitchAccessService,
            IEnumerable<ITwitchCommandResolver> commandResolvers)
        {
            this.twitchAccessService = twitchAccessService;
            this.commandResolvers = commandResolvers;

            twitchclient = new TwitchClient();

            twitchAPI = new TwitchAPI();
            twitchAPI.Settings.ClientId = twitchAccessService.GetTwitchClientID();
            twitchAPI.Settings.AccessToken = twitchAccessService.GetTwitchAccessToken();

            Connect();
        }

        #endregion

        #region Properties



        #endregion

        #region Methods

        public void Connect()
        {
            twitchclient.Initialize(new ConnectionCredentials(botName, twitchAccessService.GetTwitchAccessToken()), channel: channelName);
            twitchclient.Connect();

            twitchclient.OnJoinedChannel += OnJoinedChannel;
            twitchclient.OnDisconnected += OnDisconnected;
            twitchclient.OnMessageReceived += OnMessageReceived;
        }

        public void Disconnect()
        {
            automaticreconnect = false;
            twitchclient.Disconnect();
        }

        #region Events

        private void OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
        {
            reconnectTries = 0;
            LogWriter.Log($"Connected to channel {channelName}.");
        }

        private void OnDisconnected(object? sender, OnDisconnectedEventArgs e)
        {
            LogWriter.LogWarning($"Bot disconnected.");

            if (automaticreconnect)
            {
                if (reconnectTries < reconnectTriesMAX)
                {
                    twitchclient.Reconnect();
                    reconnectTries += 1;
                }
                else
                {
                    LogWriter.Log($"Bot disconnected, reached {reconnectTriesMAX} reconnects->Waiting.");
                    Thread.Sleep(reconnectWaitTime);
                    reconnectTries = 1;
                    twitchclient.Reconnect();
                }
            }
        }

        private async void OnMessageReceived(object? sender, OnMessageReceivedArgs e)
        {
            if(e.ChatMessage == null || string.IsNullOrWhiteSpace(e.ChatMessage.Message))
            {
                return;
            }

            ITwitchCommandResolver? resolver = commandResolvers.FirstOrDefault(r => e.ChatMessage.Message.StartsWith(r.CommandStart));

            if(resolver == null)
            {
                twitchclient.SendMessage(channelName, string.Format(MessageResources.UnknownCommand, e.ChatMessage.Username));
                return;
            }

            CommandResult commandResult = await resolver.Resolve(e.ChatMessage.Message);

            twitchclient.SendMessage(channelName, commandResult.Result);
        }

        #endregion

        #endregion
    }
}