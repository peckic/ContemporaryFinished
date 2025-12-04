using System.ComponentModel.DataAnnotations;


namespace FinalProjectIzzy.Models
{
    public class DanceMoves
    {
        [Key]
        public int MoveId { get; set; }
        public string Style { get; set; } = string.Empty;
        public int Difficulty { get; set; }
        public string MusicType { get; set; } = string.Empty;
        public int IdealTempo { get; set; }
        public DanceMoves() { }
        public DanceMoves(int moveId, string style, int difficulty, string musicType, int idealTempo)
        {
            MoveId = moveId;
            Style = style;
            Difficulty = difficulty;
            MusicType = musicType;
            IdealTempo = idealTempo;
        }
    }
}
