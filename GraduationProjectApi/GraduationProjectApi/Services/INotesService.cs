using GraduationProjectApi.Models;

namespace GraduationProjectApi.Services
{
    public interface INotesService
    {
        Task<IEnumerable<Note>> GetAll();
        Task<Note> GetById(int id);
        Task<Note> Add(Note note);
        Note Update(Note note);
        Note Delete(Note note);
    }
}
