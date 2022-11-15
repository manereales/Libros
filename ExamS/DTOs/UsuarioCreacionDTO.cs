using System.ComponentModel.DataAnnotations;

namespace ExamS.DTOs
{
    public class UsuarioCreacionDTO
    {
       [Required]  
        public int Carnet { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public List<int> Ids { get; set; }
    }
}
