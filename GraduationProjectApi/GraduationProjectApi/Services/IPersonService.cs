using GraduationProjectApi.Models;

namespace GraduationProjectApi.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<Person> Add(Person person);
        Person Update(Person person);
        Person Delete(Person person);
    }
}
