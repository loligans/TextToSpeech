using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TextToSpeech.Common
{
    public interface ITextToSpeechServiceFactory<T>
    {
        public ITextToSpeechServiceFactory<T> AddCredentials(ICredentials credentials);
        public ITextToSpeechServiceFactory<T> AddHeader(string name, string value);

        /// <summary>
        /// Creates a TextToSpeechService.
        /// </summary>
        /// <exception cref="ArgumentNullException">The service requires authentication.</exception>
        public ITextToSpeechService Create();
    }
}
