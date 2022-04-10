using HoneypotWebservice.Interfaces;
using System;
using System.Threading.Tasks;

namespace HoneypotWebservice.Concretes
{
    public class StreamContent : IStreamContent
    {
        public async Task GetResponseStream(System.IO.Stream responseStream, string streamContent)
        {
            await Task.Delay(5000);
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(streamContent + Environment.NewLine);
            await responseStream.WriteAsync(bytes);
            await responseStream.FlushAsync();
        }
    }
}