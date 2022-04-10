using System.Threading.Tasks;

namespace HoneypotWebservice.Interfaces
{
    public interface IStreamContent
    {
        Task GetResponseStream(System.IO.Stream responseStream, string streamContent);
    }
}