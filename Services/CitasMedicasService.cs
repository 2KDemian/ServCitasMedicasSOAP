using CoreWCF;
using Microsoft.EntityFrameworkCore;
using ServCitasMedicasSOAP.Data;
using ServCitasMedicasSOAP.Models;

namespace ServCitasMedicasSOAP.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CitasMedicasService : ICitasMedicasService
    {
        private readonly CitasMedicasDBContext _context;

        public CitasMedicasService(CitasMedicasDBContext context)
        {
            _context = context;
        }

        // ---------- Pacientes ----------

        public List<Paciente> ObtenerPacientes()
        {
            return _context.Pacientes.ToList();
        }

        // ---------- Citas ----------

        public List<Cita> ObtenerCitas()
        {
            return _context.Citas.ToList();
        }

        public Cita? ObtenerCita(int id)
        {
            return _context.Citas.FirstOrDefault(c => c.IdCita == id);
        }

        public Cita NuevaCita(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
            return cita;
        }

        public Cita? ActualizarCita(Cita cita)
        {
            var citaExistente = _context.Citas.Find(cita.IdCita);

            if (citaExistente == null) return null;

            citaExistente.Fecha = cita.Fecha;
            citaExistente.Hora = cita.Hora;
            citaExistente.Motivo = cita.Motivo;
            citaExistente.Tratamiento = cita.Tratamiento;
            citaExistente.Estado = cita.Estado;
            citaExistente.IdPaciente = cita.IdPaciente;

            _context.SaveChanges();

            return citaExistente;
        }

        public bool EliminarCita(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita == null) return false;

            _context.Citas.Remove(cita);
            _context.SaveChanges();
            return true;
        }

        public List<Cita> ObtenerCitaPorTratamiento(string tratamiento)
        {
            return _context.Citas
                .Where(c => c.Tratamiento != null && c.Tratamiento.Contains(tratamiento))
                .ToList();
        }

        public List<Cita> ObtenerCitaPorCedula(string cedula)
        {
            return (from cita in _context.Citas
                    join paciente in _context.Pacientes
                        on cita.IdPaciente equals paciente.IdPaciente
                    where paciente.Cedula == cedula
                    select cita).ToList();
        }
    }
}
