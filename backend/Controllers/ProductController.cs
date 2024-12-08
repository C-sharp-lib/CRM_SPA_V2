using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context) 
        { 
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            var products =  await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("product-count")]
        public async Task<IActionResult> ProductCount()
        {
            return Ok(await _context.Products.CountAsync());
        }
        [HttpGet("product-details/{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Order)
                .SingleOrDefaultAsync(p => p.ProductId == id);
            if (product == null) 
            {
                return NotFound("There is not a product by that id.");
            }
            return Ok(product);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Products prod = new Products
                    {
                        Name = product.Name,
                        UPC = product.UPC,
                        Description = product.Description,
                        Price = product.Price,
                        Category = product.Category,
                        Currency = product.Currency,
                        QuantityInStock = product.QuantityInStock,
                        ImageUrl = product.ImageUrl,
                        IsActive = product.IsActive
                    };
                    _context.Products.Add(prod);
                    await _context.SaveChangesAsync();
                    return Ok("Product Created!");
                }
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
            return BadRequest("Could not create product.");
        }

        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO product) 
        {
            try
            {
                var updateProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if(updateProduct == null)
                {
                    return NotFound("Could not find the product.");
                }
                if (ModelState.IsValid)
                {
                    updateProduct.Name = product.Name;
                    updateProduct.UPC = product.UPC;
                    updateProduct.Description = product.Description;
                    updateProduct.Price = product.Price;
                    updateProduct.Category = product.Category;
                    updateProduct.Currency = product.Currency;
                    updateProduct.ImageUrl = product.ImageUrl;
                    updateProduct.IsActive = product.IsActive;
                    updateProduct.QuantityInStock = product.QuantityInStock;
                    _context.Products.Update(updateProduct);
                    await _context.SaveChangesAsync();
                    return Ok(updateProduct);
                }
            }
            catch (DbUpdateConcurrencyException ex) 
            { 
                return BadRequest($"Could not update {ex.Message}");
            }
            return BadRequest("Could not update the product.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if(product == null)
            {
                return NotFound("Sorry there was no product with that id.");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product removed");
        }
    }
}
