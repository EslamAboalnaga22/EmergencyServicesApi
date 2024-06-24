using System.ComponentModel.DataAnnotations;

namespace GraduationProjectApi.Models
{
    public class Hotline
    {
        public int Id { get; set; }
        [MaxLength(50), MinLength(3)]
        public string Name { get; set; } = string.Empty;
        public int Phone { get; set; }
    }
}
