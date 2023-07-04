using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Com.ECommerce.Web.Models
{
    public class ProductSubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        [ValidateNever]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
