using System.ComponentModel.DataAnnotations;

namespace FinalProjectIzzy.Models
{
    public class TeamMembers
    {
        [Key]
        public int MemberId { get; set; }

        public string MemberName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; } = DateTime.Now;

        public string CollegeProgram { get; set; } = string.Empty;

        public string YearInProgram { get; set; } = string.Empty;

        public TeamMembers() { }

        public TeamMembers(int memberid, string membername, DateTime birthdate, string collegeprogram, string yearinprogram)
        {
            MemberId = memberid;
            MemberName = membername;
            BirthDate = birthdate;
            CollegeProgram = collegeprogram;
            YearInProgram = yearinprogram;
        }
    }
}
