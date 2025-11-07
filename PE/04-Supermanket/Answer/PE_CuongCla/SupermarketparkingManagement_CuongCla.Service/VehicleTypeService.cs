using SupermarketparkingManagement_CuongCla.Repositories;
using SupermarketparkingManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Service
{
    public class VehicleTypeService
    {
        //BP tên entity bảng phụ
        //RPB repository của bảng phụ
        //NLTS tên service của bảng phụ ( contructor)

        private readonly VehicleTypeRepository _repository;

        public VehicleTypeService() => _repository = new VehicleTypeRepository();


        public async Task<List<VehicleType>> GetAllAsync()
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
