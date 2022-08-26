using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>options):base(options)
        {
                    
        }
        DbSet<Address> _addresses { get; set; }
        DbSet<Student> Students { get; set; }   
    }
}
