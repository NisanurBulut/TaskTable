using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Mapping
{
    public class KullaniciMap : IEntityTypeConfiguration<KullaniciEntity>
    {
        public void Configure(EntityTypeBuilder<KullaniciEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Ad).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Soyad).IsRequired().HasMaxLength(50);
            builder.Property(a => a.DogumTarihi).IsRequired();
            builder.Property(a => a.Eposta).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Telefon).IsRequired().HasMaxLength(11);
            builder.HasMany(a => a.Calismalar).WithOne(a=>a.Kullanici)
                .HasForeignKey(a=>a.KullaniciId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
