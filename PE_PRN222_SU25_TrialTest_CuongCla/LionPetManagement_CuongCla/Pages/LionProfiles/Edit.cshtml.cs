using LionPetManagement.Repositories.Models;
using LionPetManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LionPetManagement_CuongCla.Pages.LionProfiles
{
    [Authorize(Roles = "2")]
    public class EditModel : PageModel
    {
        private readonly ILionProfileService _lionProfileService;
        private readonly LionTypeService _lionTypeService;

        public EditModel(ILionProfileService context)
        {
            _lionProfileService = context;
            _lionTypeService = new LionTypeService();
        }

        [BindProperty]
        public LionProfile LionProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lionProfile = await _lionProfileService.GetByIdAsync(id.Value);

            if (lionProfile == null)
            {
                return NotFound();
            }

            var lionTypes = await _lionTypeService.GetAllAsync();

            LionProfile = lionProfile;

            ViewData["LionTypeId"] = new SelectList(lionTypes, "LionTypeId", "LionTypeName");

            lionProfile.LionType = lionTypes.FirstOrDefault(lt => lt.LionTypeId == lionProfile.LionTypeId);

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
                await _lionProfileService.UpdateAsync(LionProfile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + '/' + ex.StackTrace);
            }

            return RedirectToPage("./Index");
        }

    

}
}
