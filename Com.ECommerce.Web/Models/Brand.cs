using System.ComponentModel.DataAnnotations;

namespace Com.ECommerce.Web.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
    }
}
