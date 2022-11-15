using ExamS.Entidades;

namespace ExamS.DTOs
{
    public class ReservacionDTO
    {
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public List<LibroDTO> LibroDTO { get; set; } 

        //public List<int> ReservacionesId { get; set; }

    }
}
