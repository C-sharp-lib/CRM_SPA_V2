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
    public class OrderItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItems>>> GetOrderItems()
        {
            var items = await _context.OrderItems.ToListAsync();
            return Ok(items);
        }

        [HttpGet("order-item-details/{id}")]
        public async Task<ActionResult> GetOrderItem(int id)
        {
            var item = await _context.OrderItems
                .Include(o => o.Products)
                .Include(o => o.Order)
                .ThenInclude(o => o.CustomerOrders)
                .ThenInclude(o => o.Customer)
                .SingleOrDefaultAsync(o => o.OrderItemId == id);
            if (item == null)
            {
                return NotFound("There is not a order-item by that id.");
            }
            return Ok(item);
        }

        [HttpPost("create-order-item")]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemDTO item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrderItems order = new OrderItems
                    {
                        ProductId = item.ProductId,
                        OrderId = item.OrderId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalPrice = item.TotalPrice
                    };
                    
                    _context.OrderItems.Add(order);
                    await _context.SaveChangesAsync();
                    return Ok("Order Item Created!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Could not create order item.");
        }

        [HttpPut("update-order-item{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, [FromBody] OrderItemDTO item)
        {
            try
            {
                var updateOrderItem = await _context.OrderItems.FirstOrDefaultAsync(p => p.OrderItemId == id);
                if (updateOrderItem == null)
                {
                    return NotFound("Could not find the product.");
                }
                if (ModelState.IsValid)
                {
                    item.ProductId = updateOrderItem.ProductId;
                    item.OrderId = updateOrderItem.OrderId;   
                    item.Quantity = updateOrderItem.Quantity;
                    item.UnitPrice = updateOrderItem.UnitPrice;
                    item.TotalPrice = updateOrderItem.TotalPrice;

                    _context.OrderItems.Update(updateOrderItem);
                    await _context.SaveChangesAsync();
                    return Ok(updateOrderItem);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest($"Could not update {ex.Message}");
            }
            return BadRequest("Could not update the product.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var item = await _context.OrderItems.FirstOrDefaultAsync(p => p.OrderItemId== id);
            if (item == null)
            {
                return NotFound("Sorry there was no product with that id.");
            }
            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
            return Ok("Item removed");
        }
    }
}
