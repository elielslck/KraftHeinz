using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KraftHeinz.Services
{
    public interface IPowerPlantService
    {
        Task<List<PowerPlant>> GetAllPowerPlants();
        Task<PowerPlant> GetPowerPlantById(int id);
        Task<PowerPlant> CreatePowerPlant(PowerPlant powerPlant);
        Task<PowerPlant> UpdatePowerPlant(int id, PowerPlant powerPlant);
        Task<bool> DeletePowerPlant(int id);
        Task<int> UpdatePowerPlant(PowerPlant powerPlant);
        Task DeletePowerPlant(PowerPlant existingPowerPlant);
    }
}