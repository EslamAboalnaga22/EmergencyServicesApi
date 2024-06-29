using GraduationProjectApi.Models;

namespace GraduationProjectApi.Services
{
    public interface INearby
    {
        Task<IEnumerable<Hospital>> GetDistance(string MyLocation);
    }
}
