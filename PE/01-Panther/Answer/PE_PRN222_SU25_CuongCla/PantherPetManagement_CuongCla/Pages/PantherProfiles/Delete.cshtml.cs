using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PantherPetManagement_CuongCla.Repositories.Models;
using PantherPetManagement_CuongCla.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PantherPetManagement_CuongCla.Pages.PantherProfiles
{
    public class DeleteModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;
        private readonly PantherTypeService _pantherTypeService;

        public DeleteModel(IPantherProfileService pantherProfileService,
                           PantherTypeService pantherTypeService)
        {
            _pantherProfileService = pantherProfileService;
            _pantherTypeService = pantherTypeService;
        }

        [BindProperty]
        public PantherProfile PantherProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherProfile = await _pantherProfileService.GetByIdAsync(id.Value);

            var pantherTypes = await _pantherTypeService.GetAllAsync();

            pantherProfile.PantherType = pantherTypes.FirstOrDefault(l => l.PantherTypeId == pantherProfile.PantherTypeId);

            if (pantherProfile == null)
            {
                return NotFound();
            }
            else
            {
                PantherProfile = pantherProfile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _pantherProfileService.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }

}