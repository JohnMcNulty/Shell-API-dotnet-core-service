using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ShellApiService.Interfaces;

namespace ShellApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class EnergyRecordsController : ControllerBase
    {

        private readonly ISanitizedEnergyRecordsService _recordsService;
        JsonSerializerOptions jsonSerializerOptions;

        public EnergyRecordsController(ISanitizedEnergyRecordsService recordsService)
        {
            this._recordsService = recordsService;

            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        [HttpGet]
        [Route("GetShellData")]
        public string GetShellData()
        {
            var data = _recordsService.GetSanitizedData();
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);

            return json;
        }


    }
}
