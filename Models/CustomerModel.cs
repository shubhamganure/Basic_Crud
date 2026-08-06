using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic_Crud
{
    [Table("eCustomerShubham")]
    public class CustomerModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int custId { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string email { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string mobile { get; set; } = string.Empty;

    }

    [Table("eCustomerAddressShubham")]
    public class CustomerAddressModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int addressId { get; set; }
        [Required]
        public int custId { get; set; }
        [MaxLength(1000)]
        public string address { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string city { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string title { get; set; } = string.Empty;
        [MaxLength(6)]
        public string pincode { get; set; } = string.Empty;

    }

    public class CustomerAddressViewModel
    {
        public int custId { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string mobile { get; set; } = string.Empty;
        public List<CustomerAddressModel> addresses { get; set; } = new List<CustomerAddressModel>();
    }
}
