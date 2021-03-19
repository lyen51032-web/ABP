using Abp.Domain.Repositories;
using MyCompany.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.MyProject.IRepositories
{
    public interface IPlayerRepository : IRepository<Player, long>
    {
        List<Player> GetPlayersWithMap(long mapID);
    }
}
