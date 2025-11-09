using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupermarketparkingManagement_CuongCla.Repositories.Models;
using SupermarketparkingManagement_CuongCla.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Pages.ParkingRecords
{
    public class CreateModel : PageModel
    {
        private readonly IParkingRecordService _parkingRecordService;
        private readonly VehicleTypeService _vehicleTypeService;

        public CreateModel(IParkingRecordService context)
        {
            _parkingRecordService = context;
            _vehicleTypeService = new VehicleTypeService();
        }

        public async Task<IActionResult> OnGet()
        {
            var vehicleTypes = await _vehicleTypeService.GetAllAsync();

            ViewData["VehicleTypeId"] = new SelectList(vehicleTypes, "VehicleTypeId", "TypeName");
            return Page();
        }

        [BindProperty]
        public ParkingRecord ParkingRecord { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload dropdown data when validation fails
                var vehicleTypes = await _vehicleTypeService.GetAllAsync();
                ViewData["VehicleTypeId"] = new SelectList(vehicleTypes, "VehicleTypeId", "TypeName");
                return Page();
            }

            await _parkingRecordService.CreateAsync(ParkingRecord);
            return RedirectToPage("./Index");
        }
    }
}