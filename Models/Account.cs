using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Account: IdentityUser
    {

        public string Frist { get; set; }
        public string Last { get; set; }

        [Required, Phone]
        public string Phone { get; set; }
        public float Age { get; set; }
    }
}
