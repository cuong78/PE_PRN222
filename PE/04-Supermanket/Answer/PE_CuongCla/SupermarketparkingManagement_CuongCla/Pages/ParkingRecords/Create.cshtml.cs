using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupermarketparkingManagement_CuongCla.Repositories.Models;

namespace SupermarketparkingManagement_CuongCla.Pages.ParkingRecords
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketparkingManagement_CuongCla.Repositories.Models.supermarketparkingdbContext _context;

        public CreateModel(SupermarketparkingManagement_CuongCla.Repositories.Models.supermarketparkingdbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["VehicleTypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "TypeName");
            return Page();
        }

        [BindProperty]
        public ParkingRecord ParkingRecord { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ParkingRecords.Add(ParkingRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
