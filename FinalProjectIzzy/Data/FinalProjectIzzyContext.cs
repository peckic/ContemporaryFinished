using Microsoft.EntityFrameworkCore;
using FinalProjectIzzy.Models;

namespace FinalProjectIzzy.Data
{
    public class FinalProjectIzzyContext : DbContext
    {
        public FinalProjectIzzyContext(DbContextOptions<FinalProjectIzzyContext> options)
            : base(options)
        {
        }

        public DbSet<DanceMoves> DanceMoves { get; set; } = default!;
        public DbSet<NatureTrail> NatureTrail { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed DanceMoves
            modelBuilder.Entity<DanceMoves>().HasData(
                new DanceMoves
                {
                    MoveId = 1,
                    Style = "Hip Hop",
                    Difficulty = 3,
                    MusicType = "Urban Beat",
                    IdealTempo = 95
                },
                new DanceMoves
                {
                    MoveId = 2,
                    Style = "Salsa",
                    Difficulty = 4,
                    MusicType = "Latin",
                    IdealTempo = 180
                }
            );

            // Seed NatureTrail
            modelBuilder.Entity<NatureTrail>().HasData(
                new NatureTrail
                {
                    Id = 1,
                    TrailName = "Pine Ridge Loop",
                    TrailLength = 4.7,
                    DifficultyLevel = "Moderate",
                    WildLifeSightings = "Deer, red foxes, woodpeckers"
                },
                new NatureTrail
                {
                    Id = 2,
                    TrailName = "Eagle Summit Trail",
                    TrailLength = 9.3,
                    DifficultyLevel = "Hard",
                    WildLifeSightings = "Eagles, mountain goats, marmots"
                }
            );

            modelBuilder.Entity<TeamMembers>().HasData(
                new TeamMembers
                {
                    MemberId = 1,
                    MemberName = "Isabelle Peck",
                    BirthDate = new DateTime(2006, 6, 12),
                    CollegeProgram = "Software Development",
                    YearInProgram = "Third year"
                },
                new TeamMembers
                {
                    MemberId = 2,
                    MemberName = "Ethan Zins",
                    BirthDate = new DateTime(2006, 4, 13),
                    CollegeProgram = "Software Development",
                    YearInProgram = "Second Year"
                }
            );

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "The Legend of Zelda: Tears of the Kingdom",
                    Genre = "Action-Adventure",
                    Platform = "Nintendo Switch",
                    ReleaseDate = new DateTime(2023, 5, 12),
                    Developer = "Nintendo"
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "Elden Ring",
                    Genre = "Action RPG",
                    Platform = "PC / PlayStation / Xbox",
                    ReleaseDate = new DateTime(2022, 2, 25),
                    Developer = "FromSoftware"
                }
            );
        }
        public DbSet<FinalProjectIzzy.Models.TeamMembers> TeamMembers { get; set; } = default!;
        public DbSet<FinalProjectIzzy.Models.VideoGame> VideoGame { get; set; } = default!;
    }
}