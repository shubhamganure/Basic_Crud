using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic_Crud
{
    [Table("emp_table_shubham")]
    public class EmployeeMasterModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Employee name cannot exceed 50 characters.")]
        public string empName { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Employee code cannot exceed 10 characters.")]
        public string empMobile { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "Employee email cannot exceed 100 characters.")]
        public string empEmail { get; set; } = string.Empty;

    }

    [Table("emp_identity_details_shubham")]
    public class EmployeeIdentityDetailsModel
    {
        [Key]
        public int empId { get; set; }
        [MaxLength(50, ErrorMessage = "Aadhar card number cannot exceed 50 characters.")]
        public string aadharCardNo { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "PAN card number cannot exceed 50 characters.")]
        public string panCardNo { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "Driving licence number cannot exceed 50 characters.")]
        public string drivingLicenceNo { get; set; } = string.Empty;
    }

    public class EmployeeMasterDetailsViewModel
    {
        public int empId { get; set; }
        public string empName { get; set; } = string.Empty;
        public string empMobile { get; set; } = string.Empty;
        public string empEmail { get; set; } = string.Empty;
        public string aadharCardNo { get; set; } = string.Empty;
        public string panCardNo { get; set; } = string.Empty;
        public string drivingLicenceNo { get; set; } = string.Empty;
    }
}
