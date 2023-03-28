using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokeArenaTwitch.NET.Data;
using PokeArenaTwitch.NET.Models.Commands.Common;
using PokeArenaTwitch.NET.Models.Contracts;
using PokeArenaTwitch.NET.Modules.Twitch;
using PokeArenaTwitch.NET.Services.Pokemon;
using PokeArenaTwitch.NET.Services.Twitch;

namespace PokeArenaTwitch.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddDbContext<AppDbContext>();
                services.AddScoped<TwitchUserService>();
                services.AddScoped<TwitchAccessService>();
                services.AddScoped<PokemonMasterDataService>();
                services.AddScoped<TwitchChatModule>();
                services.AddTransient<ITwitchCommandResolver, VersionCommandResolver>();
            })
            .Build();

            Console.WriteLine("=======================");
            Console.WriteLine("PokeArenaTwitch.NET");
            Console.WriteLine("=======================");

            string? command = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(command))
            {
                if(command == "exit")
                {
                    TwitchChatModule? chatModule = host.Services.GetService<TwitchChatModule>();

                    if(null != chatModule)
                    {
                        chatModule.Disconnect();
                    }
                }
            }
        }
    }
}