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
    internal class PlatformGameConfig : IEntityTypeConfiguration<PlatformGame>
    {
        public void Configure(EntityTypeBuilder<PlatformGame> builder)
        {
            builder
                .HasKey(pg => new { pg.GameId, pg.PlatformId });

            builder
                .HasOne(pg => pg.Game)
                .WithMany(g => g.PlatformGames)
                .HasForeignKey(pg => pg.GameId)
                .HasConstraintName("FK_PlatformGame_Game");


            builder
                .HasOne(pg => pg.Platform)
                .WithMany(g => g.PlatformGames)
                .HasForeignKey(pg => pg.PlatformId)
                .HasConstraintName("FK_PlatformGame_Platform");

            builder
                .HasData(
                    new PlatformGame() {
                        GameId = 1,
                        PlatformId = 4
                    },
                    new PlatformGame()
                    {
                        GameId = 2,
                        PlatformId = 4
                    },
                    new PlatformGame()
                    {
                        GameId = 2,
                        PlatformId = 1
                    },
                    new PlatformGame()
                    {
                        GameId = 2,
                        PlatformId = 3
                    },
                    new PlatformGame()
                    {
                        GameId = 2,
                        PlatformId = 2
                    },
                    new PlatformGame()
                    {
                        GameId = 3,
                        PlatformId = 4
                    },
                    new PlatformGame()
                    {
                        GameId = 3,
                        PlatformId = 3
                    }
                );
        }
    }
}
