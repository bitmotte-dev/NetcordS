using dotenv.net;
using Microsoft.Extensions.Hosting;
using NetCord.Gateway;
using NetCord.Hosting.Gateway;

namespace NetcordS;

static class Bot
{
    static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        DotEnv.Load();

        builder.Services.AddDiscordGateway(options =>
        {
            //intents
            //options.Intents = GatewayIntents.MessageContent;
            
            //token
            options.Token = Environment.GetEnvironmentVariable("Token");
        }
        ).AddGatewayHandlers(typeof(Bot).Assembly);
        
        var host = builder.Build();

        await host.RunAsync();
    }
} 