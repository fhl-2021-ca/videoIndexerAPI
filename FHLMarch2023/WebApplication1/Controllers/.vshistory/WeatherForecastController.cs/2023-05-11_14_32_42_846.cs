using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoIndexerArm;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("indexed")]
        public async Task<string> GetAsync(String videoUrl)
        {
            String result = await VideoProgram.indexvideo(videoUrl);
            return result;
        }

        [HttpGet("insights")]
        public async Task<string> GetInsights(string videoId)
        {

            string insights = await VideoProgram.GetInsights(videoId);
            return insights;

        }
    }

}

