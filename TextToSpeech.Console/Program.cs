using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TextToSpeech.Common;
using TextToSpeech.Engines.Google.WaveNet;

namespace TextToSpeech
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

            services.AddSingleton<ITextToSpeechServiceFactory<GoogleWaveNetServiceFactory>>();
            services.AddSingleton<Application>();

            return services;
        }
    }
}
