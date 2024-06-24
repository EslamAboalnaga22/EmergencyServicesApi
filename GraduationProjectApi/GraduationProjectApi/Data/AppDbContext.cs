using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Person> People { get; set; }
        public DbSet<Blood> Bloods { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Hotline> Hotlines { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
