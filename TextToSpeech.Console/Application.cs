using Google.WaveNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextToSpeech.Common;

namespace TextToSpeech
{
    public class Application
    {
        private readonly ITextToSpeechService _textToSpeechService;
        public Application(ITextToSpeechService textToSpeechService)
        {
            _textToSpeechService = textToSpeechService;
        }
        public async Task Run(string[] args)
        {
            await _textToSpeechService.Download("你好，你好吗");
        }
    }
}
