using Google.WaveNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextToSpeechDownloader.Common;

namespace TextToSpeechDownloader
{
    public class Application
    {
        private readonly ITextToSpeechDownloadService _textToSpeechDownloadService;
        public Application(ITextToSpeechDownloadService textToSpeechDownloader)
        {
            _textToSpeechDownloadService = textToSpeechDownloader;
        }
        public async Task Run(string[] args)
        {
            await _textToSpeechDownloadService.Download("你好，你好吗");
        }
    }
}
