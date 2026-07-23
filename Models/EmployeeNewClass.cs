using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic_Crud
{
    [Table("employee_new_shubham")]
    public class EmployeeNewClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empId { get; set; }
        [Required]
        [MaxLength(100)]
        public string empName { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string empMobile { get; set; } = string.Empty;
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string empEmail { get; set; } = string.Empty;
        [MaxLength(100)]
        public string empCity { get; set; } = string.Empty;
        [MaxLength(6)]
        public string empPincode { get; set; } = string.Empty;
        public bool isActive { get; set; }
        public DateTime createdDate { get; set; }

    }
}
