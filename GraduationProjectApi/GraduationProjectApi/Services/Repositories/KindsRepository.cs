using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services.Repositories
{
    public class KindsRepository : ISimilarRepository<Kind>
    {
        private readonly AppDbContext context;

        public KindsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Kind>> GetAll()
        {
            return await context.Kinds.ToListAsync();
        }
        public async Task<Kind> GetById(int id)
        {
            return await context.Kinds.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Kind> Add(Kind kind)
        {
            await context.Kinds.AddAsync(kind);
            context.SaveChangesAsync();
            return kind;
        }
        public Kind Update(Kind kind)
        {
            context.Update(kind);
            context.SaveChanges();
            return kind;
        }
        public Kind Delete(Kind kind)
        {
            context.Remove(kind);
            context.SaveChanges();
            return kind;
        }
    }
}



