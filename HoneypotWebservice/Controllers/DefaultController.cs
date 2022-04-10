using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        /// <param name="dictionary">Dictionary of parameters</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        /// <response code = "200">Returns Ok</response>
        /// <response code = "400">Returns BadRequest</response>
        /// <response code = "500">Returns InternalServerError</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("/{dictionary?}")]
        public async Task<IActionResult> Index([FromQuery] IDictionary<string, string> dictionary, CancellationToken cancellationToken)
        {
            try
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    while (true)
                    {
                        await this._streamContent.WriteStreamAsync(this.Response.Body, "Not Found", cancellationToken);
                    }
                }
                return Ok();
            }    
            catch(Exception exception)
            {
                // log exception
                if (exception.GetType().Equals(typeof(OperationCanceledException)))
                    return BadRequest();
                else
                    return Problem(detail: exception.StackTrace, title: exception.Message);
            }            
        }
    }
}