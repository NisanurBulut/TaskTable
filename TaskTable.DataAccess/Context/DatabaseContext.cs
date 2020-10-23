using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataAccess.Mapping;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TaskTable.db;Cache=Shared");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KullaniciMap());
            modelBuilder.ApplyConfiguration(new CalismaMap());
        }
        public DbSet<KullaniciEntity> Kullanicis { get; set; }
        public DbSet<CalismaEntity> Calismas { get; set; }
    }
}
