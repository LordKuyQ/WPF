using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age.Models
{
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
        {
            //string databasePath = "G:\\6SENESTR\\AGE\\SEP_Age\\SEP_Age\\BD\\Age.db";
            string databasePath = @"X:\GIT\WPF\SEP_Age\SEP_Age\BD\Age.db";
            Console.WriteLine($"Database path: {databasePath}");
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Измерения>(entity =>
            {
                entity.ToTable("Измерения");
                entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.Давление).HasColumnName("давление");
                entity.Property(e => e.Описание).HasColumnName("описание");
            });

            modelBuilder.Entity<КоординатыПлощади>(entity =>
            {
                entity.HasNoKey().ToTable("координаты_площади");
                entity.Property(e => e.IdПлощади).HasColumnName("id_площади");
                entity.Property(e => e.X).HasColumnName("x");
                entity.Property(e => e.Y).HasColumnName("y");
                entity.HasOne(d => d.IdПлощадиNavigation).WithMany().HasForeignKey(d => d.IdПлощади);
            });

            modelBuilder.Entity<КоординатыПрофиля>(entity =>
            {
                entity.HasNoKey().ToTable("координаты_профиля");
                entity.Property(e => e.IdПлощади).HasColumnName("id_площади");
                entity.Property(e => e.X).HasColumnName("x");
                entity.Property(e => e.Y).HasColumnName("y");
                entity.HasOne(d => d.IdПлощадиNavigation).WithMany().HasForeignKey(d => d.IdПлощади);
            });

            modelBuilder.Entity<Площадь>(entity =>
            {
                entity.ToTable("Площадь");
                entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.Координаты).HasColumnName("координаты");
                entity.Property(e => e.Площадь1).HasColumnName("площадь");
            });

            modelBuilder.Entity<Пользователь>(entity =>
            {
                entity.ToTable("Пользователь");
                entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.ТипПользователя).HasColumnName("тип_пользователя");
                entity.Property(e => e.Фио).HasColumnName("ФИО");
                entity.Property(e => e.Телефон).HasColumnName("телефон");
                entity.Property(e => e.Емайл).HasColumnName("емайл");
                entity.Property(e => e.Пароль).HasColumnName("пароль");
            });

            modelBuilder.Entity<Проект>(entity =>
            {
                entity.ToTable("Проект");
                entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.ДатаКонца).HasColumnType("DATE").HasColumnName("дата_конца");
                entity.Property(e => e.ДатаНачала).HasColumnType("DATE").HasColumnName("дата_начала");
                entity.Property(e => e.Цена).HasColumnName("цена");
            });

            modelBuilder.Entity<Профиль>(entity =>
            {
                entity.ToTable("Профиль");
                entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.Высота).HasColumnName("высота");
                entity.Property(e => e.Длина).HasColumnName("длина");
                entity.Property(e => e.Описание).HasColumnName("описание");
            });

            modelBuilder.Entity<ПунктыНаблюд>(entity =>
            {
                entity.ToTable("Пункты_наблюд");
                entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.X).HasColumnName("x");
                entity.Property(e => e.Y).HasColumnName("y");
            });

            modelBuilder.Entity<СписокИзмерений>(entity =>
            {
                entity.HasNoKey().ToTable("список_измерений");
                entity.Property(e => e.IdИзмерения).HasColumnName("id_измерения");
                entity.Property(e => e.IdПункта).HasColumnName("id_пункта");
                entity.HasOne(d => d.IdИзмеренияNavigation).WithMany().HasForeignKey(d => d.IdИзмерения);
                entity.HasOne(d => d.IdПунктаNavigation).WithMany().HasForeignKey(d => d.IdПункта);
            });

            modelBuilder.Entity<СписокПлощадей>(entity =>
            {
                entity.HasNoKey().ToTable("список_площадей");
                entity.Property(e => e.IdПлощади).HasColumnName("id_площади");
                entity.Property(e => e.IdПроекта).HasColumnName("id_проекта");
                entity.HasOne(d => d.IdПлощадиNavigation).WithMany().HasForeignKey(d => d.IdПлощади);
                entity.HasOne(d => d.IdПроектаNavigation).WithMany().HasForeignKey(d => d.IdПроекта);
            });

            modelBuilder.Entity<СписокПрофилей>(entity =>
            {
                entity.HasNoKey().ToTable("список_профилей");
                entity.Property(e => e.IdПлощади).HasColumnName("id_площади");
                entity.Property(e => e.IdПрофиля).HasColumnName("id_профиля");
                entity.HasOne(d => d.IdПлощадиNavigation).WithMany().HasForeignKey(d => d.IdПлощади);
                entity.HasOne(d => d.IdПрофиляNavigation).WithMany().HasForeignKey(d => d.IdПрофиля);
            });

            modelBuilder.Entity<СписокПунктов>(entity =>
            {
                entity.HasNoKey().ToTable("список_пунктов");
                entity.Property(e => e.IdПрофиля).HasColumnName("id_профиля");
                entity.Property(e => e.IdПункта).HasColumnName("id_пункта");
                entity.HasOne(d => d.IdПрофиляNavigation).WithMany().HasForeignKey(d => d.IdПрофиля);
                entity.HasOne(d => d.IdПунктаNavigation).WithMany().HasForeignKey(d => d.IdПункта);
            });

            modelBuilder.Entity<СписокУчастников>(entity =>
            {
                entity.HasNoKey().ToTable("список_участников");
                entity.Property(e => e.IdПользователя).HasColumnName("id_пользователя");
                entity.Property(e => e.IdПроекта).HasColumnName("id_проекта");
                entity.HasOne(d => d.IdПользователяNavigation).WithMany().HasForeignKey(d => d.IdПользователя);
                entity.HasOne(d => d.IdПроектаNavigation).WithMany().HasForeignKey(d => d.IdПроекта);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
