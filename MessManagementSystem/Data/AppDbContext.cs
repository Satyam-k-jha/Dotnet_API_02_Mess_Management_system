using Microsoft.EntityFrameworkCore;
using MessManagementSystem.Models;
using MessManagementSystem.Models.Domain;
namespace MessManagementSystem.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId);
        }
    }
}
