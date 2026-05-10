using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColegioSanJose.Models
{
    [Table("Expediente")]
    public class Expediente
    {
        [Key]
        public int Id { get; set; }

        // 🔗 Alumno
        [Required]
        public int AlumnoId { get; set; }
        public Alumno? Alumno { get; set; }

        // 🔗 Materia
        [Required]
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }

        // ⭐ NOTA CORREGIDA (IMPORTANTE)
        // Usar DECIMAL evita errores con SQL Server
        [Required(ErrorMessage = "La nota es obligatoria")]
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Nota { get; set; }

        // 📝 Observaciones
        [StringLength(200)]
        public string? Observaciones { get; set; }
    }
}