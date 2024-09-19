using HNAMDotNetCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNAMDotNetCore.ConsoleApp
{
    public class EfCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogDataModel> lst = db.Blogs.Where(x => x.DeleteFlag == false).ToList();

            foreach (BlogDataModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }


        public void Create(string title, string author, string content)
        {
            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();

            Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Failed.");
        }

        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }
            Console.WriteLine(item?.BlogId);
            Console.WriteLine(item?.BlogTitle);
            Console.WriteLine(item?.BlogAuthor);
            Console.WriteLine(item?.BlogContent);
        }

        public void Update(int id, string title, string author, string content)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .AsNoTracking()
                .Where(x => x.BlogId == id).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            if (!string.IsNullOrEmpty(title))
            {
                item!.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                item!.BlogAuthor = author;
            }
            if (!string.IsNullOrEmpty(content))
            {
                item!.BlogContent = content;
            }
            db.Entry(item).State=EntityState.Modified;
            int result = db.SaveChanges();
            Console.Write(result == 1 ? "Update Successful" : "Update Failed");

        }

        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .AsNoTracking()
                .Where(x => x.BlogId == id).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Entry(item).State = EntityState.Deleted;
            int result = db.SaveChanges();
            Console.Write(result == 1 ? "Delete Successful" : "Delete Failed");
        }
    }
}

