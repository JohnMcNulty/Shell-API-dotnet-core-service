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
                IgnoreNullValues = true // removing nulls from response
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

        [HttpGet]
        [Route("GetShellDataGroupedByMeter")]
        public string GetShellDataByMeter(string meterCode)
        {
            var data = _recordsService.GetDataByMeter();
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);

            return json;
        }

        [HttpGet]
        [Route("GetShellDataGroupedByDate")]
        public string GetShellDataByDate(string meterCode)
        {
            var data = _recordsService.GetDataByDate();
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);

            return json;
        }

        [HttpGet]
        [Route("GetShellDataGroupedByDataType")]
        public string GetShellDataByDataType(string meterCode)
        {
            var data = _recordsService.GetDataByDataType();
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);

            return json;
        }
    }
}
