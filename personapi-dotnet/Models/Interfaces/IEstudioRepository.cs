using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Interfaces
{
    public interface IEstudioRepository
    {
        Task AddAsync(Estudio estudios);
        Task DeleteAsync(int id);
        Task<IEnumerable<Estudio>> GetAllAsync();
        Task<Estudio> GetByIdAsync(int id);
        Task UpdateAsync(Estudio estudios);
    }
}