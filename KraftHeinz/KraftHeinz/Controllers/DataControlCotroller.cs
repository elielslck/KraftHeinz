using Microsoft.AspNetCore.Mvc;
using KraftHeinz.Models;
using KraftHeinz.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KraftHeinz.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CrossedDataController : ControllerBase
    {
        private readonly ICrossedDataService _crossedDataService;

        public CrossedDataController(ICrossedDataService crossedDataService)
        {
            _crossedDataService = crossedDataService;
        }

        [HttpGet]
        public ActionResult<List<CrossedData>> GetCrossedData()
        {
            List<CrossedData> crossedData = _crossedDataService.GetCrossedData();
            return Ok(crossedData);
        }
    }
}