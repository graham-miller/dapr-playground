using System;
using Dapr.Actors.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MyActorService
{
    public class Program
    {
        private const int APP_CHANNEL_HTTP_PORT = 3000;

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseActors(actorRuntime =>
                {
                    // Optional - override default actor settings
                    actorRuntime.ConfigureActorSettings(a =>
                    {
                        a.ActorIdleTimeout = TimeSpan.FromSeconds(5);
                        a.ActorScanInterval = TimeSpan.FromSeconds(5);
                    });

                    // Register MyActor actor type
                    actorRuntime.RegisterActor<MyActor>();
                })
                .UseUrls($"http://localhost:{APP_CHANNEL_HTTP_PORT}/");
    }
}
