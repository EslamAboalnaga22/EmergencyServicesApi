using AutoMapper;
using GraduationProjectApi.Dtos.Person;
using GraduationProjectApi.Models;
using GraduationProjectApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IMapper mapper;
        private new List<string> allowedExtensions = new List<string> { ".jpg", ".png" };
        private long maxAllowedImageSize = 3145728;


        public PersonController(IPersonService personService, IMapper mapper)
        {
            this.personService = personService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var people = await personService.GetAll();

            var data = mapper.Map<IEnumerable<PeopleDetailsDto>>(people);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var person = await personService.GetById(id);

            if (person is null)
                return NotFound();

            var data = mapper.Map<PeopleDetailsDto>(person);

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreatePersonDto dto)
        {
            if(!allowedExtensions.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if (dto.Image.Length > maxAllowedImageSize)
                return BadRequest("Max allowed size for poster is 3MB");

            using var dataStream = new MemoryStream();
            await dto.Image.CopyToAsync(dataStream);

            var person = mapper.Map<Person>(dto);
            person.Image = dataStream.ToArray();

            personService.Add(person);

            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdatePersonDto dto)
        {
            var person = await personService.GetById(id);

            if (person is null)
                return NotFound($"No person was found with ID {id}");

            if(dto.Image is not null)
            {
                if (!allowedExtensions.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (dto.Image.Length > maxAllowedImageSize)
                    return BadRequest("Max allowed size for poster is 3MB");

                using var dataStream = new MemoryStream();
                await dto.Image.CopyToAsync(dataStream);

                person.Image = dataStream.ToArray();   
            }
            person.Name = dto.Name;
            person.Address = dto.Address;
            person.Location = dto.Location;
            person.ContactNumber1 = dto.ContactNumber1;
            person.ContactNumber2 = dto.ContactNumber2;
            person.BloodId = dto.BloodId;
            person.JobId = dto.JobId;

            personService.Update(person);

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var person = await personService.GetById(id);

            if (person is null)
                return NotFound($"No person was found with ID {id}");

            personService.Delete(person);

            return Ok(person);
        }

    }
}
