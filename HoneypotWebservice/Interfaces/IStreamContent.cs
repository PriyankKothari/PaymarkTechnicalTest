using System.IO;
using System.Threading.Tasks;

namespace HoneypotWebservice.Interfaces
{
    public interface IStreamContent
    {
        /// <summary>
        /// Asynchronously writes stream content as a sequence of bytes to the response stream
        /// </summary>
        /// <param name="responseStream">System.IO.Stream ResponseStream</param>
        /// <param name="streamContent">System.String StreamContent</param>
        /// <returns></returns>
        Task WriteStreamAsync(Stream responseStream, string streamContent);
    }
}