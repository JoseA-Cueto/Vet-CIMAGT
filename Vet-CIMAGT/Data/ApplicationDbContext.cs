using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Vet_CIMAGT.Core.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Vet_CIMAGT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
