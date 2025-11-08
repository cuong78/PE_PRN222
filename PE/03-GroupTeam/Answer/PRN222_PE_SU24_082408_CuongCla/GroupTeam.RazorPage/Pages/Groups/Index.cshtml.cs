using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroupTeam.Repository.Models;
using GroupTeam.Service;

namespace GroupTeam.RazorPage.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly ITeamService _teamService;

        public IndexModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // Dictionary: Key = Group Name, Value = List of Teams sorted by Point ascending
        public Dictionary<string, List<Team>> GroupedTeams { get; set; }

        public async Task OnGetAsync()
        {
            // Get all teams
            var allTeams = await _teamService.GetAllAsync();

            // Group by Group Name and sort teams by Point in ASCENDING order
            GroupedTeams = allTeams
                .Where(t => t.Group != null) // Only teams with a group
                .GroupBy(t => t.Group.GroupName)
                .OrderBy(g => g.Key) // Sort groups alphabetically
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderBy(t => t.Point) // Sort by Point ASCENDING (lowest first)
                          .ThenBy(t => t.TeamName) // Tie-breaker
                          .ToList()
                );
        }
    }
}
