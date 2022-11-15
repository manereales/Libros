using System.ComponentModel.DataAnnotations;

namespace ExamS.DTOs
{
    public class LibroCreacionDTO
    {
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        public int Cantidad { get; set; }

    }
}
