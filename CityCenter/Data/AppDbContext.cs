using System;
using System.Collections.Generic;
using CityCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace CityCenter.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Аренда> Арендаs { get; set; }

    public virtual DbSet<Арендаторы> Арендаторыs { get; set; }

    public virtual DbSet<ВидДеятельности> ВидДеятельностиs { get; set; }

    public virtual DbSet<Мероприятия> Мероприятияs { get; set; }

    public virtual DbSet<НазначенияПомещений> НазначенияПомещенийs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<Помещения> Помещенияs { get; set; }

    public virtual DbSet<Роли> Ролиs { get; set; }
    public DbSet<SvgRoom> SvgRooms { get; set; }
    public DbSet<ЗаявкаНаАренду> ЗаявкиНаАренду { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MYCOMPUTER\\SQLEXPRESS;Database=CityCenter;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Аренда>(entity =>
        {
            entity.HasKey(e => e.IdАренды).HasName("PK__Аренда__1475B6F76682E109");

            entity.ToTable("Аренда");

            entity.HasIndex(e => new { e.IdПомещения, e.ДатаНачала, e.ДатаОкончания }, "UQ_УникальнаяАренда").IsUnique();

            entity.Property(e => e.IdАренды).HasColumnName("ID_Аренды");
            entity.Property(e => e.IdАрендатора).HasColumnName("ID_Арендатора");
            entity.Property(e => e.IdПомещения).HasColumnName("ID_Помещения");
            entity.Property(e => e.ДатаНачала).HasColumnType("date");
            entity.Property(e => e.ДатаОкончания).HasColumnType("date");
            entity.Property(e => e.Цель).HasMaxLength(50);

            entity.HasOne(d => d.IdАрендатораNavigation).WithMany(p => p.Арендаs)
                .HasForeignKey(d => d.IdАрендатора)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Аренда__ID_Аренд__60A75C0F");

            entity.HasOne(d => d.IdПомещенияNavigation).WithMany(p => p.Арендаs)
                .HasForeignKey(d => d.IdПомещения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Аренда__ID_Помещ__5FB337D6");


        });

        modelBuilder.Entity<Арендаторы>(entity =>
        {
            entity.HasKey(e => e.IdАрендатора).HasName("PK__Арендато__2CDA605951F51B5C");

            entity.ToTable("Арендаторы");

            entity.Property(e => e.IdАрендатора).HasColumnName("ID_Арендатора");
            entity.Property(e => e.IdПользователя).HasColumnName("ID_Пользователя");
            entity.Property(e => e.ДатаНачалаДоговора).HasColumnType("date");
            entity.Property(e => e.ДатаОкончанияДоговора).HasColumnType("date");
            entity.Property(e => e.Имя).HasMaxLength(255);
            entity.Property(e => e.КонтактнаяИнформация).HasMaxLength(255);
            entity.Property(e => e.НомерДоговора).HasMaxLength(50);
            entity.Property(e => e.Статус).HasMaxLength(50);

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Арендаторыs)
                .HasForeignKey(d => d.IdПользователя)
                .HasConstraintName("FK__Арендатор__ID_По__5535A963");

            entity.HasMany(d => d.IdДеятельностиs).WithMany(p => p.IdАрендатораs)
                .UsingEntity<Dictionary<string, object>>(
                    "ДеятельностьАрендатора",
                    r => r.HasOne<ВидДеятельности>().WithMany()
                        .HasForeignKey("IdДеятельности")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Деятельно__ID_Де__59063A47"),
                    l => l.HasOne<Арендаторы>().WithMany()
                        .HasForeignKey("IdАрендатора")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Деятельно__ID_Ар__5812160E"),
                    j =>
                    {
                        j.HasKey("IdАрендатора", "IdДеятельности").HasName("PK__Деятельн__AA9948EF409EA385");
                        j.ToTable("ДеятельностьАрендатора");
                    });
        });

        modelBuilder.Entity<ВидДеятельности>(entity =>
        {
            entity.HasKey(e => e.IdДеятельности).HasName("PK__ВидДеяте__64328B69758C284C");

            entity.ToTable("ВидДеятельности");

            entity.Property(e => e.IdДеятельности).HasColumnName("ID_Деятельности");
            entity.Property(e => e.Название).HasMaxLength(50);
        });

        modelBuilder.Entity<Мероприятия>(entity =>
        {
            entity.HasKey(e => e.IdМероприятия).HasName("PK__Мероприя__64E4CF809C75D0A0");

            entity.ToTable("Мероприятия");

            entity.Property(e => e.IdМероприятия).HasColumnName("ID_Мероприятия");
            entity.Property(e => e.IdПомещения).HasColumnName("ID_Помещения");
            entity.Property(e => e.ДатаМероприятия).HasColumnType("date");
            entity.Property(e => e.Название).HasMaxLength(255);
            entity.Property(e => e.Описание).HasMaxLength(1000);

            entity.HasOne(d => d.IdПомещенияNavigation).WithMany(p => p.Мероприятияs)
                .HasForeignKey(d => d.IdПомещения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Мероприят__ID_По__5BE2A6F2");
        });

        modelBuilder.Entity<НазначенияПомещений>(entity =>
        {
            entity.HasKey(e => e.IdНазначения).HasName("PK__Назначен__CB1EA4F902C954BF");

            entity.ToTable("НазначенияПомещений");

            entity.Property(e => e.IdНазначения).HasColumnName("ID_Назначения");
            entity.Property(e => e.Название).HasMaxLength(100);
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.IdПользователя).HasName("PK__Пользова__A1478CAD8401136C");

            entity.ToTable("Пользователи");

            entity.Property(e => e.IdПользователя).HasColumnName("ID_Пользователя");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IdРоли).HasColumnName("ID_Роли");
            entity.Property(e => e.Пароль).HasMaxLength(100);
            entity.Property(e => e.Телефон).HasMaxLength(20);
            entity.Property(e => e.Фио)
                .HasMaxLength(255)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.IdРолиNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.IdРоли)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Пользоват__ID_Ро__4316F928");
        });

        modelBuilder.Entity<Помещения>(entity =>
        {
            entity.HasKey(e => e.IdПомещения).HasName("PK__Помещени__DF905A4F2EB2470F");

            entity.ToTable("Помещения");

            entity.Property(e => e.IdПомещения).HasColumnName("ID_Помещения");
            entity.Property(e => e.IdНазначения).HasColumnName("ID_Назначения");
            entity.Property(e => e.Название).HasMaxLength(255);
            entity.Property(e => e.Площадь).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Расположение).HasMaxLength(255);
            entity.Property(e => e.СтоимостьАренды).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Фото).HasMaxLength(50);

            entity.HasOne(d => d.IdНазначенияNavigation).WithMany(p => p.Помещенияs)
                .HasForeignKey(d => d.IdНазначения)
                .HasConstraintName("FK__Помещения__ID_На__398D8EEE");
        });

        modelBuilder.Entity<Роли>(entity =>
        {
            entity.HasKey(e => e.IdРоли).HasName("PK__Роли__3F882696F47105EF");

            entity.ToTable("Роли");

            entity.Property(e => e.IdРоли).HasColumnName("ID_Роли");
            entity.Property(e => e.Название).HasMaxLength(50);
        });
        modelBuilder.Entity<SvgRoom>().ToTable("SvgRooms");

        modelBuilder.Entity<ЗаявкаНаАренду>()
    .HasOne(z => z.Пользователь)
    .WithMany()
    .HasForeignKey(z => z.ID_Пользователя)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ЗаявкаНаАренду>()
            .HasOne(z => z.Помещение)
            .WithMany()
            .HasForeignKey(z => z.ID_Помещения)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SvgRoom>()
    .HasOne(s => s.Помещение)
    .WithMany(p => p.SvgRooms)
    .HasForeignKey(s => s.StoreId)
    .HasPrincipalKey(p => p.Расположение); // Важно! связь по не-PK колонке



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
