using LionPetManagement.Repositories.Models;
using LionPetManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LionPetManagement_CuongCla.Pages.LionProfiles
{
    [Authorize(Roles = "2")]
    public class CreateModel : PageModel
    {
        private readonly ILionProfileService _lionProfileService;
        private readonly LionTypeService _lionTypeService;

        public CreateModel(ILionProfileService lionProfileService,
                           LionTypeService lionTypeService)
        {
            _lionProfileService = lionProfileService;
            _lionTypeService = lionTypeService;
        }

        public async Task<IActionResult> OnGet()
        {
            LionProfile = new LionProfile();
            LionProfile.ModifiedDate = DateTime.Now;


            var lionTypes = await _lionTypeService.GetAllAsync();

            ViewData["LionTypeId"] = new SelectList(lionTypes, "LionTypeId", "LionTypeName");
            return Page();
        }


        [BindProperty]
        public LionProfile LionProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _lionProfileService.CreateAsync(LionProfile);
            return RedirectToPage("./Index");
        }

    }
}
