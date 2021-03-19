using MyCompany.MyProject.Entities;
using MyCompany.MyProject.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.MyProject.Migrations.SeedData
{
    class DefaultPlayersCreator
    {
        private readonly MyProjectDbContext _context;

        public DefaultPlayersCreator(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreatePlayers();
        }

        public void CreatePlayers()
        {
            var defaultPlayer = _context.Players.FirstOrDefault(t => t.PlayerName == Player.DefaultPlayerName);
            if (defaultPlayer == null)
            {
                _context.Players.Add(new Player { PlayerName = Player.DefaultPlayerName });
                _context.SaveChanges();
            }
        }
    }
}
