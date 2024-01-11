using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        MySaleDBContext context = new MySaleDBContext();
        // Get all
        [HttpGet]
        public IActionResult getAllProduct()
        {
            //var product = context.Products.Include(x => x.Category).ToList();

            //return Ok(product);


            var data = from product in context.Products
                       join category in context.Categories on product.CategoryId equals category.CategoryId
                       select new Product
                       {
                           ProductId = product.ProductId,
                           CategoryId = category.CategoryId,
                           ProductName = product.ProductName,
                           UnitPrice = product.UnitPrice,
                           UnitsInStock = product.UnitsInStock,
                           Image = product.Image,
                           Category = category
                       };
            return Ok(data);

        }
        // Get by Id
        [HttpGet("getbyID")]
        public IActionResult getAllProduct(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(product);

            }
        }
        // Insert
        [HttpPost("insert")]
        public IActionResult insertProduct(Product product)
        {
            var p = context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (p == null)
            {
                Product product1 = new Product()
                {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                CategoryId = product.CategoryId,
                Image = product.Image,
                Category = null,

            };
                context.Products.Add(product1);
                context.SaveChanges();
                var data = context.Products.ToList();
                return Ok(data);
            }
            else
            {
                return BadRequest();

            }
        }
        // Update
        [HttpPut("update")]
        public IActionResult updateProduct(Product product)
        {
            var p = context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (p != null)
            {
                p.ProductName = product.ProductName;
                p.UnitPrice = product.UnitPrice;
                p.UnitsInStock = product.UnitsInStock;
                p.CategoryId = product.CategoryId;
                p.Image = product.Image;
                p.Category = null;

                context.Products.Update(p);
                context.SaveChanges();
                var data = context.Products.ToList();
                return Ok(data);
            }
            else
            {
                return BadRequest();

            }
        }
        // Delete
        [HttpDelete("delete")]
        public IActionResult delete(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return BadRequest();
            }
            else
            {

                context.Products.Remove(product);
                context.SaveChanges();
                var data = context.Products.ToList();
                return Ok(data);
            }
        }
    }
}
