using CialMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CialMVC.Context
{
    public class CialDbContext : IdentityDbContext
    {
        public CialDbContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Worker> Workers { get; set; } 
        public DbSet<WorkerSM> WorkerSMs { get; set; }
    }
}
