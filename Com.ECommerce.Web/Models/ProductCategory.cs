using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Com.ECommerce.Web.Models
{
    /// <summary>
    /// Product Categories -> Electronics Items, 
    /// </summary>
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ValidateNever]
        public virtual ICollection<ProductSubCategory> ProductSubCategories { get; set; }
    }
}
