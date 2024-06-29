using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectApi.Models
{
    public class Hospital
    {

        public int Id { get; set; }
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; } = string.Empty;
        public string Government { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Village { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string? Phone { get; set; }

        [ForeignKey(nameof(Kind))]
        public int KindId { get; set; }
        public Kind? Kind { get; set; }


        public string MyLocation { get; set; } = string.Empty;

        public float Distance { get; set; }

    }
}
