using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace parcial1_programacion3.Models
{
    public class Disciplina
    {
        [Key]
        public int IDDisciplina { get; set; }
        [Required]
        [DisplayName("Nombre de la disciplina")]
        public string NombreDisciplina { get; set; }
    }
}
