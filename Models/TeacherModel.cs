using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basic_Crud
{
    [Table("teacher_shubham")]
    public class TeacherModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teacherId { get; set; }
        [Required]
        [MaxLength(50)]
        public string teacherName { get; set; } = string.Empty;
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string mobile { get; set; } = string.Empty;
        [MaxLength(100)]
        public string email { get; set; } = string.Empty;
        [MaxLength(100)]
        public string city { get; set; } = string.Empty;

    }
}
