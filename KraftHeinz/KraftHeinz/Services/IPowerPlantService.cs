using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KraftHeinz.Services
{
    public interface IPowerPlantService
    {
        Task<List<PowerPlant>> GetAllFactories();
        Task<PowerPlant> GetFactoryById(int id);
        Task<PowerPlant> CreateFactory(PowerPlant factory);
        Task<PowerPlant> UpdateFactory(int id, PowerPlant factory);
        Task<bool> DeleteFactory(int id);
    }
}