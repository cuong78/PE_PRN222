using GroupTeam.Repository;
using GroupTeam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTeam.Service
{
    public class TeamService : ITeamService
    {
        //RPC repository của bảng chính
        //NS  tên service của bảng chính ( contructor)
        // BC là tên entity  bảng chính
        // BCs là tên entity bảng chính thêm chữ s


        private readonly TeamRepository _repository;
        public TeamService() => _repository = new TeamRepository();


        public async Task<int> CreateAsync(Team bc)
        {
            try
            {
                // Initialize Position to 0 when creating (will be calculated after)
                bc.Position = 0;
                
                var result = await _repository.CreateAsync(bc);
                
                // After creating, update positions for all teams in the same group
                if (bc.GroupId.HasValue)
                {
                    await _repository.UpdatePositionsInGroupAsync(bc.GroupId.Value);
                }
                
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item != null)
                {
                    return await _repository.RemoveAsync(item);

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
        }

        public async Task<List<Team>> GetAllAsync()
        {
            try
            {
                ////Business rules here
                var items = await _repository.GetAllAsync();
                return items;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new List<Team>();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                return item;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return null;
        }

        public async Task<List<Team>> SearchAsync(string x1, decimal? x2)
        {
            try
            {
                var items = await _repository.SearchAsync(x1, x2);
                return items;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new List<Team>();
        }

        public async Task<int> UpdateAsync(Team bc)
        {
            try
            {
                // Get the current team from database to get the old point value
                var existingTeam = await _repository.GetByIdAsync(bc.Id);
                if (existingTeam == null)
                {
                    throw new Exception("Team not found");
                }

                // Update only the fields that should be changed
                existingTeam.TeamName = bc.TeamName;
                existingTeam.GroupId = bc.GroupId;
                
                // Add the new point value to existing points (Point = Point + value)
                existingTeam.Point = existingTeam.Point + bc.Point;
                
                // Don't touch Position here - it will be calculated after
                
                var result = await _repository.UpdateAsync(existingTeam);
                
                // After updating, recalculate positions for all teams in the same group
                if (existingTeam.GroupId.HasValue)
                {
                    await _repository.UpdatePositionsInGroupAsync(existingTeam.GroupId.Value);
                }
                
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return 0;
        }

        public async Task UpdatePositionsInGroupAsync(int groupId)
        {
            try
            {
                await _repository.UpdatePositionsInGroupAsync(groupId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> GetCurrentPointAsync(int teamId)
        {
            try
            {
                return await _repository.GetCurrentPointAsync(teamId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return 0;
        }

    }
}
