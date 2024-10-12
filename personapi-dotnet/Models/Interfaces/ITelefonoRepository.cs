using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Interfaces
{
    public interface ITelefonoRepository
    {
        Task<IEnumerable<Telefono>> GetAllAsync();
        Task<Telefono> GetByIdAsync(string numero);
        Task AddAsync(Telefono telefono);
        Task UpdateAsync(Telefono telefono);
        Task DeleteAsync(string numero);
    }
}
