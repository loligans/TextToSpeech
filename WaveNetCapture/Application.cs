using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaveNetCapture.Google;

namespace WaveNetCapture
{
    public class Application
    {
        private readonly ITextToSpeechDownloader _textToSpeechDownloader;
        public Application(ITextToSpeechDownloader textToSpeechDownloader)
        {
            _textToSpeechDownloader = textToSpeechDownloader;
        }
        public async Task Run(string[] args)
        {
            await _textToSpeechDownloader.DownloadAudio(
                "C:\\Users\\ethan.lindemann\\Downloads\\audio.mp3",
                "03AOLTBLSg8f0cFVp4NEeH3X9hEvkC_YVJQx4CenTgT4rbLfhbJl2M_pYssJuIRUJZUQn2cA_tgpKwVevNk_XkzvkZbKSTqqFDXrc7px26pM7vuH0JIHZGHracPRlDRLjWihOddSYth-SRgZcKwDODEJRO3UdHroiSeHKyPX_8lpAVq6cxOseixzHALz2tizSwAlNmcOKII8agVQImsTc2Wv2CZUMOeyjZ5Ar7s2YKZN146y5kiKfy25LNmmee1o4CIrcGnA5xfhAZGU7AHm3mnzSsnNWPeRj1clBxmJoUe95q-EvUBBWjTfaIsZgg5s8prMZx_asjZjnuk5ua1MLfr6aqy-s_EOevuMFzfWpM9xqrLjC0yMkFW4qFpfbdRit1NMl3i7HHHk-FdP3_FqDyrZmMbxOl4oaSf-WxTqx7YdP8vc6axuytluRnn_r886nz3-bDTGO1oSLhUgKkWkBGsoO-TqzTs4LXXf7sD9eqn6qqBIX2hr1da_96tQOIxb56FrhoND575B2i", 
                "你好，你好吗");
        }
    }
}
