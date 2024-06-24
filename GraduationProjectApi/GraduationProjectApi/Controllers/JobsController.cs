using GraduationProjectApi.Models;
using GraduationProjectApi.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ISimilarRepository<Job> similarRepository;

        public JobsController(ISimilarRepository<Job> similarRepository)
        {
            this.similarRepository = similarRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var jobs = await similarRepository.GetAll();

            return Ok(jobs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var job = await similarRepository.GetById(id);

            return Ok(job);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Job job)
        {
            await similarRepository.Add(job);
            return Ok(job);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Job job)
        {
            var data = await similarRepository.GetById(id);

            if (data is null)
                return NotFound($"id:{id} is not found!");

            data.Name = job.Name;

            similarRepository.Update(data);

            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var job = await similarRepository.GetById(id);

            if (job is null)
                return NotFound($"id:{id} is not found!");

            similarRepository.Delete(job);

            return Ok(job);
        }
    }
}
