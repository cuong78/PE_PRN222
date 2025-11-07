using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketparkingManagement_CuongCla.Repositories.Models;

namespace SupermarketparkingManagement_CuongCla.Pages.ParkingRecords
{
    public class DetailsModel : PageModel
    {
        private readonly SupermarketparkingManagement_CuongCla.Repositories.Models.supermarketparkingdbContext _context;

        public DetailsModel(SupermarketparkingManagement_CuongCla.Repositories.Models.supermarketparkingdbContext context)
        {
            _context = context;
        }

        public ParkingRecord ParkingRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingrecord = await _context.ParkingRecords.FirstOrDefaultAsync(m => m.RecordId == id);
            if (parkingrecord == null)
            {
                return NotFound();
            }
            else
            {
                ParkingRecord = parkingrecord;
            }
            return Page();
        }
    }
}
