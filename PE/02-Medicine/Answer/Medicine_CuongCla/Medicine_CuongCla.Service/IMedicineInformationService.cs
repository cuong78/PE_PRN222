using Medicine_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_CuongCla.Service
{
    public interface IMedicineInformationService
    {
        Task<List<MedicineInformation>> GetAllAsync();

        Task<MedicineInformation> GetByIdAsync(string id);

        Task<List<MedicineInformation>> SearchAsync (string activeIngredients, string warningsAndPrecautions, string expirationDate);

        Task<int> CreateAsync(MedicineInformation medicineInformation);

        Task<int> UpdateAsync(MedicineInformation medicineInformation);

        Task<bool> DeleteAsync(string id);


    }
}
