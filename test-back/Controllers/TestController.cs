using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestBack.BL.Services.Abstraction;
using TestBack.Models;

namespace TestBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IWorkerService _serviceWorker;
        private readonly ILogger _logger;

        public TestController(IWorkerService serviceWorker, ILogger logger)
        {
            _serviceWorker = serviceWorker ?? throw new ArgumentNullException(nameof(serviceWorker));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectModel data)
        {
            if (data == null)
                return BadRequest();

            await _logger.Log("Request is running");
            var results =  await _serviceWorker.RunProcess(data.Projects);

           return Ok(results);
        }
    }
}
