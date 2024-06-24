using GraduationProjectApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectApi.Dtos.Person
{
    public class PeopleDetailsDto
    {
        public int Id { get; set; }

        [MaxLength(50), MinLength(3)]
        public string Name { get; set; } = string.Empty;
        public enum Gender { Male, Female }
        public string Email { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int ContactNumber1 { get; set; }
        public int ContactNumber2 { get; set; }

        public int BloodId { get; set; }
        public string BloodName { get; set; }

        public int JobId { get; set; }
        public string JobName { get; set; }
    }
}
