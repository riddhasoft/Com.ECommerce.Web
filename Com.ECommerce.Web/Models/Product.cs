using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.ECommerce.Web.Models
{
    /// <summary>
    /// Samsung, Applce mobiles, Tabs, 
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public int BrandId { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; }

        [Display(Name = "Please choose the Product Photo")]
        public string? ProductPhoto { get; set; }

        public string? Description { get; set; }
        public int ProductSubCategoryId { get; set; }
        [ValidateNever]
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        [ValidateNever]
        [DisplayName("Product Brand")]
        public virtual Brand Brand { get; set; }

        [ValidateNever]
        public virtual ICollection<ProductImages> ProductImages { get; set; }
    }


    public class ProductImages
    {
        public int Id { get; set; }
        public string ProductPhoto { get; set; }
        public int ProductId { get; set; }
        [ValidateNever]
        public virtual Product Product { get; set; }
    }

}
