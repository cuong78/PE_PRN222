using LionPetManagement.Repositories.Basic;
using LionPetManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionPetManagement.Repositories
{
    public class LionProfileRepository : GenericRepository<LionProfile>
    {
        public LionProfileRepository() 
        {
        }
        public LionProfileRepository(SU25LionDBContext context) 
        {
            _context = context;
        }

       


        // BC là tên entity  bảng chính
        // BCs là tên entity bảng chính thêm chữ s
        // BPC1 là tên entity bảng phụ cấp 1 nằm trong bảng chính
        // BPC2 là tên entity bảng phụ cấp 2 nằm trong bảng phụ cấp 1
        // cái gì liên quan đến _context.   là Tên entity  thêm chữ s

        // IDC là tên khóa chính của bảng chính
        public async Task<List<LionProfile>> GetAllAsync()
        {
            var items = await _context.LionProfiles
                .Include(p => p.LionType)

                //     trường hợp đề cho phân cấp 2  
                //    .ThenInclude(b => b.BPC2)
                // trường hợp đề cho hai phân cấp 1 
                //.Include(p => p.BPC1)
                .ToListAsync();

            return items ?? new List<LionProfile>();
        }

        public async Task<LionProfile> GetByIdAsync(int id)
        {
            var items = await _context.LionProfiles
                  .Include(p => p.LionType)


                  //     trường hợp đề cho phân cấp 2  
                  //    .ThenInclude(b => b.BPC2)
                  // trường hợp đề cho hai phân cấp 1 
                  //.Include(p => p.BPC1)
                  .FirstOrDefaultAsync(p => p.LionProfileId == id);
            return items ?? new LionProfile();
        }


        // v1 là kiểu truyền vào  
        // V1 là tên cột trong bảng  

        public async Task<List<LionProfile>> SearchAsync(string lionTypeName, float? weight)  //string status)
        {
            var listItem = await _context.LionProfiles
                .Include(b => b.LionType)
                //    .ThenInclude(b => b.)
                //.Include(p => p.)
                .Where(c =>
                (c.Weight == weight || weight == 0 || weight == null)

                // &&  (c..Contains() || string.IsNullOrEmpty())
                && (c.LionType.LionTypeName.Contains(lionTypeName) || string.IsNullOrEmpty(lionTypeName))  //Ref table: foreign key                

                )                 // thường sẽ chấm cột date để sắp xếp
                .OrderByDescending(c => c.ModifiedDate).ToListAsync();

            return listItem ?? new List<LionProfile>();
        }

    }
}
