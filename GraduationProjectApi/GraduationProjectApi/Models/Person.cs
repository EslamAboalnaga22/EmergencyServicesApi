using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectApi.Models
{
    public class Person
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

        [ForeignKey(nameof(Blood))]
        public int BloodId { get; set; }
        public Blood? Blood { get; set; }

        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public Job? Job { get; set; }


    }
}
