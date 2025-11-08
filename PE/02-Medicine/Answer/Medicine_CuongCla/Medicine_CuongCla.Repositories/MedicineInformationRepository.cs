using Medicine_CuongCla.Repositories.Basic;
using Medicine_CuongCla.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_CuongCla.Repositories
{
    public class MedicineInformationRepository : GenericRepository<MedicineInformation>
    {
        public MedicineInformationRepository()
        {
        }
        public MedicineInformationRepository(DBContext.Fall24PharmaceuticalDBContext context) 
        {
            _context = context;
        }

        public async Task<List<MedicineInformation>> GetAllAsync()
        {
            var items = await _context.MedicineInformations
                .Include(p => p.Manufacturer)
                .ToListAsync();

            return items ?? new List<MedicineInformation>();
        }

        public async Task<MedicineInformation> GetByIdAsync(string id)
        {
            var items = await _context.MedicineInformations
                  .Include(p => p.Manufacturer)             
                  .FirstOrDefaultAsync(p => p.MedicineId == id);
            return items ?? new MedicineInformation();
        }

        // Kiểm tra xem MedicineId đã tồn tại chưa
        public async Task<bool> IsMedicineIdExistsAsync(string medicineId)
        {
            return await _context.MedicineInformations
                .AnyAsync(m => m.MedicineId == medicineId);
        }

        public async Task<List<MedicineInformation>> SearchAsync(string activeIngredients, string warningsAndPrecautions, string expirationDate)
        {
            var listItem = await _context.MedicineInformations
                .Include(b => b.Manufacturer)
                .Where(c =>
                    (string.IsNullOrEmpty(activeIngredients) || c.ActiveIngredients.Contains(activeIngredients))               
                    || (string.IsNullOrEmpty(warningsAndPrecautions) || c.WarningsAndPrecautions.Contains(warningsAndPrecautions))
                    || (string.IsNullOrEmpty(expirationDate) || c.ExpirationDate.Contains(expirationDate))
                )
                .ToListAsync();

            return listItem ?? new List<MedicineInformation>();
        }
    }
}
