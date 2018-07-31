using MediatrCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatrCQRS.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
