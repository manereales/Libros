namespace ExamS.Entidades
{
    public class Libros
    {
        public int Id { get; set; }
        public string Titulo  { get; set; }
        public int Cantidad { get; set; }

        public List<Reservacion> Reservacion { get; set; }  



    }
}
