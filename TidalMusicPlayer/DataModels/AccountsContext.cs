using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidalMusicPlayer.DataModels
{
    class AccountsContext : DbContext
    {
        public AccountsContext()
        {
           
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=.\tidaldata.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User {ID = -1, Password = "12345678", Username = "andrewjobel"}
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
