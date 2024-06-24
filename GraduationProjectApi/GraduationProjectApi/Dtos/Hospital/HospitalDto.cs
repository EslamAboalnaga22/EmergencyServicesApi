using System.ComponentModel.DataAnnotations;

namespace GraduationProjectApi.Dtos.Hospital
{
    public class HospitalDto
    {
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; } = string.Empty;
        public string Government { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Village { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int? Phone { get; set; }
        public int KindId { get; set; }
    }
}
