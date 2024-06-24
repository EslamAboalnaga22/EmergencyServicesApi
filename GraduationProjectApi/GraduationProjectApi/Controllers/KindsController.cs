using GraduationProjectApi.Models;
using GraduationProjectApi.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindsController : ControllerBase
    {
        private readonly ISimilarRepository<Kind> similarRepository;

        public KindsController(ISimilarRepository<Kind> similarRepository)
        {
            this.similarRepository = similarRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var kinds = await similarRepository.GetAll();

            return Ok(kinds);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var kind = await similarRepository.GetById(id);

            return Ok(kind);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Kind kind)
        {
            await similarRepository.Add(kind);
            return Ok(kind);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Kind kind)
        {
            var data = await similarRepository.GetById(id);

            if (data is null)
                return NotFound($"id:{id} is not found!");

            data.Name = kind.Name;

            similarRepository.Update(data);

            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var kind = await similarRepository.GetById(id);

            if (kind is null)
                return NotFound($"id:{id} is not found!");

            similarRepository.Delete(kind);

            return Ok(kind);
        }
    }
}
