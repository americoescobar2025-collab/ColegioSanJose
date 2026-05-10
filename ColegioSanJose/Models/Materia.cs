using System.ComponentModel.DataAnnotations;

namespace ColegioSanJose.Models
{
    public class Materia
    {
        [Key]
        public int IdMateria { get; set; }

        public string? NombreMateria { get; set; }

        public string? Codigo { get; set; }

        public ICollection<Expediente>? Expedientes { get; set; }
    }
}
