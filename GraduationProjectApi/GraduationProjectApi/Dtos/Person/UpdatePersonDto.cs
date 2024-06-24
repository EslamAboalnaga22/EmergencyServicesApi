namespace GraduationProjectApi.Dtos.Person
{
    public class UpdatePersonDto : BasePersonDto
    {
        public IFormFile? Image { get; set; }
    }
}
