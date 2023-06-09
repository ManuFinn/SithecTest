﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

#nullable disable

namespace Test.Models
{
    public partial class testdbContext : DbContext
    {
        public testdbContext()
        {
        }

        public testdbContext(DbContextOptions<testdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Humanotable> Humanotable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;database=testdb;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.10.1-mariadb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1");

            modelBuilder.Entity<Humanotable>(entity =>
            {
                entity.ToTable("humanotable");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Altura).HasColumnType("int(5)");

                entity.Property(e => e.Edad).HasColumnType("int(3)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Peso).HasColumnType("int(5)");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
