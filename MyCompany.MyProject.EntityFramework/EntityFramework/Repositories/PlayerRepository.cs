using Abp.EntityFramework;
using MyCompany.MyProject.Entities;
using MyCompany.MyProject.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.MyProject.EntityFramework.Repositories
{
    public class PlayerRepository : MyProjectRepositoryBase<Player, long>, IPlayerRepository
    {
        public PlayerRepository(IDbContextProvider<MyProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public List<Player> GetPlayersWithMap(long mapID)
        {
            // GetAll()返回一個IQueryable<T>，我們可以通過它來查詢
            //var query = GetAll();

            // 也可以直接使用EF的DbContext對象
            var query = Context.Players.AsQueryable();

            // 另一種選擇：直接使用Table屬性代替"Context.Players"，都是一樣的。
            //var query3 = Table.AsQueryable();

            if (mapID > 0)
            {
                query = query.Where(c => c.MapID == mapID);
            }
            return query.ToList();
        }

        public async Task<List<Player>> GetPlayersWithMapAsync(long mapID)
        {
            return await GetAllListAsync(c => c.MapID == mapID);
        }
    }
}
