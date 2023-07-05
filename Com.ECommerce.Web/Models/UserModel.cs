using System.ComponentModel.DataAnnotations;

namespace Com.ECommerce.Web.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
