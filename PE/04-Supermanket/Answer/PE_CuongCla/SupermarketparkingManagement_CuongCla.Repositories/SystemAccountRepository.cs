using Microsoft.EntityFrameworkCore;
using SupermarketparkingManagement_CuongCla.Repositories.Basic;
using SupermarketparkingManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Repositories
{
    public class SystemAccountRepository : GenericRepository<SystemAccount>
    {
        public SystemAccountRepository()
        {
        }
        public SystemAccountRepository(supermarketparkingdbContext context)
        {
            _context = context;
        }


        public async Task<SystemAccount> GetAccount(String userName, String password)
        {

            return await _context.SystemAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password);
        }

    }
}
