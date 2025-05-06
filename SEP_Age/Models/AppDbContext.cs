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
            entity.HasMany(e => e.СписокИзмеренийs)
                  .WithOne(e => e.IdИзмеренияNavigation)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<КоординатыПлощади>(entity =>
        {
            entity.HasOne(d => d.IdПлощадиNavigation)
                  .WithMany(p => p.КоординатыПлощадиs)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<КоординатыПрофиля>(entity =>
        {
            entity.HasOne(d => d.IdПлощадиNavigation)
                  .WithMany(p => p.КоординатыПрофиляs)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Площадь>(entity =>
        {
            entity.HasMany(p => p.СписокПлощадейs)
                  .WithOne(d => d.IdПлощадиNavigation)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(p => p.СписокПрофилейs)
                  .WithOne(d => d.IdПлощадиNavigation)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Пользователь>(entity =>
        {
            entity.HasMany(p => p.СписокУчастниковs)
                  .WithOne(d => d.IdПользователяNavigation)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Проект>(entity =>
        {
            entity.HasMany(p => p.СписокПлощадейs)
                  .WithOne(d => d.IdПроектаNavigation)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(p => p.СписокУчастниковs)
                  .WithOne(d => d.IdПроектаNavigation)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Профиль>(entity =>
        {
            entity.HasMany(p => p.СписокПрофилейs)
                  .WithOne(d => d.IdПрофиляNavigation)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(p => p.СписокПунктовs)
                  .WithOne(d => d.IdПрофиляNavigation)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ПунктыНаблюд>(entity =>
        {
            entity.HasMany(p => p.СписокИзмеренийs)
                  .WithOne(d => d.IdПунктаNavigation)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(p => p.СписокПунктовs)
                  .WithOne(d => d.IdПунктаNavigation)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<СписокИзмерений>(entity =>
        {
            entity.HasOne(d => d.IdИзмеренияNavigation)
                  .WithMany(p => p.СписокИзмеренийs)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.IdПунктаNavigation)
                  .WithMany(p => p.СписокИзмеренийs)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<СписокПлощадей>(entity =>
        {
            entity.HasOne(d => d.IdПлощадиNavigation)
                  .WithMany(p => p.СписокПлощадейs)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.IdПроектаNavigation)
                  .WithMany(p => p.СписокПлощадейs)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<СписокПрофилей>(entity =>
        {
            entity.HasOne(d => d.IdПлощадиNavigation)
                  .WithMany(p => p.СписокПрофилейs)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.IdПрофиляNavigation)
                  .WithMany(p => p.СписокПрофилейs)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<СписокПунктов>(entity =>
        {
            entity.HasOne(d => d.IdПрофиляNavigation)
                  .WithMany(p => p.СписокПунктовs)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.IdПунктаNavigation)
                  .WithMany(p => p.СписокПунктовs)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<СписокУчастников>(entity =>
        {
            entity.HasOne(d => d.IdПользователяNavigation)
                  .WithMany(p => p.СписокУчастниковs)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.IdПроектаNavigation)
                  .WithMany(p => p.СписокУчастниковs)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
