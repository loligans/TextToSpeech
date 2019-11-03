using System;
using System.Collections.Generic;
using System.Text;

namespace TextToSpeech.Common
{
    public interface ITextToSpeechServiceFactory
    {
        public T Create<T>() where T : ITextToSpeechService, new();
    }
}
