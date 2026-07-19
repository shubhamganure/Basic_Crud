using System;

namespace Basic_Crud
{
    public class Student
    {
        public int studentId { get; set; }
        public string studentName { get; set; } = string.Empty;

        public string studentCity { get; set; } = string.Empty;
        public bool isActive { get; set; }


    }
}
