using PantherPetManagement_CuongCla.Repositories;
using PantherPetManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Service
{
    public class PantherProfileService : IPantherProfileService
    {
     

        private readonly PantherProfileRepository _repository;
        public PantherProfileService() => _repository = new PantherProfileRepository();


        public async Task<int> CreateAsync(PantherProfile pantherProfile)
        {
            try
            {
                return await _repository.CreateAsync(pantherProfile);
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

        public async Task<List<PantherProfile>> GetAllAsync()
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
            return new List<PantherProfile>();
        }

        public async Task<PantherProfile> GetByIdAsync(int id)
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

        public async Task<List<PantherProfile>> SearchAsync(string pantherTypeName, decimal? weight)
        {
            try
            {
                var items = await _repository.SearchAsync(pantherTypeName, weight);
                return items;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new List<PantherProfile>();
        }

        public async Task<int> UpdateAsync(PantherProfile pantherProfile)
        {
            try
            {
                return await _repository.UpdateAsync(pantherProfile);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return 0;
        }

    }
}
