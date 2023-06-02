using Microsoft.AspNetCore.Mvc;
using KraftHeinz.Models;
using KraftHeinz.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KraftHeinz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerPlantController : ControllerBase
    {
        private readonly IPowerPlantService _powerplantService;

        public PowerPlantController(IPowerPlantService powerplantService)
        {
            _powerplantService = powerplantService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PowerPlant>>> GetAllPowerPlants()
        {
            return await _powerplantService.GetAllPowerPlants();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PowerPlant>> GetPowerPlantById(int id)
        {
            var PowerPlant = await _powerplantService.GetPowerPlantById(id);
            if (PowerPlant == null)
            {
                return NotFound();
            }
            return PowerPlant;
        }

        [HttpPost]
        public async Task<ActionResult<PowerPlant>> CreatePowerPlant(PowerPlant PowerPlant)
        {
            var newPowerPlant = await _powerplantService.CreatePowerPlant(PowerPlant);
            return CreatedAtAction(nameof(GetPowerPlantById), new { id = newPowerPlant.Id }, newPowerPlant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePowerPlant(int id, PowerPlant PowerPlant)
        {
            var existingPowerPlant = await _powerplantService.GetPowerPlantById(id);
            if (existingPowerPlant == null)
            {
                return NotFound();
            }

            existingPowerPlant.Name = PowerPlant.Name;
            existingPowerPlant.Region = PowerPlant.Region;

            await _powerplantService.UpdatePowerPlant(existingPowerPlant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePowerPlant(int id)
        {
            var existingPowerPlant = await _powerplantService.GetPowerPlantById(id);
            if (existingPowerPlant == null)
            {
                return NotFound();
            }

            await _powerplantService.DeletePowerPlant(existingPowerPlant);

            return NoContent();
        }
    }
}