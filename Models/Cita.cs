using System.ComponentModel.DataAnnotations;

namespace ServCitasMedicasSOAP.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        public string Motivo { get; set; } = string.Empty;

        public string? Tratamiento { get; set; }

        public bool Estado { get; set; }

        public int IdPaciente { get; set; }
    }
}
