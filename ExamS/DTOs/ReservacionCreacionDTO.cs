namespace ExamS.DTOs
{
    public class ReservacionCreacionDTO
    {

       // public int LibrosId { get; set; }
        public int UsuariosId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTimeOffset FechaEntrega { get; set; }

    }
}
