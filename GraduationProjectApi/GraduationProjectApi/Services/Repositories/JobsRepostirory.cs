using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services.Repositories
{
    public class JobsRepostirory : ISimilarRepository<Job>
    {
        private readonly AppDbContext context;

        public JobsRepostirory(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Job>> GetAll()
        {
            return await context.Jobs.ToListAsync();
        }
        public async Task<Job> GetById(int id)
        {
            return await context.Jobs.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Job> Add(Job job)
        {
            await context.Jobs.AddAsync(job);
            context.SaveChangesAsync();
            return job;
        }
        public Job Update(Job job)
        {
            context.Update(job);
            context.SaveChanges();
            return job;
        }
        public Job Delete(Job job)
        {
            context.Remove(job);
            context.SaveChanges();
            return job;
        }
    }
}
