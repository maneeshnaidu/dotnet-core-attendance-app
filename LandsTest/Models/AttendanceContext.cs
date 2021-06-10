using Microsoft.EntityFrameworkCore;

namespace LandsTest.Models
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext(DbContextOptions<AttendanceContext> options)
            : base(options)
        {

        }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Employee> Employees {get; set; }

    }
}