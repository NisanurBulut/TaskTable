using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Mapping
{
    public class NotificationMap : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.ToTable("tNotification", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(I => I.Description).IsRequired().HasMaxLength(100);
            builder.HasOne(I => I.AppUser).WithMany(a => a.Notifications).HasForeignKey(a => a.AppUserId);
        }
    }
}
