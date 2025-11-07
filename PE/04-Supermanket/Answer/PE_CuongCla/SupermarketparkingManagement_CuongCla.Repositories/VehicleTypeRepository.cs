using SupermarketparkingManagement_CuongCla.Repositories.Basic;
using SupermarketparkingManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Repositories
{
    public class VehicleTypeRepository : GenericRepository<VehicleType>
    {
        public VehicleTypeRepository()
        {
        }
        public VehicleTypeRepository(supermarketparkingdbContext context)
        {
            _context = context;
        }
    }
}
