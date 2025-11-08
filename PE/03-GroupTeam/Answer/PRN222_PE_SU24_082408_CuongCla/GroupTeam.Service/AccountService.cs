using GroupTeam.Repository;
using GroupTeam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTeam.Service
{
    public class AccountService
    {
        //BP tên entity bảng phụ
        //RPB repository của bảng phụ
        //NLTS tên service của bảng phụ ( contructor)

        private readonly AccountRepository _repository;

        public AccountService() => _repository = new AccountRepository();


        public async Task<Account> GetAccount(string username, string password)
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
