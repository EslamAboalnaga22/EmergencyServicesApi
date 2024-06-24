using AutoMapper;
using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services
{
    public class HospitalsService : IHospitalsService
    {
        private readonly AppDbContext context;

        public HospitalsService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Hospital>> GetAll()
        {
            return await context.Hospitals.Include(k => k.Kind).ToListAsync();
        }
        public async Task<Hospital> GetById(int id)
        {
            return await context.Hospitals.Include(k => k.Kind).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Hospital> Add(Hospital hospital)
        {
            await context.AddAsync(hospital);
            context.SaveChangesAsync();
            return hospital;
        }
        public Hospital Update(Hospital hospital)
        {
            context.Update(hospital);
            context.SaveChanges();
            return hospital;
        }
        public Hospital Delete(Hospital hospital)
        {
            context.Remove(hospital);
            context.SaveChanges();
            return hospital;
        }     
    }
}
