using System.ComponentModel.DataAnnotations;

namespace TeacherDsTudent.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public List<Student> Students { get; set; }
    }
}
