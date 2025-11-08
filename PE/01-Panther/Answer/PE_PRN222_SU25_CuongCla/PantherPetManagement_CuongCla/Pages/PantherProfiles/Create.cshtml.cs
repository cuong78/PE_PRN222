using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PantherPetManagement_CuongCla.Repositories.DBContext;
using PantherPetManagement_CuongCla.Repositories.Models;
using PantherPetManagement_CuongCla.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Pages.PantherProfiles
{
    public class CreateModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;
        private readonly PantherTypeService _pantherTypeService;

        public CreateModel(IPantherProfileService pantherProfileService,
                           PantherTypeService pantherTypeService)
        {
            _pantherProfileService = pantherProfileService;
            _pantherTypeService = pantherTypeService;
        }

        public async Task<IActionResult> OnGet()
        {
            // Set ModifiedDate before creating
            PantherProfile = new PantherProfile
            {
                ModifiedDate = DateTime.Now
            };


            var PantherType = await _pantherTypeService.GetAllAsync();

            ViewData["PantherTypeId"] = new SelectList(PantherType, "PantherTypeId", "PantherTypeName");
            return Page();
        }

        [BindProperty]
        public PantherProfile PantherProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload the dropdown list when validation fails
                var PantherType = await _pantherTypeService.GetAllAsync();
                ViewData["PantherTypeId"] = new SelectList(PantherType, "PantherTypeId", "PantherTypeName");
                return Page();
            }     
            
            await _pantherProfileService.CreateAsync(PantherProfile);
            return RedirectToPage("./Index");
        }
    }
}