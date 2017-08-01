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
        public System.Data.Entity.DbSet<User> User { get; set; } // User table
        static DbHermesContext()
        {
            System.Data.Entity.Database.SetInitializer<DbHermesContext>(null);
        }

        #region constructor overrides
        public DbHermesContext() : base("Name=StudentDb")
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
        }
    }
}

