using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KraftHeinz.Services
{
    public interface IReservoirService
    {
        Task<List<Factory>> GetAllFactories();
        Task<Factory> GetFactoryById(int id);
        Task<Factory> CreateFactory(Factory factory);
        Task<Factory> UpdateFactory(int id, Factory factory);
        Task<bool> DeleteFactory(int id);
    }
}