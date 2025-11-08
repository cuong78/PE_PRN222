
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PantherPetManagement_CuongCla.Repositories.Models;
using PantherPetManagement_CuongCla.Service;


namespace PantherPetManagement_CuongCla.Pages.PantherProfiles
{
    public class IndexModel : PageModel
    {

        private readonly IPantherProfileService _context;

        public IndexModel(IPantherProfileService context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public decimal? Weight { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PantherTypeName { get; set; }


        public IList<PantherProfile> PantherProfile { get; set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            // Lấy tất cả dữ liệu từ backend
            var allProfiles = await _context.GetAllAsync();

            // Sắp xếp theo ModifiedDate giảm dần (mới nhất lên đầu)

            allProfiles = allProfiles.OrderByDescending(p => p.ModifiedDate).ToList();


            if (!string.IsNullOrEmpty(PantherTypeName) || Weight != null)
            {
                allProfiles = await _context.SearchAsync(PantherTypeName, Weight);
                // Sắp xếp lại sau khi search
                allProfiles = allProfiles.OrderByDescending(p => p.ModifiedDate).ToList();

            }

            PantherProfile = allProfiles;
        }

    }
}
