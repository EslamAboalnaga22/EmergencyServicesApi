using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services
{
    public class NotesService : INotesService
    {
        private readonly AppDbContext context;

        public NotesService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Note>> GetAll()
        {
            return await context.Notes.ToListAsync();
        }
        public async Task<Note> GetById(int id)
        {
            return await context.Notes.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Note> Add(Note note)
        {
            context.Notes.Add(note);
            context.SaveChanges();
            return note;
        }
        public Note Update(Note note)
        {
            context.Update(note);
            context.SaveChanges();
            return note;
        }
        public Note Delete(Note note)
        {
            context.Remove(note);
            context.SaveChanges();
            return note;
        }
    }
}
