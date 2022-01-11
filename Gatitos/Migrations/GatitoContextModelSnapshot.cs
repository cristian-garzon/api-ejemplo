﻿// <auto-generated />
using System;
using Gatitos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gatitos.Migrations
{
    [DbContext(typeof(GatitoContext))]
    partial class GatitoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gatitos.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.HasKey("AlbumId");

                    b.HasIndex("MascotaId")
                        .IsUnique();

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Gatitos.Models.Galeria", b =>
                {
                    b.Property<int>("GaleriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GaleriaId"), 1L, 1);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("GaleriaId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Galeria");
                });

            modelBuilder.Entity("Gatitos.Models.Mascota", b =>
                {
                    b.Property<int>("MascotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MascotaId"), 1L, 1);

                    b.Property<int>("Años")
                        .HasColumnType("int");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<string>("especie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MascotaId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Gatitos.Models.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonaId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trabajo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Gatitos.Models.vacuna", b =>
                {
                    b.Property<int>("VacunaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacunaId"), 1L, 1);

                    b.Property<DateTime>("FechaProx")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("VacunaId");

                    b.HasIndex("MascotaId");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Gatitos.Models.Album", b =>
                {
                    b.HasOne("Gatitos.Models.Mascota", "Mascota")
                        .WithOne("Album")
                        .HasForeignKey("Gatitos.Models.Album", "MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("Gatitos.Models.Galeria", b =>
                {
                    b.HasOne("Gatitos.Models.Album", "Album")
                        .WithMany("Galerias")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Gatitos.Models.Mascota", b =>
                {
                    b.HasOne("Gatitos.Models.Persona", "Persona")
                        .WithMany("Mascotas")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Gatitos.Models.vacuna", b =>
                {
                    b.HasOne("Gatitos.Models.Mascota", "Mascota")
                        .WithMany("Vacunas")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("Gatitos.Models.Album", b =>
                {
                    b.Navigation("Galerias");
                });

            modelBuilder.Entity("Gatitos.Models.Mascota", b =>
                {
                    b.Navigation("Album");

                    b.Navigation("Vacunas");
                });

            modelBuilder.Entity("Gatitos.Models.Persona", b =>
                {
                    b.Navigation("Mascotas");
                });
#pragma warning restore 612, 618
        }
    }
}
