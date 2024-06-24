using AutoMapper;
using GraduationProjectApi.Dtos.Hospital;
using GraduationProjectApi.Dtos.Pharmacy;
using GraduationProjectApi.Models;
using GraduationProjectApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly IPharmaciesService pharmaciesService;
        private readonly IMapper mapper;

        public PharmaciesController(IPharmaciesService pharmaciesService, IMapper mapper)
        {
            this.pharmaciesService = pharmaciesService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pharmacies = await pharmaciesService.GetAll();

            return Ok(pharmacies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var pharmacy = await pharmaciesService.GetById(id);

            if (pharmacy is null)
                return NotFound($"id:{id} is not found!");

            return Ok(pharmacy);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] PharmacyDto dto)
        {
            var pharmacy = mapper.Map<Pharmacy>(dto);
            await pharmaciesService.Add(pharmacy);
            return Ok(pharmacy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] PharmacyDto dto)
        {
            var pharmacy = await pharmaciesService.GetById(id);

            if (pharmacy is null)
                return NotFound($"id:{id} is not found!");

            pharmacy.Name = dto.Name;
            pharmacy.Government = dto.Government;
            pharmacy.City = dto.City;
            pharmacy.Village = dto.Village;
            pharmacy.Phone = dto.Phone;
            pharmacy.Location = dto.Location;

            pharmaciesService.Update(pharmacy);

            return Ok(pharmacy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var pharmacy = await pharmaciesService.GetById(id);

            if (pharmacy is null)
                return NotFound($"id:{id} is not found!");

            pharmaciesService.Delete(pharmacy);
            return Ok(pharmacy);
        }
    }
}
