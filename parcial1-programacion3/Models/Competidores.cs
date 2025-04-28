using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace parcial1_programacion3.Models
{
    public class Competidores
    {
        [Key]
        public int IDCompetidor { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a 0")]
        public int Edad { get; set; }
        [Required]
        [DisplayName("Ciudad de residencia")]
        public string CiudadResidencia { get; set; }
        [Required]
        [DisplayName("Nombre del competidor")]
        public string Nombre { get; set; }
        [Required]
        public int IDDisciplina { get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}
