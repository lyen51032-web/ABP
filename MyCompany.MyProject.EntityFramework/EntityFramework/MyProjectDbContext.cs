using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using MyCompany.MyProject.Authorization.Roles;
using MyCompany.MyProject.Authorization.Users;
using MyCompany.MyProject.Entities;
using MyCompany.MyProject.MultiTenancy;

namespace MyCompany.MyProject.EntityFramework
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Player> Players { set; get; }
        public virtual IDbSet<Map> Maps { set; get; }


        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public MyProjectDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MyProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MyProjectDbContext since ABP automatically handles it.
         */
        public MyProjectDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MyProjectDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public MyProjectDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);

            //這裡用Player實體建立了名稱為Players的資料表，Map同理，加上s實際建立資料表時資料表名稱就會有s
            //然後再最後加上 在建立模型時增加關聯性 Player->Map
            //這樣就會有條件約束 Player內的MapID 必須在 Map 內可以找到對應的 ID
            //到這邊基本 DbContext 就建立完成了
            modelBuilder.Entity<Player>().HasRequired(p => p.Map);
        }

    }
}
