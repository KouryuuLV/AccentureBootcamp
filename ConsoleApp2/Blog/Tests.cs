using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogORM;
using System.Data.Entity;
using BlogORM.Model;
using BlogORM.Mapping;

namespace BlogTest
{
    class Tests
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDbContext())
            {
            //    var author = context.Authors.First(a => a.FullName.EndsWith("h"));

            //    var author = context.Authors.First(a => a.Articles.where.Count>0);
            //    {
            //        foreach (var arth in author)
            //        {
            //            Console.WriteLine(author.FullName);
            //    } }
            //    context.Articles.Add(new BlogORM.Model.Artilces
            //    {
            //        Author_ID = author.Author_ID;
            //    Title = "From c#";
            //    Contents = "Tests Contents";
            //    Status = 2;
            //    CreatedTime = DateTime.Now;

            //});
            //context.saveChanges();


            //var author = context.Authors.First();
            //context.Articles.Add(new BlogORM.Model.Artilces
            //{
            //    Author_ID = author.Author_ID;
            //Title = "From c#";
            //Contents = "Tests Contents";
            //Status = 2;
            //CreatedTime = DateTime.Now;

            //});
            //context.saveChanges();

            foreach (var arcticle in context.Articles)
                    //.Include("Author"))
                {
                    Console.WriteLine(arcticle.Title);
                }
            }
        }
    }
}