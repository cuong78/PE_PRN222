using Medicine_CuongCla.Repositories.DBContext;
using Medicine_CuongCla.Repositories.Models;
using Medicine_CuongCla.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_CuongCla.RazorPage.Pages.MedicineInformations
{
    public class CreateModel : PageModel
    {
        private readonly IMedicineInformationService _medicineInformationService;
        private readonly ManufacturerService _manufacturerService;

        public CreateModel(IMedicineInformationService medicineInformationService,
                           ManufacturerService manufacturerService)
        {
            _medicineInformationService = medicineInformationService;
            _manufacturerService = manufacturerService;
        }

        public async Task<IActionResult> OnGet()
        {
            var Manufacturer = await _manufacturerService.GetAllAsync();

            ViewData["ManufacturerId"] = new SelectList(Manufacturer, "ManufacturerId", "ManufacturerName");
            return Page();
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var manufacturers = await _manufacturerService.GetAllAsync();
                ViewData["ManufacturerId"] = new SelectList(manufacturers, "ManufacturerId", "ManufacturerName");
                return Page();
            }

            try
            {
                await _medicineInformationService.CreateAsync(MedicineInformation);
                
                // Lưu ID của record vừa tạo vào TempData để sắp xếp ở Index
                TempData["NewMedicineId"] = MedicineInformation.MedicineId;
                
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                ModelState.AddModelError(string.Empty, ex.Message);
                
                // Reload lại dropdown Manufacturer
                var manufacturers = await _manufacturerService.GetAllAsync();
                ViewData["ManufacturerId"] = new SelectList(manufacturers, "ManufacturerId", "ManufacturerName");
                
                return Page();
            }
        }
    }
}

