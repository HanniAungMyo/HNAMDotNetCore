﻿using HNAMDotNetCore.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebHNAMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _db =new AppDbContext();
        [HttpGet]
        public IActionResult GetBlog()
        {
            var lst = _db.TblBlogs.AsNoTracking().ToList();     
              return Ok(lst);
        }

        [HttpGet ("{id}")]

        public IActionResult GetBlogById(int id)
        {
             TblBlog? item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x=>x.BlogId==id);
            if(item is null)
            {
                    return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            _db.TblBlogs.Add(blog);
            _db.SaveChanges();
            return Ok(blog);
        }
        [HttpPut ("{id}")]
        public IActionResult UpdateBlog(int id,TblBlog blog)
        {
            TblBlog? item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound();
            }
            item.BlogTitle=blog.BlogTitle;
            item.BlogAuthor=blog.BlogAuthor;
            item.BlogContent=blog.BlogContent;
            _db.Entry(item).State=EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }
        [HttpPatch]
        public IActionResult PatchBlog()
        {
            return Ok();
        }


        [HttpDelete]
        public IActionResult DeleteBlog()
        {
            return Ok();
        }
    }
}
