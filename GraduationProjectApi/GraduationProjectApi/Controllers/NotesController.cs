using AutoMapper;
using GraduationProjectApi.Dtos.Note;
using GraduationProjectApi.Models;
using GraduationProjectApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService notesService;
        private readonly IMapper mapper;

        public NotesController(INotesService notesService, IMapper mapper)
        {
            this.notesService = notesService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var notes = await notesService.GetAll();

            var data = mapper.Map<IEnumerable<NoteDetailsDto>>(notes);

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var note = await notesService.GetById(id);

            if (note is null)
                return NotFound($"id:{id} is not found!");

            var data = mapper.Map<NoteDetailsDto>(note);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] NoteDto dto)
        {
            var note = mapper.Map<Note>(dto);
            await notesService.Add(note);
            return Ok(note);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] NoteDto dto)
        {
            var note = await notesService.GetById(id);

            if (note is null)
                return NotFound($"id:{id} is not found!");

            note.Name = dto.Name;
            note.Description = dto.Description;
            note.Date = (DateTime)dto.Date;
            note.PersonId = dto.PersonId;
            
            notesService.Update(note);
            
            return Ok(note);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var note = await notesService.GetById(id);

            if (note is null)
                return NotFound($"id:{id} is not found!");

            notesService.Delete(note);

            return Ok(note);
        }

    }
}
