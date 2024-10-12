namespace personapi_dotnet.Models.Entities
{
    public class Telefono
    {
        public string num { get; set; } // Número de teléfono
        public string oper { get; set; } // Operador
        public int duenio { get; set; } // ID de la persona (FK)
    }

}
