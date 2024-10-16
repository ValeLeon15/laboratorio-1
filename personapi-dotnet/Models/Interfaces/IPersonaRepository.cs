using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Interfaces
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetAll();
        Task<Persona> GetById(int id);
        Task Add(Persona persona);
        Task Update(Persona persona);
        Task Delete(int id);
    }
}
