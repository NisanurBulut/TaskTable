using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataAccess.Mapping;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Context
{
    public class DatabaseContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TaskTable.db;Cache=Shared");
            // IdentityDbContext içerisinde yeniden yorumlanabilmesi için
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            // IdentityDbContext içerisinde yeniden yorumlanabilmesi için
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskEntity> Urgencies { get; set; }
    }
}
