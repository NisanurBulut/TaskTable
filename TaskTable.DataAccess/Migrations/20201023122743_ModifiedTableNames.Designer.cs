﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskTable.DataAccess.Context;

namespace TaskTable.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201023122743_ModifiedTableNames")]
    partial class ModifiedTableNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("TaskTable.Entity.Concrete.CalismaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(150);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<bool>("Durum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("tCalisma","dbo");
                });

            modelBuilder.Entity("TaskTable.Entity.Concrete.KullaniciEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(150);

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("tKullanici","dbo");
                });

            modelBuilder.Entity("TaskTable.Entity.Concrete.CalismaEntity", b =>
                {
                    b.HasOne("TaskTable.Entity.Concrete.KullaniciEntity", "Kullanici")
                        .WithMany("Calismalar")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
