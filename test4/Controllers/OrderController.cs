using Microsoft.AspNetCore.Http;
using test4.DTOs;
using test4.Entities;
using test4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace test4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Datacontext _context;
        public OrderController(Datacontext context)
        {
            _context = context;
        }
        [HttpGet("get-all-orders")]
        public async Task<ActionResult> GetAllOrder()
        {
            try
            {
                List<Order> orders = await _context.Orders.OrderByDescending(s => s.Id).ToListAsync();
                List<OrderDTO> orderDTOs = new List<OrderDTO>();
                foreach (var order in orders)
                {
                    orderDTOs.Add(new OrderDTO
                    {
                        Id = order.Id,
                        ItemCode = order.ItemCode,
                        ItemName = order.ItemName,
                        ItemQty = order.ItemQty,
                        OrderDelivery = order.OrderDelivery,
                        OrderAddress = order.OrderAddress,
                        PhoneNumber = order.PhoneNumber,
                    });
                }
                return Ok(orderDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateOrderModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order order = new Order
                    {
                        ItemCode = model.ItemCode,
                        ItemName = model.ItemName,
                        ItemQty = model.ItemQty,
                        OrderDelivery = model.OrderDelivery,
                        OrderAddress = model.OrderAddress,
                        PhoneNumber = model.PhoneNumber,
                    };

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                    return Created($"get-by-id?id={order.Id}", new OrderDTO
                    {
                        Id = order.Id,
                        ItemCode = order.ItemCode,
                        ItemName = order.ItemName,
                        ItemQty = order.ItemQty,
                        OrderDelivery = order.OrderDelivery,
                        OrderAddress = order.OrderAddress,
                        PhoneNumber = order.PhoneNumber,
                    });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            var msgs = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
            return BadRequest(string.Join(" | ", msgs));
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order orderExist = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(e => e.Id == model.Id);

                    if (orderExist != null)
                    {
                        Order order = new Order
                        {
                            Id = model.Id,
                            ItemCode = orderExist.ItemCode,
                            ItemName = orderExist.ItemName,
                            ItemQty = orderExist.ItemQty,
                            OrderDelivery = model.OrderDelivery,
                            OrderAddress = model.OrderAddress,
                            PhoneNumber = orderExist.PhoneNumber,
                        };

                        if (order != null)
                        {
                            _context.Orders.Update(order);
                            await _context.SaveChangesAsync();
                            return NoContent();
                        }

                        return NotFound();
                    }
                    else
                    {
                        return NotFound();
                    }



                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
            return BadRequest();
        }
    }
}
