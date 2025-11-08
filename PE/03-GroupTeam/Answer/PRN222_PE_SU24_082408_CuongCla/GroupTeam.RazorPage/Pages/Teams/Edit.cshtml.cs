using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupTeam.Repository.DBContext;
using GroupTeam.Repository.Models;
using GroupTeam.Service;

namespace GroupTeam.RazorPage.Pages.Teams
{
    public class EditModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly GroupTeamService _groupTeamService;

        public EditModel(ITeamService teamService, GroupTeamService groupTeamService)
        {
            _teamService = teamService;
            _groupTeamService = groupTeamService;
        }

        [BindProperty]
        public Team Team { get; set; } = default!;

        // Store the current point to display
        public int CurrentPoint { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var team = await _teamService.GetByIdAsync(id.Value);

            if (team == null)
            {
                return NotFound();
            }

            var groupTeam = await _groupTeamService.GetAllAsync();

            Team = team;
            CurrentPoint = team.Point; // Store current point
            Team.Point = 0; // Reset to 0 for input (user will select 0, 1, or 3 to ADD)

            ViewData["GroupId"] = new SelectList(groupTeam, "GroupId", "GroupName");

            team.Group = groupTeam.FirstOrDefault(lt => lt.GroupId == team.GroupId);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload dropdown data when validation fails
                var groups = await _groupTeamService.GetAllAsync();
                ViewData["GroupId"] = new SelectList(groups, "GroupId", "GroupName");
                
                // Get current point again for display
                var currentTeam = await _teamService.GetByIdAsync(Team.Id);
                CurrentPoint = currentTeam.Point;
                
                return Page();
            }
            try
            {
                // The service will handle: Point = existingPoint + Team.Point
                // and automatically update positions in the group
                await _teamService.UpdateAsync(Team);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + '/' + ex.StackTrace);
            }

            return RedirectToPage("./Index");
        }

    }
}