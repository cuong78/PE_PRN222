using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medicine_CuongCla.Repositories.DBContext;
using Medicine_CuongCla.Repositories.Models;

namespace Medicine_CuongCla.RazorPage.Pages.MedicineInformations
{
    public class DetailsModel : PageModel
    {
        private readonly Medicine_CuongCla.Repositories.DBContext.Fall24PharmaceuticalDBContext _context;

        public DetailsModel(Medicine_CuongCla.Repositories.DBContext.Fall24PharmaceuticalDBContext context)
        {
            _context = context;
        }

        public MedicineInformation MedicineInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineinformation = await _context.MedicineInformations.FirstOrDefaultAsync(m => m.MedicineId == id);
            if (medicineinformation == null)
            {
                return NotFound();
            }
            else
            {
                MedicineInformation = medicineinformation;
            }
            return Page();
        }
    }
}
