using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement_CuongCla.Repositories.DBContext;
using PantherPetManagement_CuongCla.Repositories.Models;
using PantherPetManagement_CuongCla.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Pages.PantherProfiles
{
    public class EditModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;
        private readonly PantherTypeService _pantherTypeService;

        public EditModel(IPantherProfileService pantherProfileService,
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

            if (pantherProfile == null)
            {
                return NotFound();
            }

            var lionTypes = await _pantherTypeService.GetAllAsync();

            PantherProfile = pantherProfile;

            ViewData["PantherTypeId"] = new SelectList(lionTypes, "PantherTypeId", "PantherTypeName");

            pantherProfile.PantherType = lionTypes.FirstOrDefault(lt => lt.PantherTypeId == pantherProfile.PantherTypeId);

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
            try
            {
                await _pantherProfileService.UpdateAsync(PantherProfile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + '/' + ex.StackTrace);
            }

            return RedirectToPage("./Index");
        }

    }


}