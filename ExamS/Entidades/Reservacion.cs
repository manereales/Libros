namespace ExamS.Entidades
{
    public class Reservacion
    {
        public int Id { get; set; }
        public int LibrosId { get; set; }
        public int UsuariosId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTimeOffset FechaEntrega { get; set; } 


        //public Libros Libros { get; set; }
        //public Usuarios Usuarios { get; set; } 

    }
}
