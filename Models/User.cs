using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Model
{

    public enum Roles
    {
        Admin, Customer
    }
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        public Roles Role { get; set; }



    }
}
