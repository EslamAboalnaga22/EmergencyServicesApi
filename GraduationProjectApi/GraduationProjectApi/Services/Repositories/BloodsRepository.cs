using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services.Repositories
{
    public class BloodsRepository : ISimilarRepository<Blood>
    {
        private readonly AppDbContext context;

        public BloodsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Blood>> GetAll()
        {
            return await context.Bloods.ToListAsync();
        }
        public async Task<Blood> GetById(int id)
        {
            return await context.Bloods.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Blood> Add(Blood blood)
        {
            await context.Bloods.AddAsync(blood);
            context.SaveChangesAsync();
            return blood;
        }
        public Blood Update(Blood blood)
        {
            context.Update(blood);
            context.SaveChanges();
            return blood;
        }
        public Blood Delete(Blood blood)
        {
            context.Remove(blood);
            context.SaveChanges();
            return blood;
        }
    }
}
