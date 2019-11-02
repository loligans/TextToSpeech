using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WaveNetCapture.Google.Models;

namespace WaveNetCapture.Google
{
    public interface ITextToSpeechDownloader
    {
        /// <summary>
        /// Downloads audio from a TTS engine.
        /// </summary>
        /// <param name="endpoint">The endpoint to hit.</param>
        /// <param name="token">The token to use for authentication.</param>
        /// <param name="input">The input to download audio from</param>
        /// <returns>An audio stream</returns>
        public Task<Stream?> DownloadAudio(string path, string token, string input);
    }

    public class GoogleWaveNetDownloader : ITextToSpeechDownloader
    {
        private readonly string _waveNetAddress = "https://cxl-services.appspot.com/proxy?url=https://texttospeech.googleapis.com/v1beta1/text:synthesize&token={0}";
        private readonly IHttpClientFactory _clientFactory;
        public GoogleWaveNetDownloader(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        /// <inheritDoc />
        public async Task<Stream?> DownloadAudio(string path, string token, string input)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format(_waveNetAddress, token));
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Host", "cxl-services.appspot.com");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:72.0) Gecko/20100101 Firefox/72.0");

            request.Content = new StringContent("{\"input\":{\"text\":\"你好，你好吗\"},\"voice\":{\"languageCode\":\"cmn-CN\",\"name\":\"cmn-CN-Wavenet-B\"},\"audioConfig\":{\"audioEncoding\":\"LINEAR16\",\"pitch\":0,\"speakingRate\":1}}", Encoding.UTF8, "text/plain");

            var client = _clientFactory.CreateClient("google");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stream = response.Content.ReadAsStreamAsync();
                var audioResponse = await JsonSerializer.DeserializeAsync<AudioContentResponse>(await stream);
                byte[] audio = Convert.FromBase64String(audioResponse.audioContent);
                await File.WriteAllBytesAsync(path, audio);
            }
            
            return null;
        }

        
    }
}
