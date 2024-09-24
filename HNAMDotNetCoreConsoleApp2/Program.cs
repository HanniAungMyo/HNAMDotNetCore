// See https://aka.ms/new-console-template for more information
using HNAMDotNetCore.Database.Models;

Console.WriteLine("Hello, World!");

AppDbContext context = new AppDbContext();
 List<TblBlog> lst=context.TblBlogs.ToList();