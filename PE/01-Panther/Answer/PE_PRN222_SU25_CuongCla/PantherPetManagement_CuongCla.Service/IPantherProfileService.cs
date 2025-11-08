using PantherPetManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Service
{
    public interface IPantherProfileService
    {

        Task<List<PantherProfile>> GetAllAsync();

        Task<PantherProfile> GetByIdAsync(int id);

        Task<List<PantherProfile>> SearchAsync(string pantherTypeName, decimal? weight);

        Task<int> CreateAsync(PantherProfile pantherProfile);

        Task<int> UpdateAsync(PantherProfile pantherProfile);

        Task<bool> DeleteAsync(int id);

    }
}
