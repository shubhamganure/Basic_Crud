using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic_Crud
{
    [Table("bankAccountShubham")]
    public class BankAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int accountId { get; set; }
        [Required]
        [MaxLength(20)]
        public string accountNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string accountHolderName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string accountType { get; set; } = string.Empty;
        [Required]
        public decimal balance { get; set; }
        [Required]
        public bool isActive { get; set; }
    }
}
