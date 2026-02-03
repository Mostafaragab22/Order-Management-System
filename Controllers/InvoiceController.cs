using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Model;
using OrderManagementSystem.Models;


namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        ORcontext context;
        public InvoiceController(ORcontext _context)
        {
            context = _context;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetALLInvoice()
        {
            List<Invoice> invoice = context.Invoice.ToList();
            return Ok(invoice);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetInvoiceById(int id)
        {
            Invoice invoice = context.Invoice.FirstOrDefault(x => x.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound($"Invoice with ID {id} not found.");
            }
            return Ok(invoice);
        }

    }
}
