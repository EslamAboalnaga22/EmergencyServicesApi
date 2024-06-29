using GraduationProjectApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectApi.Dtos.Hospital
{
    public class HospitalDetalilsDto
    {
        public int Id { get; set; }
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; } = string.Empty;
        public string Government { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Village { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public int KindId { get; set; }
        public string KindName { get; set; }
    }
}
