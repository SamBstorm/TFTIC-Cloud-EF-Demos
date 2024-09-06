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
    internal class EditorConfig : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
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
                        "CK_Editor_Name",
                        "LEN([Name]) > 1"
                    ));
            /* Définission de la FK du côté Many, compatible, sans problème, mais confusante, préférer la définir du côte One
            builder
                .HasMany(e => e.Softwares)
                .WithOne(e => e.Editor)
                .HasForeignKey(e => e.EditorId)
                .HasConstraintName("FK_Software_Editor");
            */

            builder
                .HasData(
                new Editor()
                {
                    ID = 1,
                    Name = "Unknown"
                },
                new Editor()
                {
                    ID = 2,
                    Name = "Ubisoft"
                },
                new Editor()
                {
                    ID = 3,
                    Name = "Polyphony Digital"
                },
                new Editor()
                {
                    ID = 4,
                    Name = "Bungie"
                },
                new Editor()
                {
                    ID = 5,
                    Name = "Neon Giant"
                },
                new Editor()
                {
                    ID = 6,
                    Name = "Microsoft"
                },
                new Editor()
                {
                    ID = 7,
                    Name = "Meta"
                }
                );
        }
    }
}
