using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Interfaces
{
    public interface IEstudiosRepository
    {
        Task<IEnumerable<Estudio>> GetAllAsync();
        Task<Estudios> GetByIdAsync(int id);
        Task AddAsync(Estudios estudios);
        Task UpdateAsync(Estudios estudios);
        Task DeleteAsync(int id);
    }
}
