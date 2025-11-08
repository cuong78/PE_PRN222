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

        public async Task<List<Team>> SearchAsync(string v1, decimal? v2) //string status)
        {
            var listItem = await _context.Teams
                .Include(b => b.Group)
                //    .ThenInclude(b => b.)
                //.Include(p => p.)
                .Where(c =>
                (c.Point == v2 || v2 == 0 || v2 == null)

                // &&  (c..Contains() || string.IsNullOrEmpty())
                && (c.Group.GroupName.Contains(v1) || string.IsNullOrEmpty(v1))  //Ref table: foreign key                

                )                
                .ToListAsync();

            return listItem ?? new List<Team>();
        }

        // Calculate and update positions for all teams in a specific group
        public async Task UpdatePositionsInGroupAsync(int groupId)
        {
            // Create a new context to avoid tracking conflicts
            using (var freshContext = new DBContext.Euro2024DBContext())
            {
                // Get all teams in the group, ordered by Point descending
                var teamsInGroup = await freshContext.Teams
                    .Where(t => t.GroupId == groupId)
                    .OrderByDescending(t => t.Point)
                    .ThenBy(t => t.TeamName) // Tie-breaker: alphabetical order
                    .AsNoTracking() // Don't track initially
                    .ToListAsync();

                // Assign positions (1, 2, 3, ...)
                int position = 1;
                foreach (var team in teamsInGroup)
                {
                    team.Position = position++;
                    
                    // Attach and mark only Position property as modified
                    freshContext.Teams.Attach(team);
                    freshContext.Entry(team).Property(t => t.Position).IsModified = true;
                }

                await freshContext.SaveChangesAsync();
            }
        }

        // Get current point value before adding new points
        public async Task<int> GetCurrentPointAsync(int teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            return team?.Point ?? 0;
        }


    }
}
