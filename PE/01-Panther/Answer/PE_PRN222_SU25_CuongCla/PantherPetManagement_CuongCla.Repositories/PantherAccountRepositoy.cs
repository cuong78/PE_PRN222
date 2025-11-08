using Microsoft.EntityFrameworkCore;
using PantherPetManagement_CuongCla.Repositories.Basic;
using PantherPetManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Repositories
{
    public class PantherAccountRepositoy : GenericRepository<PantherAccount>
    {
        public PantherAccountRepositoy()
        {
        }
        public PantherAccountRepositoy(DBContext.SU25PantherDBContext context)
        {
            _context = context;
        }
        //AC là tên entity  bảng account
        //ACs là tên entity bảng account thêm chữ s
        public async Task<PantherAccount> GetAccount(String email, String password)
        {

            return await _context.PantherAccounts.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

    }
}
