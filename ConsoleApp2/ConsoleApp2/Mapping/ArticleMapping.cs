using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using BlogORM.Model;

namespace BlogORM.Mapping
{
    class ArticleMapping : EntityTypeConfiguration <Articles>
    {
        public ArticleMapping()
        {
            ToTable("blgArcticle");

            Property(p => p.Article_ID)
                .HasColumnName("Article_ID")
                .IsRequired()
                .HasColumnType("int");

            Property(p => p.Title)
                .HasColumnName("title")
                .IsRequired();
            
        }
    }
}
