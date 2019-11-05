using Google.WaveNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TextToSpeech.Common;

namespace TextToSpeech.Engines.Google.WaveNet
{
    internal class GoogleWaveNetService : ITextToSpeechService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDictionary<string, string> _httpHeaders;
        private readonly ICredentials _credentials;
        private readonly string _waveNetAddress = "https://cxl-services.appspot.com/proxy?url=https://texttospeech.googleapis.com/v1beta1/text:synthesize&token={0}";

        public GoogleWaveNetService(IHttpClientFactory httpClientFactory, IDictionary<string, string> httpHeaders, ICredentials credentials)
        {
            _httpClientFactory = httpClientFactory;
            _httpHeaders = httpHeaders;
            _credentials = credentials;
        }

        /// <inheritDoc />
        public async Task<Stream?> Download(string input)
        {
            // TODO: Add token
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format(_waveNetAddress, ""));
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Host", "cxl-services.appspot.com");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:72.0) Gecko/20100101 Firefox/72.0");

            request.Content = new StringContent("{\"input\":{\"text\":\"你好，你好吗\"},\"voice\":{\"languageCode\":\"cmn-CN\",\"name\":\"cmn-CN-Wavenet-B\"},\"audioConfig\":{\"audioEncoding\":\"LINEAR16\",\"pitch\":0,\"speakingRate\":1}}", Encoding.UTF8, "text/plain");

            var client = _httpClientFactory.CreateClient("google");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stream = response.Content.ReadAsStreamAsync();
                var audioResponse = await JsonSerializer.DeserializeAsync<AudioContentResponse>(await stream);
                byte[] rawAudio = Convert.FromBase64String(audioResponse.audioContent);
                var rawAudioStream = new MemoryStream(rawAudio);
                return rawAudioStream;
            }
            
            return null;
        }
    }
}
