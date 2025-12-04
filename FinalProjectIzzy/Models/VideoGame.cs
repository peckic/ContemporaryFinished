namespace FinalProjectIzzy.Models
{
    public class VideoGame
    {
        public int Id { get; set; }                 // Primary Key

        public string Title { get; set; } = null!;  // e.g., "The Legend of Zelda: TOTK"

        public string Genre { get; set; } = null!;  // e.g., "Action-Adventure"

        public string Platform { get; set; } = null!; // e.g., "Nintendo Switch"

        public DateTime ReleaseDate { get; set; }   // e.g., 2023-05-12

        public string Developer { get; set; } = null!; // e.g., "Nintendo"

        public VideoGame() { }

        public VideoGame(int id, string title, string genre, string platform, DateTime releaseDate, string developer)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Platform = platform;
            ReleaseDate = releaseDate;
            Developer = developer;
        }
    }
}
