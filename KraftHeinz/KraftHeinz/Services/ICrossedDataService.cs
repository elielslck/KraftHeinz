using Microsoft.EntityFrameworkCore;
using KraftHeinz.Data;
using KraftHeinz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KraftHeinz.Services
{

    public interface ICrossedDataService
    {
        List<CrossedData> GetCrossedData();
    }
}