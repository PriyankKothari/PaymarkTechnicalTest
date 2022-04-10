using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HoneypotWebservice.Interfaces;

namespace HoneypotWebservice.Controllers
{
    /// <summary>
    /// Default Controller
    /// </summary>
    [Route("")]
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        private readonly IStreamContent _streamContent;

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="streamContent"></param>
        public DefaultController(IStreamContent streamContent)
        {
            this._streamContent = streamContent;
        }

        /// <summary>
        /// Index action
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task Index()
        {
            while (true)
            {
                await this._streamContent.WriteStreamAsync(this.Response.Body, "Not Found");
            }
        }
    }
}