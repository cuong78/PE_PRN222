using SupermarketparkingManagement_CuongCla.Repositories;
using SupermarketparkingManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketparkingManagement_CuongCla.Service
{
    public class SystemAccountService
    {
        //BA tên entity bảng account
        //RBA repository của bảng account
        //NLAS tên service của bảng account ( contructor)

        private readonly SystemAccountRepository _repository;
        public SystemAccountService() => _repository = new SystemAccountRepository();

        public async Task<SystemAccount> GetAccount(string username, string password)
        {
            try
            {
                return await _repository.GetAccount(username, password);
            }
            catch (Exception ex) { }
            return null;

        }

    }
}
