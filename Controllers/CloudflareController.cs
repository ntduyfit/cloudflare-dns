using System.Threading.Tasks;
using cloudflare_client.DTOs;
using cloudflare_client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace cloudflare_client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CloudflareController : ControllerBase
    {
        private readonly ICloudflareService _cloudflareService;


        private readonly ILogger<CloudflareController> _logger;

        public CloudflareController(ILogger<CloudflareController> logger, ICloudflareService cloudflareService)
        {
            _cloudflareService = cloudflareService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDnRecord([FromBody] Payload body)
        {
            var result = await _cloudflareService.AddDnsRecord(body.name);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}