using Microsoft.EntityFrameworkCore;
using KraftHeinz.Data;
using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace KraftHeinz.Services
{
    public class FactoryService : IFactoryService
    {
        private readonly OracleDbContext _context;

        public FactoryService(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Factory>> GetAllFactories()
        {
            return await _context.Factories.ToListAsync();
        }

        public async Task<Factory> GetFactoryById(int id)
        {
            return await _context.Factories.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Factory> CreateFactory(Factory factory)
        {
            _context.Factories.Add(factory);
            await _context.SaveChangesAsync();
            return factory;
        }

        public async Task<Factory> UpdateFactory(int id, Factory factory)
        {
            var existingFactory = await _context.Factories.FirstOrDefaultAsync(f => f.Id == id);
            if (existingFactory != null)
            {
                existingFactory.Name = factory.Name;
                existingFactory.Region = factory.Region;
                // outras propriedades

                await _context.SaveChangesAsync();
            }
            return existingFactory;
        }

        public async Task<bool> DeleteFactory(int id)
        {
            var existingFactory = await _context.Factories.FirstOrDefaultAsync(f => f.Id == id);
            if (existingFactory != null)
            {
                _context.Factories.Remove(existingFactory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<int> UpdateFactory(Factory factory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFactory(Factory existingFactory)
        {
            throw new NotImplementedException();
        }
    }
}