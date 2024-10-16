using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : Models.Interfaces.IPersonaRepository
    {
        private readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> GetAll()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task Add(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Persona>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Persona> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Persona persona)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Persona persona)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
