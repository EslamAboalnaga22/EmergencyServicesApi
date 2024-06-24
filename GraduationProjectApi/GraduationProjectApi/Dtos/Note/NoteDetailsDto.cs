using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectApi.Dtos.Note
{
    public class NoteDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public string PersonName { get; set; }
    }
}
