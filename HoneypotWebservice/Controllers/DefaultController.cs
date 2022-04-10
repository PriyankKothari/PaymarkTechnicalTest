using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HoneypotWebservice.Interfaces;

namespace HoneypotWebservice.Controllers
{
    [Route("")]
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        private readonly IStreamContent _streamContent;

        public DefaultController(IStreamContent streamContent)
        {
            this._streamContent = streamContent;
        }

        [Route("")]
        public async Task Index()
        {
            while (true)
            {
                await this._streamContent.GetResponseStream(this.Response.Body, "Not Found");
            }
        }
    }
}