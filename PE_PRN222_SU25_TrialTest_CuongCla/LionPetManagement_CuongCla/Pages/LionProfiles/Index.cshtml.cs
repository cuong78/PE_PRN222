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
    public class IndexModel : PageModel
    {
        private readonly ILionProfileService _context;

        public IndexModel(ILionProfileService context)
        {
            _context = context;
        }

        public IList<LionProfile> LionProfile { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Lấy tất cả dữ liệu từ backend
            var allProfiles = await _context.GetAllAsync();

            // Sắp xếp theo ModifiedDate giảm dần (mới nhất lên đầu)
            allProfiles = allProfiles.OrderByDescending(p => p.ModifiedDate).ToList();

            // Nếu sắp tăng dần thì 
            // allProfiles = allProfiles.OrderBy(p => p.ModifiedDate).ToList();

            // nếu như đề cố tình chèn dữ liệu mẫu date hơn với thời gian hiện tại 
            // mà có id tự tăng , thì ta sẽ sắp xếp theo id tăng dần
            // allProfiles = allProfiles.OrderBy(p => p.LionProfileId).ToList

            LionProfile = allProfiles;
        }
    }



}

