# ServCitasMedicasSOAP

Servicio web SOAP en .NET 10 (CoreWCF + Entity Framework Core) para la gestión
de Pacientes y Citas Médicas.

## Tecnologías

- .NET 10
- CoreWCF (BasicHttpBinding) — servicio SOAP
- Entity Framework Core (SQL Server)
- SQL Server

## Estructura del proyecto

```
ServCitasMedicasSOAP/
├── Models/
│   ├── Paciente.cs
│   └── Cita.cs
├── Data/
│   └── CitasMedicasDBContext.cs
├── Services/
│   ├── ICitasMedicasService.cs   (contrato SOAP)
│   └── CitasMedicasService.cs    (implementación)
├── Properties/
│   └── launchSettings.json
├── Program.cs
├── appsettings.json
└── ServCitasMedicasSOAP.csproj
```

## Requisitos previos

- Visual Studio 2022 con soporte para .NET 10
- SQL Server con la base de datos `CitasMedicasDB` ya creada
  (script `Script_BD_CitasMedicas.sql`)

## Configuración

1. Abre `appsettings.json` y ajusta la cadena de conexión `CitasMedicasConnection`
   con el nombre de tu instancia de SQL Server:
 

   ```json
   "CitasMedicasConnection": "Server=TU_SERVIDOR;Database=CitasMedicasDB;Trusted_Connection=True;TrustServerCertificate=True;"
   ```

2. Abre `ServCitasMedicasSOAP.slnx` en Visual Studio.
3. Restaura los paquetes NuGet automáticamente.

## Ejecutar el servicio

- Presiona F5 o Ctrl+F5
- El servicio queda disponible en:
  `http://localhost:5080/CitasMedicasService.svc`
- Puedes ver el WSDL agregando `?wsdl` al final de esa URL:
  `http://localhost:5080/CitasMedicasService.svc?wsdl`

## Métodos disponibles

| Método | Descripción |
|---|---|
| `ObtenerPacientes()` | Devuelve la lista completa de pacientes |
| `ObtenerCitas()` | Devuelve la lista completa de citas |
| `ObtenerCita(int id)` | Devuelve una cita por su Id |
| `NuevaCita(Cita cita)` | Crea una nueva cita |
| `ActualizarCita(Cita cita)` | Actualiza una cita existente |
| `EliminarCita(int id)` | Elimina una cita por su Id |
| `ObtenerCitaPorTratamiento(string tratamiento)` | Busca citas por tratamiento (coincidencia parcial) |
| `ObtenerCitaPorCedula(string cedula)` | Busca las citas de un paciente por su cédula |

## Probar el servicio con Postman

1. Corre el proyecto (F5).
2. Abre Postman y usa la colección 
3. Cada request ya trae el `SOAPAction` y el body XML (SOAP Envelope) listos.
(Importa el archivo dentro de la carpeta postman)


## Base de datos

El script de creación de la base de datos (`Script_BD_CitasMedicas.sql`)
crea las tablas `Paciente` y `Cita`, con la relación 1 paciente → N citas,
y carga 3 pacientes y 3 citas de prueba.
