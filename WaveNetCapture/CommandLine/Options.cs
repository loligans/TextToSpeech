using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaveNetCapture.CommandLine
{
    public class Options
    {
        [Option(Required = true)]
        public string? LanguageInput { get; set; }
        [Option(Required = true)]
        public string? Token { get; set; }
    }
}
