using LionPetManagement.Repositories;
using LionPetManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionPetManagement.Service
{
    public class LionTypeService
    {
        //BP tên entity bảng phụ
        //RPB repository của bảng phụ
        //NLTS tên service của bảng phụ ( contructor)

        private readonly LionTypeRepository _repository;

        public LionTypeService() => _repository = new LionTypeRepository();


        public async Task<List<LionType>> GetAllAsync()
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
