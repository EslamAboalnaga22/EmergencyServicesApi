using GraduationProjectApi.Models;

namespace GraduationProjectApi.Services
{
    public interface IHospitalsService
    {
        Task<IEnumerable<Hospital>> GetAll();
        Task<Hospital> GetById(int id);
        Task<Hospital> Add(Hospital hospital);
        Hospital Update(Hospital hospital);
        Hospital Delete(Hospital hospital);
    }
}
