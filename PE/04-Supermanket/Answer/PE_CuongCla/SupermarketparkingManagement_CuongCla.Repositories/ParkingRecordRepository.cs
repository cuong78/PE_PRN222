using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SupermarketparkingManagement_CuongCla.Repositories.Basic;
using SupermarketparkingManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Repositories
{
    public class ParkingRecordRepository : GenericRepository<ParkingRecord>
    {
        public ParkingRecordRepository() 
        {
        }
        public ParkingRecordRepository(supermarketparkingdbContext context) 
        {
            _context = context;
        }
        // BC là tên entity  bảng chính
        // BCs là tên entity bảng chính thêm chữ s
        // BPC1 là tên entity bảng phụ cấp 1 nằm trong bảng chính
        // BPC2 là tên entity bảng phụ cấp 2 nằm trong bảng phụ cấp 1
        // cái gì liên quan đến _context.   là Tên entity  thêm chữ s

        // IDC là tên khóa chính của bảng chính
        public async Task<List<ParkingRecord>> GetAllAsync()
        {
            var items = await _context.ParkingRecords
                .Include(p => p.VehicleType)
                .ToListAsync();
            
            // Đảo ngược danh sách để record mới nhất (ID lớn) lên đầu
            items.Reverse();

            return items ?? new List<ParkingRecord>();
        }

        public async Task<ParkingRecord> GetByIdAsync(int id)
        {
            var items = await _context.ParkingRecords
                  .Include(p => p.VehicleType)


                  //     trường hợp đề cho phân cấp 2  
                  //    .ThenInclude(b => b.BPC2)
                  // trường hợp đề cho hai phân cấp 1 
                  //.Include(p => p.BPC1)
                  .FirstOrDefaultAsync(p => p.RecordId == id);
            return items ?? new ParkingRecord();
        }

        public async Task<List<ParkingRecord>> SearchAsync(string vehiclePlate, DateTime? checkInTime) 
        {
            var query = _context.ParkingRecords
                 .Include(b => b.VehicleType)
                 .AsQueryable();

            // Apply vehicle plate filter if provided
            if (!string.IsNullOrEmpty(vehiclePlate))
            {
                query = query.Where(c => c.VehiclePlate.Contains(vehiclePlate));
            }

            // Apply check-in time filter if provided
            if (checkInTime.HasValue)
            {
                var searchDate = checkInTime.Value.Date;
                query = query.Where(c => c.CheckInTime.Date == searchDate);
            }

            var listItem = await query.ToListAsync();

            return listItem ?? new List<ParkingRecord>();

        }



    }
}
