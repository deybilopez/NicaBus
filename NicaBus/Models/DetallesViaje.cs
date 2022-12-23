namespace NicaBus.Models
{
    public class DetallesViaje
    {
        public int id { get; set; }
        public int acountId { get; set; }
        public string nameBus { get; set; }
        public string lugarEstacionamiento { get; set; }
        public int costo { get; set; }
        public string horaSalida { get; set; }
        public string horaLlegada { get; set; }
        public string destino { get; set; }
        public int idDestino { get; set; }

    }
}
