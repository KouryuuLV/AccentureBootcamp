//https://www.captechconsulting.com/blogs/Customizing-the-ASPNET-Identity-Data-Model-with-the-Entity-Framework-Fluent-API--Part-1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HermesORM.DbEntities;

namespace HermesORM
{
    public class DbHermesContext : System.Data.Entity.DbContext
    {
        // ------ Here goes Object definitions for EF
        public System.Data.Entity.DbSet<UserContract> User { get; set; } // User table
        static DbHermesContext()
        {
            System.Data.Entity.Database.SetInitializer<DbHermesContext>(null);
        }

        #region constructor overrides
        public DbHermesContext() : base("Name=HermesDb")
        {
        }

        public DbHermesContext(string connectionString) : base(connectionString)
        {
        }

        public DbHermesContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }
        #endregion

        // Override event to add our own object mappings
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());

    //        modelBuilder.Entity<DbHermesContext>()
    //.HasKey(p => p.Id)
    //    .Property(p => p.Id)
    //        .StoreGeneratedPattern = StoreGeneratedPattern.None;

    //        builder.Entity<DbHermesContext>().MapSingleType().ToTable("BOB");
        }
    }
}

