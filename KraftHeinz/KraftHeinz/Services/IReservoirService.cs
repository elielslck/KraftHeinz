using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace KraftHeinz.Services
{
    public interface IReservoirService
    {
        Task<List<Reservoir>> GetAllReservoirs();
        Task<Reservoir> GetReservoirById(int id);
        Task<Reservoir> CreateReservoir(Reservoir reservoir);
        Task<Reservoir> UpdateReservoir(int id, Reservoir reservoir);
        Task<bool> DeleteReservoir(int id);
        Task<int> UpdateReservoir(Reservoir reservoir);
        Task DeleteReservoir(Reservoir existingReservoir);
    }
}