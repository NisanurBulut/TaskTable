using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Mapping
{
    public class UrgencyMap : IEntityTypeConfiguration<UrgencyEntity>
    {
        public void Configure(EntityTypeBuilder<UrgencyEntity> builder)
        {
            builder.ToTable("tUrgency", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a=>a.Description).HasMaxLength(100);
        }
    }
}
