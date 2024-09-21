using Microsoft.EntityFrameworkCore;
using UM.Domain.Entities;

namespace UM.Domain.EntityFramework
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}