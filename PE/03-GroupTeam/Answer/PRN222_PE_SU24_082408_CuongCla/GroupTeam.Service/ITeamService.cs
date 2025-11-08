using GroupTeam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTeam.Service
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllAsync();

        Task<Team> GetByIdAsync(int id);

        Task<List<Team>> SearchAsync(string x1, decimal? x2);

        Task<int> CreateAsync(Team bc);

        Task<int> UpdateAsync(Team bc);

        Task<bool> DeleteAsync(int id);

        Task UpdatePositionsInGroupAsync(int groupId);

        Task<int> GetCurrentPointAsync(int teamId);

    }
}
