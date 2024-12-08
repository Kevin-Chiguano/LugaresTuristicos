using ProyectoFinal.Models;  // Asegúrate de tener esta línea

namespace ProyectoFinal.Models
{
    public class Reservacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LugarId { get; set; }
        public string HoraItinerario { get; set; }

        public Usuario Usuario { get; set; }
        public Lugar Lugar { get; set; }
    }
}
