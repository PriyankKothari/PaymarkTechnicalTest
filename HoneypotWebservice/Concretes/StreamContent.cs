using HoneypotWebservice.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HoneypotWebservice.Concretes
{
    public class StreamContent : IStreamContent
    {
        public int? MillisecondsDelay { get; set; }

        public bool? IncludeNewLineCharacter { get; set; }

        public StreamContent(int? millisecondsDelay, bool? includeNewLineCharacter)
        {
            this.MillisecondsDelay = millisecondsDelay;
            this.IncludeNewLineCharacter = includeNewLineCharacter;
        }

        public async Task WriteStreamAsync(Stream responseStream, string streamContent)
        {
            await Task.Delay(this.MillisecondsDelay.GetValueOrDefault(0));
            byte[] bytes = Encoding.ASCII.GetBytes($"{streamContent}{(this.IncludeNewLineCharacter.GetValueOrDefault(false) ? Environment.NewLine : string.Empty)}");
            await responseStream.WriteAsync(bytes);
            await responseStream.FlushAsync();
        }
    }
}