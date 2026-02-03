using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.DTO;
using OrderManagementSystem.Migrations;
using OrderManagementSystem.Model;
using OrderManagementSystem.Models;
using System.Net.Http.Headers;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        ORcontext context;
        public OrderController(ORcontext _context)
        {

            context = _context;
        }
        [HttpGet]
        [Authorize(Roles= "Admin")]
        public ActionResult<List<OrderDTO>> GetOrders()
        {
            var orderDTOs = context.Order
                .Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    TotalAmount = o.TotalAmount
                    
                })
                .ToList();

            return Ok(orderDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            Order order = context.Order.FirstOrDefault(x => x.OrderId == id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return Ok(order);

        }



        [HttpPost]
        public ActionResult<List<OrderDTO>> createOrder (Order order)
        {
            context.Order.Add(order);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }
        [HttpPut("{id}")]
        [Authorize (Roles = "Admin") ]
        public IActionResult updateOrder (int id ,Order order) 
            {
            Order order1 = context.Order.FirstOrDefault(x =>x.OrderId == id);
            if (order1 == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            order1.OrderDate = order.OrderDate;
            order1.OrderItem = order.OrderItem;
            order1.PaymentMethod = order.PaymentMethod;
            order1.Status = order.Status;
            order1.TotalAmount = order.TotalAmount;
            context.SaveChanges();
            return Ok();


        }
    }

}
