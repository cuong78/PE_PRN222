using LionPetManagement.Repositories;
using LionPetManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LionPetManagement.Service
{
    public class LionAccountService
    {

        private readonly LionAccountRepository _repository;
        public LionAccountService() => _repository = new LionAccountRepository();

        public async Task<LionAccount> GetAccount(string username, string password)
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
