namespace ExamS.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public int  Carnet { get; set; }
        public string Nombre { get; set; }
        public List<Reservacion> Reservacion { get; set; }

    }
}
