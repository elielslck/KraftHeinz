using Microsoft.EntityFrameworkCore;
using KraftHeinz.Data;
using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace KraftHeinz.Services
{
    public class ReservoirService : IReservoirService
    {
        private readonly OracleDbContext _context;

        public ReservoirService(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservoir>> GetAllReservoirs()
        {
            return await _context.Reservoirs.ToListAsync();
        }

        public async Task<Reservoir> GetReservoirById(int id)
        {
            return await _context.Reservoirs.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Reservoir> CreateReservoir(Reservoir reservoir)
        {
            _context.Reservoirs.Add(reservoir);
            await _context.SaveChangesAsync();
            return reservoir;
        }

        public async Task<Reservoir> UpdateReservoir(int id, Reservoir reservoir)
        {
            var existingReservoir = await _context.Reservoirs.FirstOrDefaultAsync(f => f.Id == id);
            if (existingReservoir != null)
            {
                existingReservoir.Name = reservoir.Name;
                existingReservoir.Region = reservoir.Region;
                // outras propriedades

                await _context.SaveChangesAsync();
            }
            return existingReservoir;
        }

        public async Task<bool> DeleteReservoir(int id)
        {
            var existingReservoir = await _context.Reservoirs.FirstOrDefaultAsync(f => f.Id == id);
            if (existingReservoir != null)
            {
                _context.Reservoirs.Remove(existingReservoir);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<int> UpdateReservoir(Reservoir reservoir)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReservoir(Reservoir existingReservoir)
        {
            throw new NotImplementedException();
        }


    }
}