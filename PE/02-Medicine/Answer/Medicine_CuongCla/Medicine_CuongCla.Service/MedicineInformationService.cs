using Medicine_CuongCla.Repositories;
using Medicine_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_CuongCla.Service
{
    public class MedicineInformationService : IMedicineInformationService
    {
        
        private readonly MedicineInformationRepository _repository;
        public MedicineInformationService() => _repository = new MedicineInformationRepository();


        public async Task<int> CreateAsync(MedicineInformation medicineInformation)
        {
            try
            {
                // Kiểm tra xem MedicineId đã tồn tại chưa
                var exists = await _repository.IsMedicineIdExistsAsync(medicineInformation.MedicineId);
                if (exists)
                {
                    throw new Exception($"Medicine ID '{medicineInformation.MedicineId}' already exists. Please use a different ID.");
                }

                return await _repository.CreateAsync(medicineInformation);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(string id)
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

        public async Task<List<MedicineInformation>> GetAllAsync()
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
            return new List<MedicineInformation>();
        }

        public async Task<MedicineInformation> GetByIdAsync(string id)
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

        public async Task<List<MedicineInformation>> SearchAsync(string activeIngredients, string warningsAndPrecautions, string expirationDate)
        {
            try
            {
                var items = await _repository.SearchAsync(activeIngredients, warningsAndPrecautions, expirationDate);
                return items;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new List<MedicineInformation>();
        }

        public async Task<int> UpdateAsync(MedicineInformation medicineInformation)
        {
            try
            {
                return await _repository.UpdateAsync(medicineInformation);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return 0;
        }

    }
}
