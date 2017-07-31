using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HermesORM.DbEntities;

namespace HermesORM
{
    public class UserMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Image).HasColumnName("Image").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Password).HasColumnName("Password").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.DisplayName).HasColumnName("DisplayName").IsOptional().HasColumnType("nvarchar"); //.HasMaxLength(50);

            // Foreign keys
            //HasRequired(a => a.Author).WithMany(b => b.Articles).HasForeignKey(c => c.AuthorId); // FK_Article_ToAuthor
            //HasMany(t => t.Tags).WithMany(t => t.User).Map(m =>
            {
                //    m.ToTable("blgArticleTags");
                //    m.MapLeftKey("ArticleId");
                //    m.MapRightKey("TagId");
                //});
            }
        }
    }
}

