using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic_Crud
{
    [Table("locationsShubham")]
    public class Location
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int locationId { get; set; }
        [Required]
        [MaxLength(100)]
        public string cityName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string stateName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string countryName { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string pinCode { get; set; } = string.Empty;

    }

}
