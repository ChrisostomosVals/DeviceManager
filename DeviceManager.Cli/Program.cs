using CommandLine;
using DataAdapter.Sdk.Sql;
using DeviceManager.Cli.Options;
using DeviceManager.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
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
                    return Task.FromResult(options);
                });
            if (parser.Errors.Count() > 0)
            {
                Console.WriteLine(parser.Errors.FirstOrDefault());
            }
            else
            {
                var cancellationToken = new CancellationToken();
                await CheckOptions(parser.Value, cancellationToken);
            }
        }
        static IServiceProvider ConfigureServices()
        {
            IServiceCollection collection = new ServiceCollection();
            return collection.BuildServiceProvider();
        }


        static async Task CheckOptions(GlobalOptions value, CancellationToken cancellationToken)
        {
            if (value.List != null)
            {
                switch (value.List)
                {
                    case "site":
                    case "sites":
                        SiteRepository siteRepository = new SiteRepository(new SqlAdapter(value.ConnectionString, "MSSQL"));
                        var sites = await siteRepository.FindAsync(cancellationToken);
                        foreach(var site in sites)
                        {
                            if (value.Verbose)
                                Console.WriteLine("SITE_ID {0}, NAME {1}, DSCR {2}, LAST_UPDATED {3}, LONGITUDE {4}, LATITUDE {5}", site.SITE_ID, site.NAME, site.DSCR, site.LAST_UPDATED, site.LONGITUDE, site.LATITUDE);
                            else
                                Console.WriteLine("SITE_ID {0}, NAME {1}", site.SITE_ID, site.NAME);
                        }
                        break;
                    case "device":
                    case "devices":
                        DeviceRepository deviceRepository = new DeviceRepository(new SqlAdapter(value.ConnectionString, "MSSQL"));
                        var devices = await deviceRepository.FindAsync(cancellationToken);
                        break;
                    default:
                        Console.WriteLine("Selected list type is wrong");
                        break;
                }
            }

        }
    }
}
