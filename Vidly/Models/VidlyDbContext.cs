using System.Data.Entity;
using Vidly.Models;

namespace Vidly
{
    public class VidlyDbContext : DbContext
    {
        public VidlyDbContext() : base("name=VidlyDbContext")
        {
        }


        public DbSet<Customer> Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}