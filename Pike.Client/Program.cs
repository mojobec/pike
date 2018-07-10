using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Runtime;
using Pike.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pike.Client
{
    class Program
    {
        public static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            {
                try
                {
                    using (var client = await StartClientWithRetries())
                    {
                        await DoClientWork(client);
                        Console.ReadKey();
                    }

                    return 0;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                    return 1;
                }
            }
        }

        private static async Task<IClusterClient> StartClientWithRetries(int initializeAttemptsBeforeFailing = 5)
        {
            int attempt = 0;
            IClusterClient client;

            while (true)
            {

                try
                {
                    client = new ClientBuilder()
                                         .UseLocalhostClustering()
                                         .Configure<ClusterOptions>(options =>
                                         {
                                             options.ClusterId = "dev";
                                             options.ServiceId = "PikeService";
                                         })
                                         .ConfigureLogging(logging => logging.AddConsole())
                                         .Build();

                    await client.Connect();
                    Console.WriteLine("Client successfully connect to silo host");
                    break;
                }
                catch (SiloUnavailableException)
                {

                    attempt++;
                    Console.WriteLine($"Attempt {attempt} of {initializeAttemptsBeforeFailing} failed to initialize the Orleans client.");
                    if (attempt > initializeAttemptsBeforeFailing)
                    {
                        throw;
                    }
                    await Task.Delay(TimeSpan.FromSeconds(4)); ;
                }
            }

            return client;

        }
        private static async Task DoClientWork(IClusterClient client)
        {
            var country = client.GetGrain<ICountry>(Guid.NewGuid());
            var user = client.GetGrain<IUser>(Guid.NewGuid());
            await user.Visit(country);
            var countryVistors = await country.GetVisitors();
            Console.WriteLine("\n\n{0}\n\n", countryVistors.Count);
        }
    }
}
