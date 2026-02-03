using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.DTO;
using OrderManagementSystem.Model;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ORcontext context;
        public ProductController(ORcontext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult GetALLProd()
        {
            List<Product> products = context.Product.ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product = context.Product.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult NewProduct(Product prod)
        {
            context.Product.Add(prod);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetProductById), new { id = prod.ProductId }, prod);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult updateProduct(int id, Product prodtFromREquest)
        {
            Product prod = context.Product.FirstOrDefault(x =>x.ProductId == id);
            if (prod == null)
            {
                return NotFound();
            }
            prod.Name = prodtFromREquest.Name;
            prod.Price = prodtFromREquest.Price;
            prod.Stock = prodtFromREquest.Stock;
            return Ok($"Product with ID {id} not found.");

        }
    }
}
