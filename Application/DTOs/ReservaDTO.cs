namespace GestionDeReservas.Application.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Servicio { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }

}
