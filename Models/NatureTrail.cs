using System.ComponentModel.DataAnnotations;

namespace FinalProjectIzzy.Models
{
    public class NatureTrail
    {

        [Key]
        public int Id { get; set; }
        public string TrailName { get; set; } = string.Empty;
        public double TrailLength { get; set; }
        public string DifficultyLevel { get; set; } = string.Empty;
        public string WildLifeSightings { get; set; } = string.Empty;

        public NatureTrail() { }

        public NatureTrail(int id, string trailName, double trailLength, string difficultyLevel, string wildLifeSightings)
        {
            Id = id;
            TrailName = trailName;
            TrailLength = trailLength;
            DifficultyLevel = difficultyLevel;
            WildLifeSightings = wildLifeSightings;
        }

    }
}
