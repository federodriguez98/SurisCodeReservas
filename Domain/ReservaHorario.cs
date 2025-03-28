namespace GestionDeReservas.Domain
{
    public class ReservaHorario
    {
        public int IdReserva { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
        public Reserva Reserva { get; set; }
        public Horario Horario { get; set; }
    }
}
