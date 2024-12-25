using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITPWorkshop.Models;
using Microsoft.EntityFrameworkCore;

namespace ITPWorkshop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity => {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).ValueGeneratedOnAdd();
            });
        }
    }
}