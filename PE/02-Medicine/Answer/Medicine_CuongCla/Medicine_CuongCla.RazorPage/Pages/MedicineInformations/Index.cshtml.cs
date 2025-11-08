using Medicine_CuongCla.Repositories.DBContext;
using Medicine_CuongCla.Repositories.Models;
using Medicine_CuongCla.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine_CuongCla.RazorPage.Pages.MedicineInformations
{
    public class IndexModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string WarningsAndPrecautions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ActiveIngredients { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ExpirationDate { get; set; }



        private readonly IMedicineInformationService _medicineInformationService;

        public IndexModel(IMedicineInformationService MedicineInformationService)
        {
            _medicineInformationService = MedicineInformationService;
        }

        public IList<MedicineInformation> MedicineInformation { get; set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            List<MedicineInformation> allProfiles;

            // Kiểm tra xem có tìm kiếm không
            if (!string.IsNullOrEmpty(WarningsAndPrecautions) || 
                !string.IsNullOrEmpty(ActiveIngredients) || 
                !string.IsNullOrEmpty(ExpirationDate))
            {
                // Nếu có search, gọi SearchAsync
                allProfiles = await _medicineInformationService.SearchAsync(ActiveIngredients, WarningsAndPrecautions, ExpirationDate);
                
                // Nhóm kết quả theo ActiveIngredients, ExpirationDate, WarningsAndPrecautions
                allProfiles = allProfiles
                    .OrderBy(m => m.ActiveIngredients)
                    .ThenBy(m => m.ExpirationDate)
                    .ThenBy(m => m.WarningsAndPrecautions)
                    .ToList();
            }
            else
            {
                // Không có search, lấy tất cả
                allProfiles = await _medicineInformationService.GetAllAsync();

                // Kiểm tra xem có record mới vừa được tạo không
                if (TempData["NewMedicineId"] != null)
                {
                    var newMedicineId = TempData["NewMedicineId"].ToString();

                    // Tìm record vừa tạo
                    var newRecord = allProfiles.FirstOrDefault(m => m.MedicineId == newMedicineId);

                    if (newRecord != null)
                    {
                        // Xóa record khỏi vị trí cũ
                        allProfiles.Remove(newRecord);

                        // Thêm vào đầu danh sách
                        allProfiles.Insert(0, newRecord);
                    }
                }
            }

            MedicineInformation = allProfiles;
        }

    }
}
