using Medicine_CuongCla.Repositories.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_CuongCla.Repositories
{
    public class ManufacturerRepository : GenericRepository<Models.Manufacturer>
    {
        public ManufacturerRepository()
        {
        }
        public ManufacturerRepository(DBContext.Fall24PharmaceuticalDBContext context)
        {
            _context = context;
        }
    }
}
