using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ShellApiService;
using ShellApiService.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShellApi.Controllers
{

    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class EnergyRecordsController : Controller
    {
        
        private readonly ISanitizedEnergyRecordsService _recordsService;

        public EnergyRecordsController(ISanitizedEnergyRecordsService recordsService)
        {
            this._recordsService = recordsService;
        }

        [HttpGet]
        [Route("GetShellDataByMeter")]
        public JsonResult GetShellDataByMeter()
        {
            var records = _recordsService.GetDataByMeter();

            return Json(records);
        }
    }
}
