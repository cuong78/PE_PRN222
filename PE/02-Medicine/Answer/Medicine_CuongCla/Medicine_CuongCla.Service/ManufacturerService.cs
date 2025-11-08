using Medicine_CuongCla.Repositories;
using Medicine_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_CuongCla.Service
{
    public class ManufacturerService
    {
        

        private readonly ManufacturerRepository _repository;

        public ManufacturerService() => _repository = new ManufacturerRepository();


        public async Task<List<Manufacturer>> GetAllAsync()
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
