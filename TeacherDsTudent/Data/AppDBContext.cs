using Microsoft.EntityFrameworkCore;
using TeacherDsTudent.Models;

namespace TeacherDsTudent.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
       
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
           .HasMany(t => t.Students)
           .WithOne(s => s.Teacher)
           .HasForeignKey(s => s.TeacherID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherID = 1, TeacherName = "Teacher 1" },
                new Teacher { TeacherID = 2, TeacherName = "Teacher 2" }
            );
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentID = 1, StudentName = "Student 1", TeacherID = 1 },
                new Student { StudentID = 2, StudentName = "Student 2", TeacherID = 1 },
                new Student { StudentID = 3, StudentName = "Student 3", TeacherID = 2 },
                new Student { StudentID = 4, StudentName = "Student 4", TeacherID = 2 }
            );
        }



    }
}
