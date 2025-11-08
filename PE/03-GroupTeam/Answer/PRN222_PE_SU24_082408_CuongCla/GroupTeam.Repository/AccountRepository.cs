using GroupTeam.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTeam.Repository
{
    public class AccountRepository : GenericRepository<Models.Account>
    {
        public AccountRepository()
        {
        }
        public AccountRepository(DBContext.Euro2024DBContext context)
        {
            _context = context;
        }

        //AC là tên entity  bảng account
        //ACs là tên entity bảng account thêm chữ s
        public async Task<Account> GetAccount(String userName, String password)
        {

            return await _context.Accounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        }

    }
}
