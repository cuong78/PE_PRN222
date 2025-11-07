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

        public IList<ParkingRecord> ParkingRecord { get; set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            var allProfiles = await _context.GetAllAsync();
            allProfiles = allProfiles.OrderByDescending(p => p.CheckInTime).ToList();
            ParkingRecord = allProfiles;
        }

    }

}
