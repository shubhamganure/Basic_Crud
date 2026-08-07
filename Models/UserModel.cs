using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic_Crud
{
    [Table("Users_Shubham")]
    public class UserModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        [MaxLength(50)]
        public string userName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string email { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string mobile { get; set; } = string.Empty;
        [MaxLength(50)]
        public string password { get; set; } = string.Empty;
        [MaxLength(20)]
        public string role { get; set; } = string.Empty;

    }

    public class LoginModel
    {
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

     public class UpdatePasswordModel
    {
        public int userId { get; set; }
        public string password { get; set; } = string.Empty;
        public string newPassword { get; set; } = string.Empty;
    }


}
