using LionPetManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionPetManagement.Service
{
    public interface ILionProfileService
    {
        Task<List<LionProfile>> GetAllAsync();

        Task<LionProfile> GetByIdAsync(int id);

        Task<List<LionProfile>> SearchAsync(string lionTypeName, float? weight);

        Task<int> CreateAsync(LionProfile lionProfile);

        Task<int> UpdateAsync(LionProfile lionProfile);

        Task<bool> DeleteAsync(int id);

    }
}
