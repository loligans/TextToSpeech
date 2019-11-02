using System;
using System.Collections.Generic;
using System.Text;

namespace TextToSpeechDownloader.Common
{
    public interface ITextToSpeechDownloadFactory
    {
        public T Create<T>() where T : ITextToSpeechDownloadService, new();
    }

    public class TextToSpeechDownloadFactory : ITextToSpeechDownloadFactory
    {
        public T Create<T>() where T : ITextToSpeechDownloadService, new()
        {
            return new T();
        }
    }
}
