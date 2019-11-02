using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WaveNetCapture.Google;

namespace WaveNetCapture
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureServices().BuildServiceProvider();
            await serviceProvider.GetService<Application>().Run(args);
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddHttpClient("google")
                    .ConfigurePrimaryHttpMessageHandler(() =>{
                        return new HttpClientHandler()
                        {
                            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                        };
                    });

            services.AddTransient<ITextToSpeechDownloader, GoogleWaveNetDownloader>();
            services.AddTransient<Application>();

            return services;
        }
    }
}
