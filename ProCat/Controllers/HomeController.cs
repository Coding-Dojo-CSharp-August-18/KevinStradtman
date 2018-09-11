using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProCat.Models;

namespace ProCat.Controllers
{
    public class HomeController : Controller
    {
        private ProContext _context;
 
        public HomeController(ProContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.products.ToList();
            ViewBag.products = products;
            return View();
        }
        [HttpGet("categories")]
        public IActionResult Categories()
        {
            IEnumerable<Category> categories = _context.categories.ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpGet("addproduct")]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpGet("addcategory")]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpGet("product/{id}")]
        public IActionResult Product(int id)
        {
            Product product = _context.products
                .Include(p => p.CatPro)
                .ThenInclude(c => c.Categories)
                .SingleOrDefault(p => p.product_id == id);
            List<Category> categories = _context.categories
                .Include(c => c.CatPro)
                .ThenInclude(p => p.Categories)
                .ToList();
            ViewBag.categories = categories;
            return View(product);
        }
        [HttpPost("AddCategoryToProduct")]
        public IActionResult AddCategoryToProduct(int productid, int categoryid)
        {
            CatPro cat = new CatPro
            {
                product_id = productid,
                category_id = categoryid
            };
            _context.categories_products.Add(cat);
            _context.SaveChanges();
            return Redirect("~/product/" + productid);
        }
        [HttpGet("category/{id}")]
        public IActionResult Category(int id)
        {
            Category category = _context.categories
                .Include(c => c.CatPro)
                .ThenInclude(p => p.Products)
                .SingleOrDefault(c => c.category_id == id);
            List<Product> products = _context.products
                .Include(p => p.CatPro)
                .ThenInclude(c => c.Categories)
                .ToList();
            ViewBag.products = products;
            return View(category);
        }
        [HttpPost("AddProductToCategory")]
        public IActionResult AddProductToCategory(int productid, int categoryid)
        {
            CatPro pro = new CatPro
            {
                product_id = productid,
                category_id = categoryid
            };
            _context.categories_products.Add(pro);
            _context.SaveChanges();
            return Redirect("~/category/" + categoryid);
        }
        [HttpPost("process-product")]
        public IActionResult ProcessProduct(AddProduct product)
        {
            if(ModelState.IsValid)
            {
                Product newProd = new Product
                {
                    name = product.name,
                    description = product.description,
                    price = product.price
                };
                _context.products.Add(newProd);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddProduct");
        }
        [HttpPost("process-category")]
        public IActionResult ProcessCategory(AddCategory category)
        {
            if(ModelState.IsValid)
            {
                Category newCat = new Category
                {
                    name = category.name
                };

                _context.categories.Add(newCat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddCategory");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
