namespace personapi_dotnet.Models.Entities
{
    public class Estudios
    {
        public int id_prof { get; set; } // ID de la profesión (FK)
        public int cc_per { get; set; } // Cédula de la persona (FK)
        public DateTime? fecha { get; set; } // Fecha de estudios
        public string univer { get; set; } // Universidad
    }

}
