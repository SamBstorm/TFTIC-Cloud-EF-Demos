using Demo01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Configs
{
    internal class ApplicationConfig : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder
                .Property(x => x.IsMultimedia)
                .IsRequired();

            builder
                .Property (x => x.IsMobile)
                .IsRequired();

            builder.HasData(
                new Application()
                {
                    Id = 5,
                    Name = "Tinder",
                    Description = "Application de rencontre",
                    IsMobile = true,
                    IsMultimedia = false,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2012,9,12),
                    EditorId = 1
                },
                new Application()
                {
                    Id = 6,
                    Name = "Instagram",
                    Description = "Application de partage de contenu multimédia, réseau social",
                    IsMobile = true,
                    IsMultimedia = true,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2010, 10, 6),
                    EditorId = 7
                },
                new Application()
                {
                    Id = 7,
                    Name = "CrunchyRoll",
                    Description = "Application de visualisation de manga, service de streaming",
                    IsMobile = true,
                    IsMultimedia = true,
                    IsOnline = true,
                    ReleaseDate = new DateTime(2006,5,14),
                    EditorId = 1
                },
                new Application()
                {
                    Id = 8,
                    Name = "Visual Studio",
                    Description = "IDE pour le framework .net",
                    IsMobile = false,
                    IsMultimedia = false,
                    IsOnline = true,
                    ReleaseDate = new DateTime(1997,3,19),
                    EditorId = 6
                });
        }
    }
}
