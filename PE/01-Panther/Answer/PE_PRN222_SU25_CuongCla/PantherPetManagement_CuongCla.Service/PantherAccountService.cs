using PantherPetManagement_CuongCla.Repositories;
using PantherPetManagement_CuongCla.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_CuongCla.Service
{
    public class PantherAccountService
    {


        private readonly PantherAccountRepositoy _repository;
        public PantherAccountService() => _repository = new PantherAccountRepositoy();

        public async Task<PantherAccount> GetAccount(string email, string password)
        {
            try
            {
                return await _repository.GetAccount(email, password);
            }
            catch (Exception ex) { }
            return null;

        }

    }
}
