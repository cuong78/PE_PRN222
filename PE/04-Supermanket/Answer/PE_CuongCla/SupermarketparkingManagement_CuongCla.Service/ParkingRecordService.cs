using SupermarketparkingManagement_CuongCla.Repositories;
using SupermarketparkingManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Service
{
    public class ParkingRecordService : IParkingRecordService
    {


       

        private readonly ParkingRecordRepository _repository;
        public ParkingRecordService() => _repository = new ParkingRecordRepository();


        public async Task<int> CreateAsync(ParkingRecord parkingRecord)
        {
            try
            {
                return await _repository.CreateAsync(parkingRecord);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item != null)
                {
                    return await _repository.RemoveAsync(item);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
        }

        public async Task<List<ParkingRecord>> GetAllAsync()
        {
            try
            {
                ////Business rules here
                var items = await _repository.GetAllAsync();
                return items;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new List<ParkingRecord>();
        }

        public async Task<ParkingRecord> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                return item;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return null;
        }

        public async Task<List<ParkingRecord>> SearchAsync(string vehiclePlate, DateTime? checkInTime)
        {
            try
            {
                var items = await _repository.SearchAsync(vehiclePlate, checkInTime);
                return items;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new List<ParkingRecord>();
        }

        public async Task<int> UpdateAsync(ParkingRecord parkingRecord)
        {
            try
            {
                return await _repository.UpdateAsync(parkingRecord);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return 0;
        }


    }
}
