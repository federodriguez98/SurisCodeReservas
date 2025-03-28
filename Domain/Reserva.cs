using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionDeReservas.Domain
{
    public class Reserva
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdServicio { get; set; }
        public string Cliente { get; set; }
        public Servicio Servicio { get; set; }
        public ICollection<ReservaHorario> ReservaHorarios { get; set; }

    }
}
