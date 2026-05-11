CREATE DATABASE ColegioSanJoseDB;
GO

USE ColegioSanJoseDB;
GO

CREATE TABLE Alumnos
(
    IdAlumno INT PRIMARY KEY IDENTITY(1,1),

    Nombres NVARCHAR(100) NOT NULL,

    Apellidos NVARCHAR(100) NOT NULL,

    FechaNacimiento DATE NOT NULL,

    Correo NVARCHAR(100)
);
GO

CREATE TABLE Materias
(
    IdMateria INT PRIMARY KEY IDENTITY(1,1),

    NombreMateria NVARCHAR(100) NOT NULL,

    Codigo NVARCHAR(20) NOT NULL
);
GO

CREATE TABLE Expedientes
(
    IdExpediente INT PRIMARY KEY IDENTITY(1,1),

    AlumnoId INT NOT NULL,

    MateriaId INT NOT NULL,

    Nota DECIMAL(5,2),

    Observaciones NVARCHAR(200),

    CONSTRAINT FK_Alumno
    FOREIGN KEY (AlumnoId)
    REFERENCES Alumnos(IdAlumno),

    CONSTRAINT FK_Materia
    FOREIGN KEY (MateriaId)
    REFERENCES Materias(IdMateria)
);
GO