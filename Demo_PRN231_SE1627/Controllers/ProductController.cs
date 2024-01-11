using Demo_PRN231_SE1627.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace Demo_PRN231_SE1627.Controllers
{
    public class ProductController : Controller
    {
        private readonly MySaleDBContext _context; 
        public ProductController(MySaleDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listProduct = _context.Products.Include(c => c.Category).ToList();
            var listCategoty = _context.Categories.ToList();

            ViewBag.Products = listProduct;
            ViewBag.Categories = listCategoty;

            return View();
        }
        [HttpPost]
        public IActionResult Create()
        {
            //var code = HttpContext.Request.Form["code"].ToString();
            var name = HttpContext.Request.Form["name"].ToString();
            var stock = int.Parse(HttpContext.Request.Form["stock"]);
            var price = decimal.Parse(HttpContext.Request.Form["price"]);
            var image = HttpContext.Request.Form["image"].ToString();
            var categoryId = int.Parse(HttpContext.Request.Form["category"]);
            var newProduct = new Product
            {
                ProductName = name,
                UnitsInStock = stock,
                UnitPrice = price,
                Image = image,
                CategoryId = categoryId
            };
            if (ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách sản phẩm
            }

            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(); // Trả về view với dữ liệu nhập vào để người dùng điền lại
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var productToDelete = _context.Products.Find(id);
            if (productToDelete == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productToDelete);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPost]
        public IActionResult Update(int id)
        {
            var existingProduct = _context.Products.Find(id);

            if (existingProduct == null)
            {
                return NotFound(); 
            }
            var name = HttpContext.Request.Form["name"].ToString();
            var stock = double.Parse(HttpContext.Request.Form["stock"]);
            var price = decimal.Parse(HttpContext.Request.Form["price"]);
            var image = HttpContext.Request.Form["image"].ToString();
            var categoryId = int.Parse(HttpContext.Request.Form["category"]);
            var newProduct = new Product
            {
                ProductName = name,
                UnitsInStock = (int)stock,
                UnitPrice = price,
                Image = image,
                CategoryId = categoryId
            };
            if (ModelState.IsValid)
            {
                existingProduct.ProductName = newProduct.ProductName;
                existingProduct.UnitsInStock = newProduct.UnitsInStock;
                existingProduct.UnitPrice = newProduct.UnitPrice;
                existingProduct.Image = newProduct.Image;
                existingProduct.CategoryId = newProduct.CategoryId;

                _context.SaveChanges(); 
                return RedirectToAction("Index"); 
            }

            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(); 
        }

    }
}
