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
    public class DeleteModel : PageModel
    {
        private readonly SupermarketparkingManagement_CuongCla.Repositories.Models.supermarketparkingdbContext _context;

        public DeleteModel(SupermarketparkingManagement_CuongCla.Repositories.Models.supermarketparkingdbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingrecord = await _context.ParkingRecords.FindAsync(id);
            if (parkingrecord != null)
            {
                ParkingRecord = parkingrecord;
                _context.ParkingRecords.Remove(ParkingRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
