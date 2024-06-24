using GraduationProjectApi.Models;

namespace GraduationProjectApi.Services
{
    public interface IPharmaciesService
    {
        Task<IEnumerable<Pharmacy>> GetAll();
        Task<Pharmacy> GetById(int id);
        Task<Pharmacy> Add(Pharmacy pharmacy);
        Pharmacy Update(Pharmacy pharmacy);
        Pharmacy Delete(Pharmacy pharmacy);
    }
}
