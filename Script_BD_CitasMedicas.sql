
    CREATE DATABASE CitasMedicasDB;
GO
USE CitasMedicasDB;
GO

CREATE TABLE dbo.Paciente (
    IdPaciente  INT IDENTITY(1,1) PRIMARY KEY,
    Cedula      VARCHAR(10)  NOT NULL UNIQUE,
    Nombre      VARCHAR(50)  NOT NULL,
    Apellido    VARCHAR(50)  NOT NULL,
    Telefono    VARCHAR(15)  NULL,
    Estado      BIT          NOT NULL DEFAULT 1 
);
GO

-- 4) Tabla Cita
CREATE TABLE dbo.Cita (
    IdCita       INT IDENTITY(1,1) PRIMARY KEY,
    Fecha        DATE          NOT NULL,
    Hora         DATETIME      NOT NULL,
    Motivo       VARCHAR(200)  NOT NULL,
    Tratamiento  VARCHAR(200)  NULL,
    Estado       BIT           NOT NULL DEFAULT 1, 
    IdPaciente   INT           NOT NULL,

    CONSTRAINT FK_Cita_Paciente FOREIGN KEY (IdPaciente)
        REFERENCES dbo.Paciente(IdPaciente)
);
GO

-- 4) Datos de prueba 
INSERT INTO dbo.Paciente (Cedula, Nombre, Apellido, Telefono, Estado)
VALUES
    ('1712345678', 'Mateo',  'Salazar', '0991234567', 1),
    ('1798765432', 'Andrea', 'Chicaiza', '0987654321', 1),
    ('1723456789', 'Carlos', 'Vintimilla', '0976543210', 1);
GO


INSERT INTO dbo.Cita (Fecha, Hora, Motivo, Tratamiento, Estado, IdPaciente)
VALUES
    ('20260825', '20260825 09:00:00', 'Control general', 'Ninguno', 1, 1),
    ('20260826', '20260826 10:30:00', 'Dolor de espalda', 'Fisioterapia', 1, 2),
    ('20260827', '20260827 15:00:00', 'Chequeo dental', 'Limpieza dental', 1, 3);
GO

-- 5) Verificación rápida
SELECT * FROM dbo.Paciente;
SELECT * FROM dbo.Cita;
GO
