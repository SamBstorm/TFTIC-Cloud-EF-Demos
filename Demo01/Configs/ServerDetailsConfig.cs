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
    internal class ServerDetailsConfig : IEntityTypeConfiguration<ServerDetails>
    {
        public void Configure(EntityTypeBuilder<ServerDetails> builder)
        {
            builder
                .HasKey(e => e.ServerDetailsId);

            builder
                .Property(e => e.ServerDetailsId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(e => e.IpAddress)
                .HasColumnType("CHAR(15)")
                .IsRequired();

            builder
                .ToTable(t => t.HasCheckConstraint(
                    "CK_ServerDetails_IpAddress",
                    "[IpAddress] LIKE '___.___.___.___' AND ISNUMERIC(REPLACE([IpAddress],'.','')) = 1"));


            builder
                .HasOne(sd => sd.Software)
                .WithOne(sf => sf.ServerDetails)
                .HasForeignKey<ServerDetails>(sd => sd.SoftwareId)
                .HasConstraintName("FK_ServerDetails_Softs")
                .IsRequired();

            builder
                .HasData(
                    new ServerDetails()
                    {
                        ServerDetailsId = 1,
                        IpAddress = "127.000.000.001",
                        SoftwareId = 3
                    },

                    new ServerDetails()
                    {
                        ServerDetailsId = 2,
                        IpAddress = "127.000.000.001",
                        SoftwareId = 7
                    }
                );
        }
    }
}
