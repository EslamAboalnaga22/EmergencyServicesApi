using GraduationProjectApi.Models;
using GraduationProjectApi.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotlinesController : ControllerBase
    {
        private readonly ISimilarRepository<Hotline> similarRepository;

        public HotlinesController(ISimilarRepository<Hotline> similarRepository)
        {
            this.similarRepository = similarRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var hotlines = await similarRepository.GetAll();

            return Ok(hotlines);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var hotline = await similarRepository.GetById(id);

            return Ok(hotline);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Hotline hotline)
        {
            await similarRepository.Add(hotline);
            return Ok(hotline);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Hotline hotline)
        {
            var data = await similarRepository.GetById(id);

            if (data is null)
                return NotFound($"id:{id} is not found!");

            data.Name = hotline.Name;
            data.Phone = hotline.Phone;

            similarRepository.Update(data);

            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var hotline = await similarRepository.GetById(id);

            if (hotline is null)
                return NotFound($"id:{id} is not found!");

            similarRepository.Delete(hotline);

            return Ok(hotline);
        }
    }
}
