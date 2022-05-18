using Microsoft.EntityFrameworkCore;
using dotnet_api_inside.Models;

namespace dotnet_api_inside.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Operator> Operators { get; set; } = null!;
    }
}
