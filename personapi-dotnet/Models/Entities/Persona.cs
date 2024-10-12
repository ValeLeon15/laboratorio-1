namespace personapi_dotnet.Models.Entities
{
    public class Persona
    {
        public int cc { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public char genero { get; set; } // 'M' o 'F'
        public int? edad { get; set; } // La edad puede ser null
    }
}
