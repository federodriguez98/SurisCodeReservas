namespace GestionDeReservas.Domain
{
    public class Horario
    {
        public int Id { get; set; }
        public TimeSpan Hora { get; set; }
        public ICollection<ReservaHorario> ReservaHorarios { get; set; }
    }
}
