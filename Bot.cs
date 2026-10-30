using dotenv.net;
using Microsoft.Extensions.Hosting;
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
            //options.Intents = ;
            options.Token = Environment.GetEnvironmentVariable("Token");
        }).AddGatewayHandlers(typeof(Bot).Assembly);
        
        var host = builder.Build();

        await host.RunAsync();
    }
} 