﻿// <auto-generated />
using System;
using Demo01;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo01.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240905123553_InitEF")]
    partial class InitEF
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo01.Entities.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name", "ReleaseDate")
                        .IsUnique();

                    b.ToTable("Softs", t =>
                        {
                            t.HasCheckConstraint("CK_Software_Description", "LEN([Description]) > 10");

                            t.HasCheckConstraint("CK_Software_Name", "LEN([Name]) > 0");
                        });

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Demo01.Entities.Application", b =>
                {
                    b.HasBaseType("Demo01.Entities.Software");

                    b.Property<bool>("IsMobile")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMultimedia")
                        .HasColumnType("bit");

                    b.ToTable(t =>
                        {
                            t.HasCheckConstraint("CK_Software_Description", "LEN([Description]) > 10");

                            t.HasCheckConstraint("CK_Software_Name", "LEN([Name]) > 0");
                        });

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Demo01.Entities.Game", b =>
                {
                    b.HasBaseType("Demo01.Entities.Software");

                    b.Property<bool>("IsSplitScreen")
                        .HasColumnType("bit");

                    b.Property<string>("PegiClassification")
                        .IsRequired()
                        .HasColumnType("CHAR(3)");

                    b.ToTable(t =>
                        {
                            t.HasCheckConstraint("CK_Software_Description", "LEN([Description]) > 10");

                            t.HasCheckConstraint("CK_Software_Name", "LEN([Name]) > 0");
                        });

                    b.HasDiscriminator().HasValue(0);
                });
#pragma warning restore 612, 618
        }
    }
}
