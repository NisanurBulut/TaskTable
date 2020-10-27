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
            optionsBuilder.UseSqlite("Data Source=../TaskTable.DataAccess/TaskTable.db;Cache=Shared");
            // IdentityDbContext içerisinde yeniden yorumlanabilmesi için
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            // IdentityDbContext içerisinde yeniden yorumlanabilmesi için
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UrgencyEntity> Urgencies { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
    }
}
