﻿using Demo01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Configs
{
    internal class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(g => g.Id);  // Défini une propriété comme étant la primary key


            builder
                .Property(nameof(Game.Id))  //Récupère la propriété
                .ValueGeneratedOnAdd()      //Défini en tant qu'IDENTITY la propriété sélectionnée
                .IsRequired();              //Défini en tant que NOT NULL la propriété sélectionnée

            builder
                .Property(nameof(Game.Name))
                .HasMaxLength(128)          //Défini une longueur maximale à
                                            //la colonne représentant la propriété sélectionnée
                .IsRequired();

            builder
                .Property(nameof(Game.Description))
                .HasMaxLength(1024);

            builder
                .Property(nameof(Game.ReleaseDate))
                .IsRequired();

            builder
                .Property(nameof(Game.PegiClassification))
                .HasColumnType("CHAR(3)");  //Défini le type de la colonne
                                            //représentant la propriété selectionnée

            builder
                .Property(nameof(Game.IsOnline))
                .IsRequired();
        }
    }
}
