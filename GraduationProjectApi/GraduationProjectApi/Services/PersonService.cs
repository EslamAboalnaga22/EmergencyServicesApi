using AutoMapper;
using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext context;
        
        public PersonService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await context.People
                .Include(b => b.Blood)
                .Include(j => j.Job)
                .ToArrayAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await context.People
                .Include(b => b.Blood)
                .Include(j => j.Job)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Person> Add(Person person)
        {
            await context.AddAsync(person);
            context.SaveChanges();
            return person;
        }
        public Person Update(Person person)
        {
            context.Update(person);
            context.SaveChanges();
            return person;
        }
        public Person Delete(Person person)
        {
            context.Remove(person);
            context.SaveChanges();
            return person;
        }
    }
}
