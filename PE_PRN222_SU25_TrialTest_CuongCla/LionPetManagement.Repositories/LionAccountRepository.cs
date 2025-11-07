using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionPetManagement.Repositories.Basic;
using LionPetManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;


namespace LionPetManagement.Repositories
{
    public class LionAccountRepository : GenericRepository<LionAccount>
    {
        public LionAccountRepository() { }
        public LionAccountRepository(SU25LionDBContext context)
        {
            _context = context;
        }

        public async Task<LionAccount> GetAccount(String userName, String password)
        {                                                                                                                         // nếu đề yêu cầu có isActive         
                                                                                                                                  //   return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password &&  u.IsActive == true);
                                                                                                                                  //   return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Phone == userName && u.Password == password );
            return await _context.LionAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password);
        }


    }
}
