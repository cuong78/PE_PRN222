using Medicine_CuongCla.Repositories.Basic;
using Medicine_CuongCla.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_CuongCla.Repositories
{
    public class StoreAccountRepository : GenericRepository<Models.StoreAccount>
    {
       
        public async Task<StoreAccount> GetAccount(String userName, String password)
        {

            return await _context.StoreAccounts.FirstOrDefaultAsync(u => u.EmailAddress == userName && u.StoreAccountPassword == password);
        }

    }
}
