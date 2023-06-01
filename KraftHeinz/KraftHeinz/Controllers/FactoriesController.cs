using Microsoft.AspNetCore.Mvc;
using KraftHeinz.Models;
using KraftHeinz.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KraftHeinz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        private readonly IFactoryService _factoryService;

        public FactoriesController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Factory>>> GetAllFactories()
        {
            return await _factoryService.GetAllFactories();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Factory>> GetFactoryById(int id)
        {
            var factory = await _factoryService.GetFactoryById(id);
            if (factory == null)
            {
                return NotFound();
            }
            return factory;
        }

        [HttpPost]
        public async Task<ActionResult<Factory>> CreateFactory(Factory factory)
        {
            var newFactory = await _factoryService.CreateFactory(factory);
            return CreatedAtAction(nameof(GetFactoryById), new { id = newFactory.Id }, newFactory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFactory(int id, Factory factory)
        {
            var existingFactory = await _factoryService.GetFactoryById(id);
            if (existingFactory == null)
            {
                return NotFound();
            }

            existingFactory.Name = factory.Name;
            existingFactory.Region = factory.Region;

            await _factoryService.UpdateFactory(existingFactory);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactory(int id)
        {
            var existingFactory = await _factoryService.GetFactoryById(id);
            if (existingFactory == null)
            {
                return NotFound();
            }

            await _factoryService.DeleteFactory(existingFactory);

            return NoContent();
        }
    }
}