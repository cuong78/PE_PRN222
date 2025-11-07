using LionPetManagement.Repositories.Models;
using LionPetManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LionPetManagement_CuongCla.Pages.LionProfiles
{
    [Authorize(Roles = "2,3")]
    public class SearchModel : PageModel
    {
        private readonly ILionProfileService _lionProfileService;

        public SearchModel(ILionProfileService lionProfileService)
        {
            _lionProfileService = lionProfileService;
        }

        [BindProperty(SupportsGet = true)]
        public float? Weight { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LionTypeName { get; set; }

        public IList<LionProfile> LionProfile { get; set; } = new List<LionProfile>();

        public async Task OnGetAsync()
        {
            // Nếu có tham số search, thực hiện tìm kiếm
            if (!string.IsNullOrEmpty(LionTypeName) || Weight != null)
            {
                LionProfile = await _lionProfileService.SearchAsync(LionTypeName, Weight);
                
                // Sắp xếp theo ModifiedDate giảm dần (mới nhất lên đầu)
                LionProfile = LionProfile.OrderByDescending(p => p.ModifiedDate).ToList();
            }
            // Nếu không có tham số, để list rỗng (hiển thị form search)
        }
    }
}
