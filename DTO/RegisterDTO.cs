using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Frist { get; set; }
        public string Last { get; set; }

        [Required, Phone]
        public string Phone { get; set; }
        public float Age { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
