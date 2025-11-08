using GroupTeam.Repository;
using GroupTeam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTeam.Service
{
    public class GroupTeamService 
    {
        //BP tên entity bảng phụ
        //RPB repository của bảng phụ
        //NLTS tên service của bảng phụ ( contructor)

        private readonly GroupTeamRepository _repository;

        public GroupTeamService() => _repository = new GroupTeamRepository();


        public async Task<List<Repository.Models.GroupTeam>> GetAllAsync()
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
