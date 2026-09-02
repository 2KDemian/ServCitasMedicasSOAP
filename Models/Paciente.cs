using System.ComponentModel.DataAnnotations;

namespace ServCitasMedicasSOAP.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        public string Cedula { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        public bool Estado { get; set; }
    }
}
