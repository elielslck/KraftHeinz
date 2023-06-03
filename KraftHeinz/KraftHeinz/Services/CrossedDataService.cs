using Microsoft.EntityFrameworkCore;
using KraftHeinz.Data;
using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace KraftHeinz.Services
{

    public class CrossedDataService : ICrossedDataService
    {
        private readonly OracleDbContext _context;

        public CrossedDataService(OracleDbContext context)
        {
            _context = context;
        }

        public List<CrossedData> GetCrossedData()
        {
            List<CrossedData> crossedData = new List<CrossedData>();

            List<Factory> factories = _context.Factories.ToList();
            foreach (var factory in factories)
            {
                List<PowerPlant> powerPlants = _context.PowerPlants.Where(p => p.FactoryId == factory.Id).ToList();
                foreach (var powerPlant in powerPlants)
                {
                    Reservoir reservoir = _context.Reservoirs.FirstOrDefault(r => r.PowerPlantId == powerPlant.Id);

                    CrossedData data = new CrossedData
                    {
                        Factory = factory,
                        PowerPlant = powerPlant,
                        Reservoir = reservoir
                    };

                    crossedData.Add(data);
                }
            }

            return crossedData;
        }
    }
}