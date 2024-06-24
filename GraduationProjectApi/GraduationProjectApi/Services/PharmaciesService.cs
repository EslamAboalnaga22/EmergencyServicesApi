using AutoMapper;
using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services
{
    public class PharmaciesService : IPharmaciesService
    {
        private readonly AppDbContext context;

        public PharmaciesService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Pharmacy>> GetAll()
        {
            return await context.Pharmacies.ToListAsync();
        }
        public async Task<Pharmacy> GetById(int id)
        {
            return await context.Pharmacies.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Pharmacy> Add(Pharmacy pharmacy)
        {
            await context.AddAsync(pharmacy);
            context.SaveChangesAsync();
            return pharmacy;
        }
        public Pharmacy Update(Pharmacy pharmacy)
        {
            context.Update(pharmacy);
            context.SaveChanges();
            return pharmacy;
        }
        public Pharmacy Delete(Pharmacy pharmacy)
        {
            context.Remove(pharmacy);
            context.SaveChanges();
            return pharmacy;
        }
    }
}
