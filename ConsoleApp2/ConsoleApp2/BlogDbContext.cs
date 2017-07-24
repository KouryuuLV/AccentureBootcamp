using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlogORM.Model;
using BlogORM.Mapping;


namespace BlogORM
{
    public class BlogDbContext : DbContext
    {
        public IDbSet<Articles> Articles { get; set; }
        public IDbSet<Authors> Authors { get; set; }
        //static BlogORM()
        //{
        //Database.SetInitializer<BlogDbContext>(null);
        //}

    public BlogDbContext() : base("Name=DbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ArticleMapping());
            modelBuilder.Configurations.Add(new AuthorMapping());
        }   

    }
}
