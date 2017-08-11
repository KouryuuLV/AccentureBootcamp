using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HermesORM.DbEntities;

namespace HermesORM
{
    public class UserMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserContract>
    {
        public UserMap()
        {
            ToTable("AspNetUsers");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("Id").IsRequired().HasColumnType("nvarchar").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None).HasMaxLength(128);
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.FirstName).HasColumnName("FirstName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.LastName).HasColumnName("LastName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            //Property(x => x.Image).HasColumnName("Image").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Password).HasColumnName("PasswordHash").IsOptional().HasColumnType("nvarchar");
            //Property(x => x.DisplayName).HasColumnName("DisplayName").IsOptional().HasColumnType("nvarchar"); //.HasMaxLength(50);
            Property(x => x.SecurityStamp).HasColumnName("SecurityStamp").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.EmailConfirmed).HasColumnName("EmailConfirmed").IsRequired().HasColumnType("bit");
            Property(x => x.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed").IsOptional().HasColumnType("bit");
            Property(x => x.TwoFactorEnable).HasColumnName("TwoFactorEnabled").IsRequired().HasColumnType("bit");
            Property(x => x.LockoutEnabled).HasColumnName("LockoutEnabled").IsRequired().HasColumnType("bit");
            Property(x => x.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc").IsOptional().HasColumnType("datetime");
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").IsOptional().HasColumnType("nvarchar");
            Property(x => x.AccessFailedCount).HasColumnName("AccessFailedCount").IsRequired().HasColumnType("int");

            // Foreign keys
            //HasRequired(a => a.Author).WithMany(b => b.Articles).HasForeignKey(c => c.AuthorId); // FK_Article_ToAuthor
            //HasMany(t => t.Tags).WithMany(t => t.User).Map(m =>
            //{
            //    m.ToTable("blgArticleTags");
            //    m.MapLeftKey("ArticleId");
            //    m.MapRightKey("TagId");
            //});
            //}
        }
    }
}

