using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using TextToSpeech.Common;

namespace TextToSpeech.Engines.Google.WaveNet
{
    public class GoogleWaveNetServiceFactory : ITextToSpeechServiceFactory<GoogleWaveNetServiceFactory>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDictionary<string, string?> _httpHeaders;
        private string? Credentials { get; set; }
        public GoogleWaveNetServiceFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpHeaders = new Dictionary<string, string?>();
        }

        /// <inheritdoc />
        public ITextToSpeechServiceFactory<GoogleWaveNetServiceFactory> AddCredentials(string credentials)
        {
            Credentials = credentials;
            return this;
        }

        /// <inheritdoc />
        public ITextToSpeechServiceFactory<GoogleWaveNetServiceFactory> AddHeader(string name, string? value)
        {
            if (name is null) throw new ArgumentNullException($"{nameof(name)} cannot be null.");
            name = name.Trim();
            if (_httpHeaders.ContainsKey(name))
            {
                _httpHeaders[name] = value;
            }
            else
            {
                _httpHeaders.Add(name, value);
            }
            return this;
        }

        /// <inheritdoc />
        public ITextToSpeechService Create()
        {
            if (Credentials is null) throw new ArgumentNullException($"{nameof(Credentials)} Cannot be null when using {nameof(GoogleWaveNetServiceFactory)}.");
            return new GoogleWaveNetService(_httpClientFactory, _httpHeaders, Credentials);
        }
    }
}
