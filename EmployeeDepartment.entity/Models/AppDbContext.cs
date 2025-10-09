using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartment.entity.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department>Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>()
                 .HasOne(e => e.Department)
                 .WithMany(e => e.Employees)
                 .HasForeignKey(e => e.DepartmentId);

            var adminRoleId = "role-admin-id";
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id=adminRoleId,
                    Name="Admin",
                    NormalizedName="ADMIN"
                }
                );
            var adminUserId = "user-admin-id";
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id= adminUserId,
                Email="admin@gmail.com",
                NormalizedEmail="ADMIN@GMAIL.COM",
                EmailConfirmed=true,
                SecurityStamp=Guid.NewGuid().ToString("D")

            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");
            builder.Entity<IdentityUser>().HasData(adminUser);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                });

        }
    }
}
