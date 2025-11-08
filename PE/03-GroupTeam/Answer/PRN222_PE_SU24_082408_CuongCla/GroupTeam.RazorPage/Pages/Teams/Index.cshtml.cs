using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupTeam.Repository.DBContext;
using GroupTeam.Repository.Models;
using GroupTeam.Service;

namespace GroupTeam.RazorPage.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly ITeamService _teamService;

        public IndexModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IList<Team> Team { get; set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            // Lấy tất cả dữ liệu từ backend
            var allProfiles = await _teamService.GetAllAsync();

            // Sắp xếp theo Group, sau đó theo Position (thứ hạng trong group)
            Team = allProfiles
                .OrderBy(t => t.Group?.GroupName)
                .ThenBy(t => t.Position)
                .ToList();
        }
    }
}
