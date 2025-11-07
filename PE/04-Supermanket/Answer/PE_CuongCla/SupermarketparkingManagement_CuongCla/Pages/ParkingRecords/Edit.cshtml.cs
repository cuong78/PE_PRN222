using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupermarketparkingManagement_CuongCla.Repositories.Models;

namespace SupermarketparkingManagement_CuongCla.Pages.ParkingRecords
{
    public class EditModel : PageModel
    {
        private readonly SupermarketparkingManagement_CuongCla.Repositories.Models.supermarketparkingdbContext _context;

        public EditModel(SupermarketparkingManagement_CuongCla.Repositories.Models.supermarketparkingdbContext context)
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

            var parkingrecord =  await _context.ParkingRecords.FirstOrDefaultAsync(m => m.RecordId == id);
            if (parkingrecord == null)
            {
                return NotFound();
            }
            ParkingRecord = parkingrecord;
           ViewData["VehicleTypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "TypeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ParkingRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingRecordExists(ParkingRecord.RecordId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ParkingRecordExists(int id)
        {
            return _context.ParkingRecords.Any(e => e.RecordId == id);
        }
    }
}
