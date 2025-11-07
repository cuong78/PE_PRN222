using SupermarketparkingManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Service
{
    public interface IParkingRecordService
    {

        Task<List<ParkingRecord>> GetAllAsync();

        Task<ParkingRecord> GetByIdAsync(int id);

        Task<List<ParkingRecord>> SearchAsync(string vehiclePlate, DateTime? checkInTime);

        Task<int> CreateAsync(ParkingRecord parkingRecord);

        Task<int> UpdateAsync(ParkingRecord parkingRecord);

        Task<bool> DeleteAsync(int id);


    }
}
