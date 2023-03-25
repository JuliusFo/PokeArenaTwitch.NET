using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokeArenaTwitch.NET.Data;
using PokeArenaTwitch.NET.Services.Pokemon;
using PokeArenaTwitch.NET.Services.Twitch;

namespace PokeArenaTwitch.NET // Note: actual namespace depends on the project name.
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
            })
            .Build();

            Console.WriteLine("Test-Run");
        }
    }
}