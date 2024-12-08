using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.CustomerOrders)
                .ThenInclude(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Products)
                .ToListAsync();
            return Ok(orders);
        }
        [HttpGet("order-details/{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.CustomerOrders)
                .ThenInclude(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Products)
                .FirstOrDefaultAsync(o => o.OrderId == id);
            if (order == null) 
            {
                return NotFound("There was no order with that id.");
            }
            return Ok(order);
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Orders ord = new Orders
                    {
                        OrderDate = order.OrderDate,
                        TotalAmount = order.TotalAmount,
                        DiscountAmount = order.DiscountAmount,
                        NetAmount = order.NetAmount,
                        PaymentMethod = order.PaymentMethod,
                        PaymentStatus = order.PaymentStatus,
                        BillingAddress = order.BillingAddress,
                        Notes = order.Notes
                    };
                    _context.Orders.Add(ord);
                    await _context.SaveChangesAsync();
                    return Ok("Order created");
                }
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
            return BadRequest("Could not create order.");
        }

        [HttpPut("update-order/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDTO order)
        {
            try
            {
                var or = _context.Orders
                     .Include(o => o.CustomerOrders)
                     .ThenInclude(o => o.Customer)
                     .Include(o => o.OrderItems)
                     .ThenInclude(o => o.Products)
                    .FirstOrDefault(o => o.OrderId == id);
                if(or == null)
                {
                    return NotFound("Order with that id could not be found.");
                }
                if(ModelState.IsValid)
                {
                    order.OrderDate = or.OrderDate;
                    order.TotalAmount = or.TotalAmount;
                    order.DiscountAmount = or.DiscountAmount;
                    order.PaymentMethod = or.PaymentMethod;
                    order.NetAmount = or.NetAmount;
                    order.PaymentStatus = or.PaymentStatus;
                    order.ShippingAddress = or.ShippingAddress;
                    order.BillingAddress = or.BillingAddress;
                    order.Notes = or.Notes;
                    _context.Orders.Update(or);
                    await _context.SaveChangesAsync();
                    return Ok($"The order with the id: {id} was updated");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Could not update order.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound("Sorry there was no order with that id..");
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok("Item removed");
        }
    }
}
