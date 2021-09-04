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
        [Route("GetShellDataByMeter")]
        public string GetShellDataByMeter()
        {
            var data = _recordsService.GetSanitizedData();
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);

            return json;
        }

        [HttpGet]
        [Route("GetShellDataByDate")]
        public string GetShellDataByDate()
        {
            var data = _recordsService.GetSanitizedData(); //TODO : ByDate
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);

            return json;
        }

        [HttpGet]
        [Route("GetShellDataByDataType")]
        public string GetShellDataByDataType()
        {
            var data = _recordsService.GetSanitizedData(); //TODO : ByDataType
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);

            return json;
        }

    }
}
