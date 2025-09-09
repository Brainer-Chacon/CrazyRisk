namespace CrazyRisk.Shared
{
    public enum TipoTarjeta
    {
        Infanteria,
        Caballeria,
        Artilleria
    }

    public class Tarjeta
    {
        public TipoTarjeta Tipo { get; set; }
        public Territorio TerritorioAsociado { get; set; }
        public Jugador Propietario { get; set; }

        // Constructor
        public Tarjeta(TipoTarjeta tipo, Territorio territorio)
        {
            Tipo = tipo;
            TerritorioAsociado = territorio;
        }

        public override string ToString()
        {
            string territorio = TerritorioAsociado != null ? TerritorioAsociado.Nombre : "Ninguno";
            string propietario = Propietario != null ? Propietario.Alias : "Sin dueño";
            return $"Tarjeta: {Tipo}, Territorio: {territorio}, Propietario: {propietario}";
        }
    }
}