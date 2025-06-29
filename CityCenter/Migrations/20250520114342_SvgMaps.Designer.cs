﻿// <auto-generated />
using System;
using CityCenter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityCenter.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250520114342_SvgMaps")]
    partial class SvgMaps
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CityCenter.Models.SvgRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SvgRooms", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.Аренда", b =>
                {
                    b.Property<int>("IdАренды")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Аренды");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdАренды"));

                    b.Property<int>("IdАрендатора")
                        .HasColumnType("int")
                        .HasColumnName("ID_Арендатора");

                    b.Property<int>("IdПомещения")
                        .HasColumnType("int")
                        .HasColumnName("ID_Помещения");

                    b.Property<DateTime>("ДатаНачала")
                        .HasColumnType("date");

                    b.Property<DateTime>("ДатаОкончания")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ДатаПоследнегоИзменения")
                        .HasColumnType("datetime2");

                    b.Property<string>("Цель")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdАренды")
                        .HasName("PK__Аренда__1475B6F76682E109");

                    b.HasIndex("IdАрендатора");

                    b.HasIndex(new[] { "IdПомещения", "ДатаНачала", "ДатаОкончания" }, "UQ_УникальнаяАренда")
                        .IsUnique();

                    b.ToTable("Аренда", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.Арендаторы", b =>
                {
                    b.Property<int>("IdАрендатора")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Арендатора");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdАрендатора"));

                    b.Property<int?>("IdПользователя")
                        .HasColumnType("int")
                        .HasColumnName("ID_Пользователя");

                    b.Property<DateTime?>("ДатаНачалаДоговора")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ДатаОкончанияДоговора")
                        .HasColumnType("date");

                    b.Property<string>("Имя")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("КонтактнаяИнформация")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("НомерДоговора")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Статус")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdАрендатора")
                        .HasName("PK__Арендато__2CDA605951F51B5C");

                    b.HasIndex("IdПользователя");

                    b.ToTable("Арендаторы", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.ВидДеятельности", b =>
                {
                    b.Property<int>("IdДеятельности")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Деятельности");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdДеятельности"));

                    b.Property<string>("Название")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdДеятельности")
                        .HasName("PK__ВидДеяте__64328B69758C284C");

                    b.ToTable("ВидДеятельности", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.Мероприятия", b =>
                {
                    b.Property<int>("IdМероприятия")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Мероприятия");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdМероприятия"));

                    b.Property<int>("IdПомещения")
                        .HasColumnType("int")
                        .HasColumnName("ID_Помещения");

                    b.Property<DateTime>("ДатаМероприятия")
                        .HasColumnType("date");

                    b.Property<string>("Название")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Описание")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("IdМероприятия")
                        .HasName("PK__Мероприя__64E4CF809C75D0A0");

                    b.HasIndex("IdПомещения");

                    b.ToTable("Мероприятия", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.НазначенияПомещений", b =>
                {
                    b.Property<int>("IdНазначения")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Назначения");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdНазначения"));

                    b.Property<string>("Название")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdНазначения")
                        .HasName("PK__Назначен__CB1EA4F902C954BF");

                    b.ToTable("НазначенияПомещений", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.Пользователи", b =>
                {
                    b.Property<int>("IdПользователя")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Пользователя");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdПользователя"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdРоли")
                        .HasColumnType("int")
                        .HasColumnName("ID_Роли");

                    b.Property<string>("Пароль")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Телефон")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Фио")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ФИО");

                    b.HasKey("IdПользователя")
                        .HasName("PK__Пользова__A1478CAD8401136C");

                    b.HasIndex("IdРоли");

                    b.ToTable("Пользователи", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.Помещения", b =>
                {
                    b.Property<int>("IdПомещения")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Помещения");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdПомещения"));

                    b.Property<int?>("IdНазначения")
                        .HasColumnType("int")
                        .HasColumnName("ID_Назначения");

                    b.Property<bool>("ДоступноДляАренды")
                        .HasColumnType("bit");

                    b.Property<string>("Название")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Описание")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Площадь")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Расположение")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("СтоимостьАренды")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Фото")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Этаж")
                        .HasColumnType("int");

                    b.HasKey("IdПомещения")
                        .HasName("PK__Помещени__DF905A4F2EB2470F");

                    b.HasIndex("IdНазначения");

                    b.ToTable("Помещения", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.Роли", b =>
                {
                    b.Property<int>("IdРоли")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Роли");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdРоли"));

                    b.Property<string>("Название")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdРоли")
                        .HasName("PK__Роли__3F882696F47105EF");

                    b.ToTable("Роли", (string)null);
                });

            modelBuilder.Entity("ДеятельностьАрендатора", b =>
                {
                    b.Property<int>("IdАрендатора")
                        .HasColumnType("int");

                    b.Property<int>("IdДеятельности")
                        .HasColumnType("int");

                    b.HasKey("IdАрендатора", "IdДеятельности")
                        .HasName("PK__Деятельн__AA9948EF409EA385");

                    b.HasIndex("IdДеятельности");

                    b.ToTable("ДеятельностьАрендатора", (string)null);
                });

            modelBuilder.Entity("CityCenter.Models.Аренда", b =>
                {
                    b.HasOne("CityCenter.Models.Арендаторы", "IdАрендатораNavigation")
                        .WithMany("Арендаs")
                        .HasForeignKey("IdАрендатора")
                        .IsRequired()
                        .HasConstraintName("FK__Аренда__ID_Аренд__60A75C0F");

                    b.HasOne("CityCenter.Models.Помещения", "IdПомещенияNavigation")
                        .WithMany("Арендаs")
                        .HasForeignKey("IdПомещения")
                        .IsRequired()
                        .HasConstraintName("FK__Аренда__ID_Помещ__5FB337D6");

                    b.Navigation("IdАрендатораNavigation");

                    b.Navigation("IdПомещенияNavigation");
                });

            modelBuilder.Entity("CityCenter.Models.Арендаторы", b =>
                {
                    b.HasOne("CityCenter.Models.Пользователи", "IdПользователяNavigation")
                        .WithMany("Арендаторыs")
                        .HasForeignKey("IdПользователя")
                        .HasConstraintName("FK__Арендатор__ID_По__5535A963");

                    b.Navigation("IdПользователяNavigation");
                });

            modelBuilder.Entity("CityCenter.Models.Мероприятия", b =>
                {
                    b.HasOne("CityCenter.Models.Помещения", "IdПомещенияNavigation")
                        .WithMany("Мероприятияs")
                        .HasForeignKey("IdПомещения")
                        .IsRequired()
                        .HasConstraintName("FK__Мероприят__ID_По__5BE2A6F2");

                    b.Navigation("IdПомещенияNavigation");
                });

            modelBuilder.Entity("CityCenter.Models.Пользователи", b =>
                {
                    b.HasOne("CityCenter.Models.Роли", "IdРолиNavigation")
                        .WithMany("Пользователиs")
                        .HasForeignKey("IdРоли")
                        .IsRequired()
                        .HasConstraintName("FK__Пользоват__ID_Ро__4316F928");

                    b.Navigation("IdРолиNavigation");
                });

            modelBuilder.Entity("CityCenter.Models.Помещения", b =>
                {
                    b.HasOne("CityCenter.Models.НазначенияПомещений", "IdНазначенияNavigation")
                        .WithMany("Помещенияs")
                        .HasForeignKey("IdНазначения")
                        .HasConstraintName("FK__Помещения__ID_На__398D8EEE");

                    b.Navigation("IdНазначенияNavigation");
                });

            modelBuilder.Entity("ДеятельностьАрендатора", b =>
                {
                    b.HasOne("CityCenter.Models.Арендаторы", null)
                        .WithMany()
                        .HasForeignKey("IdАрендатора")
                        .IsRequired()
                        .HasConstraintName("FK__Деятельно__ID_Ар__5812160E");

                    b.HasOne("CityCenter.Models.ВидДеятельности", null)
                        .WithMany()
                        .HasForeignKey("IdДеятельности")
                        .IsRequired()
                        .HasConstraintName("FK__Деятельно__ID_Де__59063A47");
                });

            modelBuilder.Entity("CityCenter.Models.Арендаторы", b =>
                {
                    b.Navigation("Арендаs");
                });

            modelBuilder.Entity("CityCenter.Models.НазначенияПомещений", b =>
                {
                    b.Navigation("Помещенияs");
                });

            modelBuilder.Entity("CityCenter.Models.Пользователи", b =>
                {
                    b.Navigation("Арендаторыs");
                });

            modelBuilder.Entity("CityCenter.Models.Помещения", b =>
                {
                    b.Navigation("Арендаs");

                    b.Navigation("Мероприятияs");
                });

            modelBuilder.Entity("CityCenter.Models.Роли", b =>
                {
                    b.Navigation("Пользователиs");
                });
#pragma warning restore 612, 618
        }
    }
}
