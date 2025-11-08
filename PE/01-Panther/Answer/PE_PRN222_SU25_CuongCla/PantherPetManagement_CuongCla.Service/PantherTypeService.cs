using PantherPetManagement_CuongCla.Repositories;
using PantherPetManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Service
{
    public class PantherTypeService
    {


        private readonly PantherTypeRepository _repository;

        public PantherTypeService() => _repository = new PantherTypeRepository();


        public async Task<List<PantherType>> GetAllAsync()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                return items;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
