using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupTeam.Repository.DBContext;
using GroupTeam.Repository.Models;
using GroupTeam.Service;

namespace GroupTeam.RazorPage.Pages.Teams
{
    public class CreateModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly GroupTeamService _groupTeamService;

        public CreateModel(ITeamService teamService,
                           GroupTeamService groupTeamService)
        {
            _teamService = teamService;
            _groupTeamService = groupTeamService;
        }

        public async Task<IActionResult> OnGet()
        {
            var lionTypes = await _groupTeamService.GetAllAsync();

            ViewData["GroupId"] = new SelectList(lionTypes, "GroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload the GroupId dropdown when validation fails
                var groups = await _groupTeamService.GetAllAsync();
                ViewData["GroupId"] = new SelectList(groups, "GroupId", "GroupName");
                return Page();
            }

            await _teamService.CreateAsync(Team);
            return RedirectToPage("./Index");
        }
    }
}

