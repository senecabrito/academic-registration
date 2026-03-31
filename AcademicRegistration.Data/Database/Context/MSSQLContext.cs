using AcademicRegistration.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademicRegistration.Data.Database.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
