using GraduationProjectApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectApi.Dtos.Person
{
    public class CreatePersonDto : BasePersonDto
    {
        public IFormFile? Image { get; set; }
    }
}
