using Microsoft.EntityFrameworkCore;
using KraftHeinz.Data;
using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace KraftHeinz.Services
{
    public class PowerPlantService : IPowerPlantService
    {
        private readonly OracleDbContext _context;

        public PowerPlantService(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<PowerPlant>> GetAllPowerPlants()
        {
            return await _context.PowerPlants.ToListAsync();
        }

        public async Task<PowerPlant> GetPowerPlantById(int id)
        {
            return await _context.PowerPlants.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<PowerPlant> CreatePowerPlant(PowerPlant powerPlant)
        {
            _context.PowerPlants.Add(powerPlant);
            await _context.SaveChangesAsync();
            return powerPlant;
        }

        public async Task<PowerPlant> UpdatePowerPlant(int id, PowerPlant powerPlant)
        {
            var existingPowerPlant = await _context.PowerPlants.FirstOrDefaultAsync(f => f.Id == id);
            if (existingPowerPlant != null)
            {
                existingPowerPlant.Name = powerPlant.Name;
                existingPowerPlant.Region = powerPlant.Region;
                // outras propriedades

                await _context.SaveChangesAsync();
            }
            return existingPowerPlant;
        }

        public async Task<bool> DeletePowerPlant(int id)
        {
            var existingPowerPlant = await _context.PowerPlants.FirstOrDefaultAsync(f => f.Id == id);
            if (existingPowerPlant != null)
            {
                _context.PowerPlants.Remove(existingPowerPlant);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<int> UpdatePowerPlant(PowerPlant powerPlant)
        {
            throw new NotImplementedException();
        }

        public Task DeletePowerPlant(PowerPlant existingPowerPlant)
        {
            throw new NotImplementedException();
        }

    }

}