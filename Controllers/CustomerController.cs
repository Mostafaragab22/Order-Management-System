using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.DTO;
using OrderManagementSystem.Model;
using OrderManagementSystem.Models;


namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
     ORcontext context;

      public CustomerController(ORcontext _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult newCustomer(Customer customer)
        {
            context.Customer.Add(customer);
            context.SaveChanges();
            return Ok();

        }
        [HttpGet]
        public ActionResult <List<OrdWithCustDTO>> getCustomer()
        {
            List<Customer> customerList = context.Customer.ToList();
            return Ok(customerList);
        }

       
    }
}
