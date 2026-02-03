using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Model;

namespace OrderManagementSystem.Models
{
    public class ORcontext: IdentityDbContext<Account>
    {
        public DbSet<Customer> Customer {  get; set; }
        public DbSet<Product> Product {  get; set; }
        public DbSet<Order> Order {  get; set; }
        public DbSet<OrderItem> orderItem {  get; set; }
        public DbSet<User> customers {  get; set; }
        public DbSet<Invoice> Invoice {  get; set; }

        public ORcontext(DbContextOptions<ORcontext> options) : base(options) {

            }


    }
}
