using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;

namespace personapi_dotnet.Models
{
    public class PersonaDbContext : DbContext
    {
        public PersonaDbContext(DbContextOptions<PersonaDbContext> options)
            : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Profesion> Profesiones { get; set; }
        public DbSet<Estudios> Estudios { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
    }
}
