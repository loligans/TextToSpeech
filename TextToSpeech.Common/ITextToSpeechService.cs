using System;
using System.IO;
using System.Threading.Tasks;

namespace TextToSpeech.Common
{
    public interface ITextToSpeechService
    {
        /// <summary>
        /// Downloads audio from a TTS engine.
        /// </summary>
        /// <param name="input">The input to download audio from</param>
        /// <returns>An audio stream</returns>
        public Task<Stream?> Download(string input);
    }
}
