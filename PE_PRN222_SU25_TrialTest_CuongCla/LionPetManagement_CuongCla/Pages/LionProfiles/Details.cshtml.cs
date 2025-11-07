using LionPetManagement.Repositories.Models;
using LionPetManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LionPetManagement_CuongCla.Pages.LionProfiles
{
    [Authorize(Roles = "2,3")]
    public class DetailsModel : PageModel
    {
        private readonly ILionProfileService _lionProfileService;
        private readonly LionTypeService _lionTypeService;

        public DetailsModel(ILionProfileService context)
        {
            _lionProfileService = context;
            _lionTypeService = new LionTypeService();
        }

        public LionProfile LionProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lionprofile = await _lionProfileService.GetByIdAsync(id.Value);

            var lionType = await _lionTypeService.GetAllAsync();

            lionprofile.LionType = lionType.FirstOrDefault(l => l.LionTypeId == lionprofile.LionTypeId);

            if (lionprofile == null)
            {
                return NotFound();
            }
            else
            {
                LionProfile = lionprofile;
            }
            return Page();
        }
    }

}

