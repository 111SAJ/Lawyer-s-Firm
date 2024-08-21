using LawyersFirm.Models;
using Microsoft.EntityFrameworkCore;

namespace LawyersFirm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //Model
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasNoKey();
        }
    }
}
