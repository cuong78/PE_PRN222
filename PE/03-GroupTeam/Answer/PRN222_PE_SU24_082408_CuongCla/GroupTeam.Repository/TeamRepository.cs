using GroupTeam.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTeam.Repository
{
    public class TeamRepository : GenericRepository<Models.Team>
    {
        public TeamRepository() 
        {
        }

        public TeamRepository(DBContext.Euro2024DBContext context) 
        {
            _context = context;
        }

       
        public async Task<List<Team>> GetAllAsync()
        {
            var items = await _context.Teams
                .Include(p => p.Group)

                .ToListAsync();

            return items ?? new List<Team>();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            var items = await _context.Teams
                  .Include(p => p.Group)
         
                  .FirstOrDefaultAsync(p => p.Id == id);
            return items ?? new Team();
        }


    }
}
