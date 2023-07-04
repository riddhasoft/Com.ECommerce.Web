using System.ComponentModel.DataAnnotations;

namespace Com.ECommerce.Web.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
