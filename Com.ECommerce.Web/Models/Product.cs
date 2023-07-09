using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.ECommerce.Web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public ICollection<ProductCategory>? ProductCategoryId { get; set; }
        public ICollection<ProductSubCategory>? ProductSubCategoryId { get; set; }
        public ICollection<Brand>? BrandId { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; }

        [Display(Name ="Please choose the Product Photo")]
        public string ProductPhoto { get; set; }
        public string Description { get; set; }


        [ValidateNever]
        public virtual ICollection<ProductImages> ProductImages { get; set; }
    }


    public class ProductImages
    {
        public int Id { get; set; }
        public string ProductPhoto { get; set; }
        public int ProductId { get; set; }
    }
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [DisplayName("Product Category Name")]
        public ICollection<ProductCategory>? ProductCategoryId { get; set; }
        [DisplayName("Sub Category Name")]
        public ICollection<ProductSubCategory>? ProductSubCategoryId { get; set; }

        [DisplayName("Product Brand Name")]

        public ICollection<Brand>? BrandId { get; set; }

       
        [Range(0, 5)]
        public int Rating { get; set; }

        [Display(Name = "Please choose the Product Photo")]
        public IFormFile ProductPhoto { get; set; }
        public string Description { get; set; }


    }
}
