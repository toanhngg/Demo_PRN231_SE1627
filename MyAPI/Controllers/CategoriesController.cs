using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        MySaleDBContext context = new MySaleDBContext();
        // Get all
        [HttpGet]
        public IActionResult getAllCategory()
        {
            var data = context.Categories.ToList();
            return Ok(data);
        }
        // Get by id
        [HttpGet("getbyId")]
        public IActionResult getAllCategoryById(int categoryId)
        {
            var data = context.Categories.Where(x => x.CategoryId == categoryId);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
        // Insert
        //C1
        //[HttpPost("insert")]
        //public IActionResult InsertCategory(string CategoryName)
        //{
        //    //var data = context.Categories.Where(x => x.CategoryId == CategoryId);
        //    //if (data == null)
        //    //{
        //        Category category = new Category()
        //        {
        //            CategoryName = CategoryName
        //        };
        //        context.Categories.Add(category);
        //        context.SaveChanges();
        //        var listcategory = context.Categories.ToList();
        //        return Ok(listcategory);
        //    //}
        //    //else
        //    //{
        //    //    return BadRequest();
        //    //}
        //}
        [HttpPost("insert")]
        public IActionResult InsertCategory([FromBody] string CategoryName)
        {
            //var data = context.Categories.Where(x => x.CategoryId == CategoryId);
            //if (data == null)
            //{
            Category category = new Category()
            {
                CategoryName = CategoryName
            };
            context.Categories.Add(category);
            context.SaveChanges();
            var listcategory = context.Categories.ToList();
            return Ok(listcategory);
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }
        // Update
        [HttpPut("update")]
        public IActionResult UpdateCategory(Category c)
        {
            var data = context.Categories.FirstOrDefault(x => x.CategoryId == c.CategoryId);
            if (data != null)
            {
              data.CategoryName = c.CategoryName;
                context.Categories.Update(data);
                context.SaveChanges();
                var listcategory = context.Categories.ToList();

                return Ok(listcategory);
            }
            else
            {
                return BadRequest();
            }
        }
        //[HttpPut("update")]
        //public IActionResult UpdateCategory(int CategoryId, string CategoryName)
        //{
        //    var data = context.Categories.FirstOrDefault(x => x.CategoryId == CategoryId);
        //    if (data != null)
        //    {
        //        data.CategoryName = CategoryName;
        //        context.Categories.Update(data);
        //        context.SaveChanges();
        //        var listcategory = context.Categories.ToList();

        //        return Ok(listcategory);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        // Delete
        [HttpDelete("delete")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var data = context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if(data == null)
            {
                return BadRequest();

            }
            else
            {
                context.Categories.Remove(data);
                context.SaveChanges();
                var listcategory = context.Categories.ToList();

                return Ok(listcategory);
            }
        }
    }
}
