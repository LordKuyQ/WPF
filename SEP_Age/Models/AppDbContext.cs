using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Измерения> Измеренияs { get; set; }

    public virtual DbSet<КоординатыПлощади> КоординатыПлощадиs { get; set; }

    public virtual DbSet<КоординатыПрофиля> КоординатыПрофиляs { get; set; }

    public virtual DbSet<Площадь> Площадьs { get; set; }

    public virtual DbSet<Пользователь> Пользовательs { get; set; }

    public virtual DbSet<Проект> Проектs { get; set; }

    public virtual DbSet<Профиль> Профильs { get; set; }

    public virtual DbSet<ПунктыНаблюд> ПунктыНаблюдs { get; set; }

    public virtual DbSet<СписокИзмерений> СписокИзмеренийs { get; set; }

    public virtual DbSet<СписокПлощадей> СписокПлощадейs { get; set; }

    public virtual DbSet<СписокПрофилей> СписокПрофилейs { get; set; }

    public virtual DbSet<СписокПунктов> СписокПунктовs { get; set; }

    public virtual DbSet<СписокУчастников> СписокУчастниковs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=X:\\GIT\\WPF\\SEP_Age\\BD\\BD.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Измерения>(entity =>
        {
            entity.Property(e => e.Id);
        });

        modelBuilder.Entity<КоординатыПлощади>(entity =>
        {
            entity.HasOne(d => d.IdПлощадиNavigation)
                  .WithMany(p => p.КоординатыПлощадиs)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<КоординатыПрофиля>(entity =>
        {
            entity.HasOne(d => d.IdПлощадиNavigation)
                  .WithMany(p => p.КоординатыПрофиляs)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Площадь>(entity =>
        {
            entity.Property(e => e.Id);
        });

        modelBuilder.Entity<Пользователь>(entity =>
        {
            entity.Property(e => e.Id);
        });

        modelBuilder.Entity<Проект>(entity =>
        {
            entity.Property(e => e.Id);
        });

        modelBuilder.Entity<Профиль>(entity =>
        {
            entity.Property(e => e.Id);
        });

        modelBuilder.Entity<ПунктыНаблюд>(entity =>
        {
            entity.Property(e => e.Id);
        });

        modelBuilder.Entity<СписокИзмерений>(entity =>
        {
            entity.HasOne(d => d.IdИзмеренияNavigation)
                  .WithMany(p => p.СписокИзмеренийs)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdПунктаNavigation)
                  .WithMany(p => p.СписокИзмеренийs)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<СписокПлощадей>(entity =>
        {
            entity.HasOne(d => d.IdПлощадиNavigation)
                  .WithMany(p => p.СписокПлощадейs)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdПроектаNavigation)
                  .WithMany(p => p.СписокПлощадейs)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<СписокПрофилей>(entity =>
        {
            entity.HasOne(d => d.IdПлощадиNavigation)
                  .WithMany(p => p.СписокПрофилейs)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdПрофиляNavigation)
                  .WithMany(p => p.СписокПрофилейs)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<СписокПунктов>(entity =>
        {
            entity.HasOne(d => d.IdПрофиляNavigation)
                  .WithMany(p => p.СписокПунктовs)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdПунктаNavigation)
                  .WithMany(p => p.СписокПунктовs)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<СписокУчастников>(entity =>
        {
            entity.HasOne(d => d.IdПользователяNavigation)
                  .WithMany(p => p.СписокУчастниковs)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdПроектаNavigation)
                  .WithMany(p => p.СписокУчастниковs)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
