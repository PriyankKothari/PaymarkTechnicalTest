using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HoneypotWebservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
            var outputStream = this.Response.Body;
            while(true)
            {
                await Task.Delay(5000);
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes("not found" + Environment.NewLine);
                await outputStream.WriteAsync(bytes);
                await outputStream.FlushAsync();
            }
        }
    }
}