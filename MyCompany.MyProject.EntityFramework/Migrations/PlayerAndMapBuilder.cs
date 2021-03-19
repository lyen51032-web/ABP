using MyCompany.MyProject.EntityFramework;
using MyCompany.MyProject.Migrations.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.MyProject.Migrations
{
    class PlayerAndMapBuilder
    {
        private readonly MyProjectDbContext _context;
        public PlayerAndMapBuilder(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultMapsCreator(_context).Create();
            new DefaultPlayersCreator(_context).Create();
        }
    }
}
