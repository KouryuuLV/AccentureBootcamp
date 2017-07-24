using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using BlogORM.Model;

namespace BlogORM.Mapping
{
    class AuthorMapping : EntityTypeConfiguration<Authors>
    {
        public AuthorMapping()
        {
            ToTable("blgAuthor");

            Property(p => p.Author_ID)
                .HasColumnName("Author_ID")
                .IsRequired()
                .HasColumnType("int");
        }
    }
}
