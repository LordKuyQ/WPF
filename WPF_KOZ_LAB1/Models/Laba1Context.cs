using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPF_KOZ_LAB1.Models;

public partial class Laba1Context : DbContext
{
    public Laba1Context()
    {
    }

    public Laba1Context(DbContextOptions<Laba1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Bron> Brons { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Skidka> Skidkas { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    public virtual DbSet<ZakazSkidka> ZakazSkidkas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=X:\\GIT\\WPF_KOZ\\WPF\\WPF_KOZ_LAB1\\BD\\laba1.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bron>(entity =>
        {
            entity.ToTable("bron");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DtBron)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("dt_bron");
            entity.Property(e => e.InvId).HasColumnName("inv_id");

            entity.HasOne(d => d.Inv).WithMany(p => p.Brons)
                .HasForeignKey(d => d.InvId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Fio).HasColumnName("fio");
            entity.Property(e => e.Telefon).HasColumnName("telefon");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("inventory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
        });

        modelBuilder.Entity<Skidka>(entity =>
        {
            entity.ToTable("skidka");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Pers).HasColumnName("pers");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity.ToTable("zakaz");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClentId).HasColumnName("clent_id");
            entity.Property(e => e.InvId).HasColumnName("inv_id");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Clent).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.ClentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Inv).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.InvId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ZakazSkidka>(entity =>
        {
            entity.ToTable("zakaz_skidka");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdSkidka).HasColumnName("id_skidka");
            entity.Property(e => e.IdZakaz).HasColumnName("id_zakaz");

            entity.HasOne(d => d.IdSkidkaNavigation).WithMany(p => p.ZakazSkidkas)
                .HasForeignKey(d => d.IdSkidka)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdZakazNavigation).WithMany(p => p.ZakazSkidkas)
                .HasForeignKey(d => d.IdZakaz)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
