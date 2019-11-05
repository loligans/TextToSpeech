using System;
using System.Threading.Tasks;
using TextToSpeech.Common;
using TextToSpeech.Engines.Google.WaveNet;
using Microsoft.Extensions.DependencyInjection;

namespace TextToSpeech
{
    public class Application
    {
        private readonly IServiceProvider _serviceProvider;
        public Application(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Run(string[] args)
        {
            var factory = _serviceProvider.GetService<ITextToSpeechServiceFactory<GoogleWaveNetServiceFactory>>();
            var service = factory.Create();
            await service.Download("你好，你好吗");
        }
    }
}
