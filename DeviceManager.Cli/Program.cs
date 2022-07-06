using CommandLine;
using DeviceManager.Cli.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DeviceManager.Cli
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var parser = await Parser.Default.ParseArguments<GlobalOptions>(args)
                .WithParsedAsync<GlobalOptions>(options =>
                {
                    IServiceProvider provider = ConfigureServices();
                    return Task.CompletedTask;
                });
        }
        static IServiceProvider ConfigureServices()
        {
            IServiceCollection collection = new ServiceCollection();
            return collection.BuildServiceProvider();
        }

    }
}
