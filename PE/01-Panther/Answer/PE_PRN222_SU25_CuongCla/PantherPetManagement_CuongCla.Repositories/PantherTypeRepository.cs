using PantherPetManagement_CuongCla.Repositories.Basic;
using PantherPetManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Repositories
{
    public class PantherTypeRepository : GenericRepository<PantherType>
    {
        public PantherTypeRepository()
        {
        }
        public PantherTypeRepository(DBContext.SU25PantherDBContext context)
        {
            _context = context;
        }

    }
}
