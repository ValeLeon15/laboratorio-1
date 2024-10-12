using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Interfaces
{
    public interface IProfesionRepository
    {
        Task<IEnumerable<Profesion>> GetAllAsync();
        Task<Profesion> GetByIdAsync(int id);
        Task AddAsync(Profesion profesion);
        Task UpdateAsync(Profesion profesion);
        Task DeleteAsync(int id);
    }
}

