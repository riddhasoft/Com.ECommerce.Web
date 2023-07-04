using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Com.ECommerce.Web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductSubCategoryId { get; set; }
        public int BrandId { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }


        [ValidateNever]
        public virtual ICollection<ProductImages> ProductImages { get; set; }
    }


    public class ProductImages
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}
