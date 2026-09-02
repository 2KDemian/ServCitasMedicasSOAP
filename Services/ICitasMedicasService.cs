using CoreWCF;
using ServCitasMedicasSOAP.Models;

namespace ServCitasMedicasSOAP.Services
{
    [ServiceContract]
    public interface ICitasMedicasService
    {
        // ---------- Pacientes ----------
        [OperationContract]
        List<Paciente> ObtenerPacientes();

        // ---------- Citas ----------
        [OperationContract]
        List<Cita> ObtenerCitas();

        [OperationContract]
        Cita? ObtenerCita(int id);

        [OperationContract]
        Cita NuevaCita(Cita cita);

        [OperationContract]
        Cita? ActualizarCita(Cita cita);

        [OperationContract]
        bool EliminarCita(int id);

        [OperationContract]
        List<Cita> ObtenerCitaPorTratamiento(string tratamiento);

        [OperationContract]
        List<Cita> ObtenerCitaPorCedula(string cedula);
    }
}
