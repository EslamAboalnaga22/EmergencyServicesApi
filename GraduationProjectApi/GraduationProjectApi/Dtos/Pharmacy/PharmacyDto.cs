using System.ComponentModel.DataAnnotations;

namespace GraduationProjectApi.Dtos.Pharmacy
{
    public class PharmacyDto
    {
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; } = string.Empty;
        public string Government { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Village { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string? Phone { get; set; }
    }
}
