using AutoMapper;
using GraduationProjectApi.Dtos.Note;
using GraduationProjectApi.Models;
using GraduationProjectApi.Services;
using GraduationProjectApi.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodController : ControllerBase
    {
        private readonly ISimilarRepository<Blood> similarRepository;

        public BloodController(ISimilarRepository<Blood> similarRepository)
        {
            this.similarRepository = similarRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var bloods = await similarRepository.GetAll();

            return Ok(bloods);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blood = await similarRepository.GetById(id);

            return Ok(blood);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Blood blood)
        {
            await similarRepository.Add(blood);
            return Ok(blood);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Blood blood)
        {
            var data = await similarRepository.GetById(id);

            if (data is null)
                return NotFound($"id:{id} is not found!");

            data.Name = blood.Name;

            similarRepository.Update(data);

            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var blood = await similarRepository.GetById(id);

            if (blood is null)
                return NotFound($"id:{id} is not found!");

            similarRepository.Delete(blood);

            return Ok(blood);
        }
    }
}
