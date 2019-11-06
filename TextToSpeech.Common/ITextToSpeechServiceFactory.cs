using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TextToSpeech.Common
{
    public interface ITextToSpeechServiceFactory<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials">The credentials to use.</param>
        public ITextToSpeechServiceFactory<T> AddCredentials(string credentials);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <exception cref="ArgumentNullException">The header name cannot be null.</exception>
        public ITextToSpeechServiceFactory<T> AddHeader(string name, string? value);

        /// <summary>
        /// Creates a TextToSpeechService.
        /// </summary>
        /// <exception cref="ArgumentNullException">The service requires authentication.</exception>
        public ITextToSpeechService Create();
    }
}
