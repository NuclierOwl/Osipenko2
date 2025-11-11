using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OsipenkoN.Date;

namespace OsipenkoN.Conect;

public partial class bdBetka : DbContext
{
    public bdBetka()
    {
    }

    public bdBetka(DbContextOptions<bdBetka> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Produkt> Produkts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    public virtual DbSet<Zakazciki> Zakazcikis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=lorksipt.ru:5432;Database=db512;User Id=user512; Password=95168");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("material");

            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Id)
                .HasColumnType("character varying")
                .HasColumnName("id");
            entity.Property(e => e.Izmerenie)
                .HasColumnType("character varying")
                .HasColumnName("izmerenie");
            entity.Property(e => e.Kolichestvo)
                .HasColumnType("character varying")
                .HasColumnName("kolichestvo");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Produkt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("produkt");

            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Izmerenie)
                .HasColumnType("character varying")
                .HasColumnName("izmerenie");
            entity.Property(e => e.Kolichestvo)
                .HasColumnType("character varying")
                .HasColumnName("kolichestvo");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("users");

            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.Pasword)
                .HasColumnType("character varying")
                .HasColumnName("pasword");
            entity.Property(e => e.Role).HasColumnType("character varying");
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("zakaz");

            entity.Property(e => e.Cena)
                .HasColumnType("character varying")
                .HasColumnName("cena");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Izmerenie)
                .HasColumnType("character varying")
                .HasColumnName("izmerenie");
            entity.Property(e => e.KolVo)
                .HasColumnType("character varying")
                .HasColumnName("kol-vo");
            entity.Property(e => e.Produkt)
                .HasColumnType("character varying")
                .HasColumnName("produkt");
            entity.Property(e => e.Summa)
                .HasColumnType("character varying")
                .HasColumnName("summa");
        });

        modelBuilder.Entity<Zakazciki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("zakazciki");

            entity.Property(e => e.Addres)
                .HasColumnType("character varying")
                .HasColumnName("addres");
            entity.Property(e => e.Buyer).HasColumnName("buyer");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Inn)
                .HasColumnType("character varying")
                .HasColumnName("inn");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Salesman).HasColumnName("salesman");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
