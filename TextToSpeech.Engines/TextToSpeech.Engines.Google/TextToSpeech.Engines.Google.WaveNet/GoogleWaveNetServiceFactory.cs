using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TextToSpeech.Common;

namespace TextToSpeech.Engines.Google.WaveNet
{
    public class GoogleWaveNetServiceFactory : ITextToSpeechServiceFactory<GoogleWaveNetServiceFactory>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDictionary<string, string> _httpHeaders = new Dictionary<string, string>();
        private ICredentials? _credentials { get; set; }
        public GoogleWaveNetServiceFactory(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public ITextToSpeechServiceFactory<GoogleWaveNetServiceFactory> AddCredentials(ICredentials credentials)
        {
            _credentials = credentials;
            return this;
        }

        public ITextToSpeechServiceFactory<GoogleWaveNetServiceFactory> AddHeader(string name, string value)
        {
            _httpHeaders.Add(name, value);
            return this;
        }

        public ITextToSpeechService Create()
        {
            if (_credentials is null) throw new ArgumentNullException($"{nameof(_credentials)} Cannot be null when using {nameof(GoogleWaveNetServiceFactory)}.");
            return new GoogleWaveNetService(_httpClientFactory, _httpHeaders, _credentials);;
        }
    }
}
