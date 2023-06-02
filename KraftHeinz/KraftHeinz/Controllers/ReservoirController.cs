using Microsoft.AspNetCore.Mvc;
using KraftHeinz.Models;
using KraftHeinz.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KraftHeinz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservoirController : ControllerBase
    {
        private readonly IReservoirService _reservoirService;

        public ReservoirController(IReservoirService reservoirService)
        {
            _reservoirService = reservoirService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reservoir>>> GetAllReservoirs()
        {
            return await _reservoirService.GetAllReservoirs();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservoir>> GetReservoirById(int id)
        {
            var Reservoir = await _reservoirService.GetReservoirById(id);
            if (Reservoir == null)
            {
                return NotFound();
            }
            return Reservoir;
        }

        [HttpPost]
        public async Task<ActionResult<Reservoir>> CreateReservoir(Reservoir reservoir)
        {
            var newReservoir = await _reservoirService.CreateReservoir(reservoir);
            return CreatedAtAction(nameof(GetReservoirById), new { id = newReservoir.Id }, newReservoir);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservoir(int id, Reservoir reservoir)
        {
            var existingReservoir = await _reservoirService.GetReservoirById(id);
            if (existingReservoir == null)
            {
                return NotFound();
            }

            existingReservoir.Name = reservoir.Name;
            existingReservoir.Region = reservoir.Region;

            await _reservoirService.UpdateReservoir(existingReservoir);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservoir(int id)
        {
            var existingReservoir = await _reservoirService.GetReservoirById(id);
            if (existingReservoir == null)
            {
                return NotFound();
            }

            await _reservoirService.DeleteReservoir(existingReservoir);

            return NoContent();
        }
    }
}