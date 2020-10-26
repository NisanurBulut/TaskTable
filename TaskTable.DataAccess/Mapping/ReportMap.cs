using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.ToTable("tReport", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Description).HasMaxLength(100);
            builder.Property(a => a.Detail).HasMaxLength(100);
            builder.HasOne(a => a.Task).WithMany(a => a.Reports).HasForeignKey(a => a.TaskId);
        }
    }
}
