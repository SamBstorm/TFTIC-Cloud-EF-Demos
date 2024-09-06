using Demo01.Entities;
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
                .Property(nameof(Game.PegiClassification))
                .HasColumnType("CHAR(3)");  //Défini le type de la colonne
                                            //représentant la propriété selectionnée

            builder
                .HasData(
                new Game() { 
                    Id = 1,
                    Name = "Shapez 2",
                    Description = "Jeu de réflexion, puzle game, style SuperFactory.",
                    IsOnline = false,
                    IsSplitScreen = false,
                    PegiClassification = "NaN",
                    ReleaseDate = new DateTime(2024,8,15)
                },
                new Game()
                {
                    Id = 2,
                    Name = "TrackMania",
                    Description = "Jeu de course Arcade",
                    IsOnline = true,
                    IsSplitScreen = true,
                    PegiClassification = "+3",
                    ReleaseDate= new DateTime(2020,7,1)
                },
                new Game()
                {
                    Id = 3,
                    Name = "The Ascent",
                    Description = "Action-RPG dans un univers cyber-punk, shooter-looter",
                    IsOnline = true,
                    IsSplitScreen = false,
                    PegiClassification = "+18",
                    ReleaseDate = new DateTime(2021,7,29)
                },
                new Game()
                {
                    Id = 4,
                    Name = "Destiny 2",
                    Description = "TPS PVP PVE spatial",
                    IsOnline = true,
                    IsSplitScreen = false,
                    PegiClassification = "+16",
                    ReleaseDate = new DateTime(2017, 9, 6)
                }
                );
        }
    }
}
