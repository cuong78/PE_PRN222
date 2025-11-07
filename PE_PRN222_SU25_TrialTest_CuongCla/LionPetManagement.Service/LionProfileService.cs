using LionPetManagement.Repositories;
using LionPetManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionPetManagement.Service
{
    public class LionProfileService : ILionProfileService
    {
    

        private readonly LionProfileRepository _repository;
        public LionProfileService() => _repository = new LionProfileRepository();


        public async Task<int> CreateAsync(LionProfile lionProfile)
        {
            try
            {
                return await _repository.CreateAsync(lionProfile);
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

        public async Task<List<LionProfile>> GetAllAsync()
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
            return new List<LionProfile>();
        }

        public async Task<LionProfile> GetByIdAsync(int id)
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

        public async Task<List<LionProfile>> SearchAsync(string lionTypeName, float? weight)
        {
            try
            {
                var items = await _repository.SearchAsync(lionTypeName, weight);
                return items;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new List<LionProfile>();
        }

   

        public async Task<int> UpdateAsync(LionProfile lionProfile)
        {
            try
            {
                return await _repository.UpdateAsync(lionProfile);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return 0;
        }


    }
}
