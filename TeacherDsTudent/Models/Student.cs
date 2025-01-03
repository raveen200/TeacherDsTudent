using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherDsTudent.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int TeacherID { get; set; }
        [ForeignKey("TeacherID")]
        [ValidateNever]
        public Teacher Teacher { get; set; }
    }
}
