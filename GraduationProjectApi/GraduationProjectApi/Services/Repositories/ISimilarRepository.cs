using GraduationProjectApi.Models;

namespace GraduationProjectApi.Services.Repositories
{
    public interface ISimilarRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
