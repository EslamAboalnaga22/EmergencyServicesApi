using System.ComponentModel.DataAnnotations;

namespace GraduationProjectApi.Dtos.Person
{
    public class BasePersonDto
    {
        [MaxLength(50), MinLength(3)]
        public string Name { get; set; } = string.Empty;
        public enum Gender { Male, Female }
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int ContactNumber1 { get; set; }
        public int ContactNumber2 { get; set; }

        public int BloodId { get; set; }
        public int JobId { get; set; }
    }
}
