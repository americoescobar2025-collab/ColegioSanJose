using System.ComponentModel.DataAnnotations;

namespace ColegioSanJose.Models
{
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string? Correo { get; set; }

        public ICollection<Expediente>? Expedientes { get; set; }
    }
}