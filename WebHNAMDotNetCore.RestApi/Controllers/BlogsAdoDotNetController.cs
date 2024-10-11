using HNAMDotNetCore.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using WebHNAMDotNetCore.RestApi.ViewsModel;

namespace WebHNAMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsAdoDotNetController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=LAPTOP\\SQLSERVER;Initial Catalog=DotNet;User ID=sa; Password=sa@123";

        [HttpGet]
        public IActionResult GetBlog()
        {
            List<ViewModel> list = new List<ViewModel>();
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
                //Console.WriteLine(dr["DeleteFlag"]);
                list.Add(new ViewModel
                {
                    Id = Convert.ToInt32(reader["BlogId"]),
                    Title = Convert.ToString(reader["BlogTitle"]),
                    Author = Convert.ToString(reader["BlogAuthor"]),
                    Content = Convert.ToString(reader["BlogContent"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                });
            }



            connection.Close();


            return Ok(list);
        }

        [HttpGet("{Id}")]
       
        [HttpPost]
        public IActionResult CreateBlog(ViewModel blog)
        {
            List<ViewModel> list = new List<ViewModel>();
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            list.Add(new ViewModel
            {

                Title = Convert.ToString(cmd.Parameters.AddWithValue("@BlogTitle", blog.Title)),
                Author = Convert.ToString(cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author)),
                Content = Convert.ToString(cmd.Parameters.AddWithValue("@BlogContent", blog.Content)),
            });
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Create Successfully" : "Create fail";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, ViewModel blog)
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            cmd.Parameters.AddWithValue("@BlogContent", blog.Content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, ViewModel blog)
        {
            //    string condition = "";
            //    if (!string.IsNullOrEmpty(blog.Title))
            //    {
            //        condition += " [BlogTitle] = @BlogTitle, ";
            //    }
            //    if (!string.IsNullOrEmpty(blog.Author))
            //    {
            //        condition += " [BlogAuthor] = @BlogAuthor, ";
            //    }
            //    if (!string.IsNullOrEmpty(blog.Content))
            //    {
            //        condition += " [BlogContent] = @BlogContent, ";
            //    }
            //    if (condition.Length == 0)
            //    {
            //        return BadRequest("Invalid Parameter");
            //    }
            //    condition = condition.Substring(0, condition.Length - 2);
            //    SqlConnection connection = new SqlConnection(_connectionString);
            //    connection.Open();

            //    string query = $@"UPDATE [dbo].[Tbl_Blog]
            //     SET {condition}  WHERE BlogId = @BlogId;




            //    cmd.Parameters.AddWithValue("@BlogTitle", title);
            //    cmd.Parameters.AddWithValue("@BlogAuthor", author);
            //    cmd.Parameters.AddWithValue("@BlogContent", content);

            //    int result = cmd.ExecuteNonQuery();

            //    connection.Close();

            //    Console.WriteLine(result == 1 ? "Updating Successful." : "Updating Failed.");

            //    return Ok();
            string conditions = "";
            if (!string.IsNullOrEmpty(blog.Title))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                conditions += " [BlogContent] = @BlogContent, ";
            }

            if (conditions.Length == 0)
            {
                return BadRequest("Invalid Parameters!");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"UPDATE [dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (!string.IsNullOrEmpty(blog.Title))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.Content);
            }

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return Ok(result > 0 ? "Updating Successful." : "Updating Failed.");
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                       WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result == 1 ? "Delete Successful." : "Delete Failed.";
            return Ok(message);
        }
    }
}
