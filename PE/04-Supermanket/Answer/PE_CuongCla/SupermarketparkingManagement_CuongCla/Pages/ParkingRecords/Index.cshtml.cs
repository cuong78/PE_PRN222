using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketparkingManagement_CuongCla.Repositories.Models;
using SupermarketparkingManagement_CuongCla.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Pages.ParkingRecords
{
    public class IndexModel : PageModel
    {

        private readonly IParkingRecordService _context;

        public IndexModel(IParkingRecordService context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string VehiclePlate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? CheckInTime { get; set; }



        public IList<ParkingRecord> ParkingRecord { get; set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {

            // Lấy tất cả dữ liệu từ backend
            var allProfiles = await _context.GetAllAsync();

         


            if (!string.IsNullOrEmpty(VehiclePlate) || CheckInTime != null)
            {
                allProfiles = await _context.SearchAsync(VehiclePlate, CheckInTime);
                // Sắp xếp lại sau khi search

            }



            ParkingRecord = allProfiles;


        }

    }

}
