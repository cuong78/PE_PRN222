using LionPetManagement.Repositories.Basic;
using LionPetManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionPetManagement.Repositories
{
    public class LionTypeRepository : GenericRepository<LionType>
    {
        public LionTypeRepository()
        {
        }
        public LionTypeRepository(SU25LionDBContext context)
        {
            _context = context;
        }
    }
}
