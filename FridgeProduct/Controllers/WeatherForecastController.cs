using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fridge.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;

        public WeatherForecastController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //_repository.Fridge.AnyMethodFridgeRepository();
            //_repository.Product.AnyMethodProductRepository();
            //_repository.FridgeModel.AnyMethodFridgeModelRepository();
            return new string[] { "value1", "value2" };
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info mesage from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn mesage from our values controller.");
            _logger.LogError("Here is an error mesage from our values controller.");

            return new string[] { "value1", "value2" };
        }*/
    }
}
