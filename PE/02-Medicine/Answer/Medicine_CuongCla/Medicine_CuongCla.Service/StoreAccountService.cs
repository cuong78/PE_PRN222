using Medicine_CuongCla.Repositories;
using Medicine_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_CuongCla.Service
{
    public class StoreAccountService
    {
        //BA tên entity bảng account
        //RBA repository của bảng account
        //NLAS tên service của bảng account ( contructor)

        private readonly StoreAccountRepository _repository;
        public StoreAccountService() => _repository = new StoreAccountRepository();

        public async Task<StoreAccount> GetAccount(string username, string password)
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
