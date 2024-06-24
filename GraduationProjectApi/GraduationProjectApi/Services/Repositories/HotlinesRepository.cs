using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services.Repositories
{
    public class HotlinesRepository : ISimilarRepository<Hotline>
    {
        private readonly AppDbContext context;

        public HotlinesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Hotline>> GetAll()
        {
            return await context.Hotlines.ToListAsync();
        }
        public async Task<Hotline> GetById(int id)
        {
            return await context.Hotlines.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Hotline> Add(Hotline hotline)
        {
            await context.Hotlines.AddAsync(hotline);
            context.SaveChangesAsync();
            return hotline;
        }
        public Hotline Update(Hotline hotline)
        {
            context.Update(hotline);
            context.SaveChanges();
            return hotline;
        }
        public Hotline Delete(Hotline hotline)
        {
            context.Remove(hotline);
            context.SaveChanges();
            return hotline;
        }
    }
}
