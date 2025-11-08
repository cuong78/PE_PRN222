using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTeam.Repository
{
    public class GroupTeamRepository : GenericRepository<Models.GroupTeam>
    {
        public GroupTeamRepository()
        {
        }
        public GroupTeamRepository(DBContext.Euro2024DBContext context)
        {
            _context = context;
        }

    }
}
