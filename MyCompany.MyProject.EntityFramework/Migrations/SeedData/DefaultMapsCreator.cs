using MyCompany.MyProject.Entities;
using MyCompany.MyProject.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.MyProject.Migrations.SeedData
{
    class DefaultMapsCreator
    {
        private readonly MyProjectDbContext _context;
        public DefaultMapsCreator(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateMaps();
        }

        public void CreateMaps()
        {
            var defaultMap = _context.Maps.FirstOrDefault(t => t.MapName == Map.DefaultMapName);
            if (defaultMap == null)
            {
                _context.Maps.Add(new Map { MapName = Map.DefaultMapName });
                _context.SaveChanges();
            }
        }
    }
}
