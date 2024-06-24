using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectApi.Dtos.Note
{
    public class NoteDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public int PersonId { get; set; }
    }
}
