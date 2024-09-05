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
    internal class SoftwareConfig : IEntityTypeConfiguration<Software>
    {
        public void Configure(EntityTypeBuilder<Software> builder)
        {
            builder
                .HasKey(g => g.Id);  // Défini une propriété comme étant la primary key


            builder
                .Property(nameof(Software.Id))  //Récupère la propriété
                .ValueGeneratedOnAdd()      //Défini en tant qu'IDENTITY la propriété sélectionnée
                .IsRequired();              //Défini en tant que NOT NULL la propriété sélectionnée

            builder
                .Property(nameof(Software.Name))
                .HasMaxLength(128)          //Défini une longueur maximale à
                                            //la colonne représentant la propriété sélectionnée
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_Software_Name", "LEN([Name]) > 0"));

            builder
                .Property(nameof(Software.Description))
                .HasMaxLength(1024);

            builder.ToTable(t => t.HasCheckConstraint("CK_Software_Description", "LEN([Description]) > 10"));

            builder
                .Property(nameof(Software.ReleaseDate))
                .IsRequired();

            builder
                .Property(nameof(Software.IsOnline))
                .IsRequired();

            builder
                .HasIndex(g => new { g.Name, g.ReleaseDate })   //Pour une clé composite,
                                                                //utiliser un type anonyme
                .IsUnique();                                    //Défini la/les colonne(s) comme étant Unique

            builder
                /* SSS notre parent connait dans ses propriétés une propriété dédier à notre discrimination
                .HasDiscriminator(s => s.Type)                  //Définit la propriété correspondant
                                                                //à la colonne de discrimination
                */
                /* Si pas de propriété dédier à la discrimination */
                .HasDiscriminator<SoftwareType>("Type")         //Défini le type et le nom de la colonne       
                                                                //servant pour la discrimination
                .HasValue<Game>(SoftwareType.game)              //S'il s'agit d'un object de type Game:
                                                                //alors la valeur est "game"
                .HasValue<Application>(SoftwareType.app);       //S'il s'agit d'un object de type Application:
                                                                //alors la valeur est "app"

        }
    }
}
