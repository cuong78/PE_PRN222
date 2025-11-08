using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PantherPetManagement_CuongCla.Repositories.Basic;
using PantherPetManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Repositories
{
    public class PantherProfileRepository : GenericRepository<PantherProfile>
    {
        public PantherProfileRepository() 
        {
        }
        public PantherProfileRepository(DBContext.SU25PantherDBContext context) 
        {
            _context = context;
        }

        // BC là tên entity  bảng chính
        // BCs là tên entity bảng chính thêm chữ s
        // BPC1 là tên entity bảng phụ cấp 1 nằm trong bảng chính
        // BPC2 là tên entity bảng phụ cấp 2 nằm trong bảng phụ cấp 1
        // cái gì liên quan đến _context.   là Tên entity  thêm chữ s

        // IDC là tên khóa chính của bảng chính
        public async Task<List<PantherProfile>> GetAllAsync()
        {
            var items = await _context.PantherProfiles
                .Include(p => p.PantherType)

                //     trường hợp đề cho phân cấp 2  
                //    .ThenInclude(b => b.BPC2)
                // trường hợp đề cho hai phân cấp 1 
                //.Include(p => p.BPC1)
                .ToListAsync();

            return items ?? new List<PantherProfile>();
        }

        public async Task<PantherProfile> GetByIdAsync(int id)
        {
            var items = await _context.PantherProfiles
                  .Include(p => p.PantherType)


                  //     trường hợp đề cho phân cấp 2  
                  //    .ThenInclude(b => b.BPC2)
                  // trường hợp đề cho hai phân cấp 1 
                  //.Include(p => p.BPC1)
                  .FirstOrDefaultAsync(p => p.PantherProfileId == id);
            return items ?? new PantherProfile();
        }


        // v1 là kiểu truyền vào  
        // V1 là tên cột trong bảng  

        public async Task<List<PantherProfile>> SearchAsync(string pantherTypeName, decimal? weight)
        {
            var listItem = await _context.PantherProfiles
                .Include(b => b.PantherType)
                //    .ThenInclude(b => b.)
                //.Include(p => p.)
                .Where(c =>
                (c.Weight == weight || weight == 0 || weight == null)

                // &&  (c..Contains() || string.IsNullOrEmpty())
                && (c.PantherType.PantherTypeName.Contains(pantherTypeName) || string.IsNullOrEmpty(pantherTypeName))  //Ref table: foreign key                

                )                 // thường sẽ chấm cột date để sắp xếp
                .OrderByDescending(c => c.ModifiedDate).ToListAsync();

            return listItem ?? new List<PantherProfile>();
        }

    }
}
