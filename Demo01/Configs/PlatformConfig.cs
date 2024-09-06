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
    internal class PlatformConfig : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder
                .HasKey(e => e.ID);

            builder
                .Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(e => e.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder
                .ToTable(t => t.HasCheckConstraint(
                    "CK_Platform_Name",
                    "LEN([Name]) > 1"
                    ));

            builder
                .HasData(
                    new Platform()
                    {
                        ID = 1,
                        Name = "PlayStation"
                    },
                    new Platform()
                    {
                        ID = 2,
                        Name = "Switch"
                    },
                    new Platform()
                    {
                        ID = 3,
                        Name = "XBox ONE"
                    },
                    new Platform()
                    {
                        ID = 4,
                        Name = "PC"
                    }
                );
        }
    }
}
