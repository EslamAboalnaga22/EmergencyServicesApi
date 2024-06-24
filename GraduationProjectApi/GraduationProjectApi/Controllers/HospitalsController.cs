using AutoMapper;
using GraduationProjectApi.Dtos.Hospital;
using GraduationProjectApi.Dtos.Person;
using GraduationProjectApi.Models;
using GraduationProjectApi.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GraduationProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalsService hospitalsService;
        private readonly IMapper mapper;

        public HospitalsController(IHospitalsService hospitalsService, IMapper mapper)
        {
            this.hospitalsService = hospitalsService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var hospitals = await hospitalsService.GetAll();

            var data = mapper.Map<IEnumerable<HospitalDetalilsDto>>(hospitals);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var hospital = await hospitalsService.GetById(id);

            if (hospital is null)
                return NotFound($"id:{id} is not found!");

            var data = mapper.Map<HospitalDetalilsDto>(hospital);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] HospitalDto dto)
        {
            var hospital = mapper.Map<Hospital>(dto);
            await hospitalsService.Add(hospital);
            return Ok(hospital);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id , [FromForm] HospitalDto dto)
        {
            var hospital = await hospitalsService.GetById(id);

            if (hospital is null)
                return NotFound($"id:{id} is not found!");

            hospital.Name = dto.Name;
            hospital.Government = dto.Government;
            hospital.City = dto.City;
            hospital.Village = dto.Village;
            hospital.Phone = dto.Phone;
            hospital.Location = dto.Location;
            hospital.KindId = dto.KindId;

            hospitalsService.Update(hospital);

            return Ok(hospital);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var hospital = await hospitalsService.GetById(id);

            if (hospital is null)
                return NotFound($"id:{id} is not found!");

            hospitalsService.Delete(hospital);

            return Ok(hospital);
        }
    }
}
