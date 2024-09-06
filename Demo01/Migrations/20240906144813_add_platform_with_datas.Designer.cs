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
    [Migration("20240906144813_add_platform_with_datas")]
    partial class add_platform_with_datas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo01.Entities.Editor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("ID");

                    b.ToTable("Editor", t =>
                        {
                            t.HasCheckConstraint("CK_Editor_Name", "LEN([Name]) > 1");
                        });

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Unknown"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Ubisoft"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Polyphony Digital"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Bungie"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Neon Giant"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Microsoft"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Meta"
                        });
                });

            modelBuilder.Entity("Demo01.Entities.Platform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("ID");

                    b.ToTable("Platform", t =>
                        {
                            t.HasCheckConstraint("CK_Platform_Name", "LEN([Name]) > 1");
                        });

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "PlayStation"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Switch"
                        },
                        new
                        {
                            ID = 3,
                            Name = "XBox ONE"
                        },
                        new
                        {
                            ID = 4,
                            Name = "PC"
                        });
                });

            modelBuilder.Entity("Demo01.Entities.PlatformGame", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("PlatformGame");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            PlatformId = 4
                        },
                        new
                        {
                            GameId = 2,
                            PlatformId = 4
                        },
                        new
                        {
                            GameId = 2,
                            PlatformId = 1
                        },
                        new
                        {
                            GameId = 2,
                            PlatformId = 3
                        },
                        new
                        {
                            GameId = 2,
                            PlatformId = 2
                        },
                        new
                        {
                            GameId = 3,
                            PlatformId = 4
                        },
                        new
                        {
                            GameId = 3,
                            PlatformId = 3
                        });
                });

            modelBuilder.Entity("Demo01.Entities.ServerDetails", b =>
                {
                    b.Property<int>("ServerDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServerDetailsId"));

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("CHAR(15)");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.HasKey("ServerDetailsId");

                    b.HasIndex("SoftwareId")
                        .IsUnique();

                    b.ToTable("ServerDetails", t =>
                        {
                            t.HasCheckConstraint("CK_ServerDetails_IpAddress", "[IpAddress] LIKE '___.___.___.___' AND ISNUMERIC(REPLACE([IpAddress],'.','')) = 1");
                        });

                    b.HasData(
                        new
                        {
                            ServerDetailsId = 1,
                            IpAddress = "127.000.000.001",
                            SoftwareId = 3
                        },
                        new
                        {
                            ServerDetailsId = 2,
                            IpAddress = "127.000.000.001",
                            SoftwareId = 7
                        });
                });

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

                    b.Property<int>("EditorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

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

                    b.HasIndex("EditorId");

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

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Description = "Application de rencontre",
                            EditorId = 1,
                            IsOnline = true,
                            Name = "Tinder",
                            ReleaseDate = new DateTime(2012, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsMobile = true,
                            IsMultimedia = false
                        },
                        new
                        {
                            Id = 6,
                            Description = "Application de partage de contenu multimédia, réseau social",
                            EditorId = 7,
                            IsOnline = true,
                            Name = "Instagram",
                            ReleaseDate = new DateTime(2010, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsMobile = true,
                            IsMultimedia = true
                        },
                        new
                        {
                            Id = 7,
                            Description = "Application de visualisation de manga, service de streaming",
                            EditorId = 1,
                            IsOnline = true,
                            Name = "CrunchyRoll",
                            ReleaseDate = new DateTime(2006, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsMobile = true,
                            IsMultimedia = true
                        },
                        new
                        {
                            Id = 8,
                            Description = "IDE pour le framework .net",
                            EditorId = 6,
                            IsOnline = true,
                            Name = "Visual Studio",
                            ReleaseDate = new DateTime(1997, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsMobile = false,
                            IsMultimedia = false
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Jeu de réflexion, puzle game, style SuperFactory.",
                            EditorId = 1,
                            IsOnline = false,
                            Name = "Shapez 2",
                            ReleaseDate = new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsSplitScreen = false,
                            PegiClassification = "NaN"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Jeu de course Arcade",
                            EditorId = 2,
                            IsOnline = true,
                            Name = "TrackMania",
                            ReleaseDate = new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsSplitScreen = true,
                            PegiClassification = "+3"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Action-RPG dans un univers cyber-punk, shooter-looter",
                            EditorId = 5,
                            IsOnline = true,
                            Name = "The Ascent",
                            ReleaseDate = new DateTime(2021, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsSplitScreen = false,
                            PegiClassification = "+18"
                        },
                        new
                        {
                            Id = 4,
                            Description = "TPS PVP PVE spatial",
                            EditorId = 4,
                            IsOnline = true,
                            Name = "Destiny 2",
                            ReleaseDate = new DateTime(2017, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsSplitScreen = false,
                            PegiClassification = "+16"
                        });
                });

            modelBuilder.Entity("Demo01.Entities.PlatformGame", b =>
                {
                    b.HasOne("Demo01.Entities.Game", "Game")
                        .WithMany("PlatformGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PlatformGame_Game");

                    b.HasOne("Demo01.Entities.Platform", "Platform")
                        .WithMany("PlatformGames")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PlatformGame_Platform");

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Demo01.Entities.ServerDetails", b =>
                {
                    b.HasOne("Demo01.Entities.Software", "Software")
                        .WithOne("ServerDetails")
                        .HasForeignKey("Demo01.Entities.ServerDetails", "SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ServerDetails_Softs");

                    b.Navigation("Software");
                });

            modelBuilder.Entity("Demo01.Entities.Software", b =>
                {
                    b.HasOne("Demo01.Entities.Editor", "Editor")
                        .WithMany("Softwares")
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Software_Editor");

                    b.Navigation("Editor");
                });

            modelBuilder.Entity("Demo01.Entities.Editor", b =>
                {
                    b.Navigation("Softwares");
                });

            modelBuilder.Entity("Demo01.Entities.Platform", b =>
                {
                    b.Navigation("PlatformGames");
                });

            modelBuilder.Entity("Demo01.Entities.Software", b =>
                {
                    b.Navigation("ServerDetails");
                });

            modelBuilder.Entity("Demo01.Entities.Game", b =>
                {
                    b.Navigation("PlatformGames");
                });
#pragma warning restore 612, 618
        }
    }
}
