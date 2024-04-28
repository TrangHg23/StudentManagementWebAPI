using Microsoft.EntityFrameworkCore;
using StudentManagement.Entities;

namespace StudentManagement.DbContexts
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
