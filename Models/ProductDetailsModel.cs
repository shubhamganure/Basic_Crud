using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic_Crud
{
    [Table("ecom_product_shubham")]
    public class ProductDetailsModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prodId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string prodName { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Short name cannot exceed 10 characters.")]
        public string shortName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Main image URL cannot exceed 100 characters.")]
        public string mainImage { get; set; } = string.Empty;
        [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        public string categoryName { get; set; } = string.Empty;

    }

     [Table("ecom_product_extra_shubham")]
    public class ProductExtraDetailsModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prodExtraDetailId { get; set; }
        [Required]
        public int prodId { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string description { get; set; } = string.Empty;
        public double price { get; set; }
        public double discount { get; set; } 

    }

    public class ProductDetailsViewModel
    {
        public int prodId { get; set; }
        public string prodName { get; set; } = string.Empty;
        public string shortName { get; set; } = string.Empty;
        public string mainImage { get; set; } = string.Empty;
        public string categoryName { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public double price { get; set; }
        public double discount { get; set; } 
    }
}

