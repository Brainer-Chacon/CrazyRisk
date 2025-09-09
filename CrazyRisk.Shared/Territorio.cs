namespace CrazyRisk.Shared
{
    public class Territorio
    {
        public string Nombre { get; set; } = "";
        public Jugador Propietario { get; set; }
        public int Tropas { get; set; } = 1;

        public List<Territorio> Adyacentes { get; set; } = new List<Territorio>();

        // ---------------- Métodos útiles ----------------

        // Verifica si puede atacar a algún territorio adyacente enemigo
        public bool PuedeAtacar()
        {
            return Tropas > 1 && Adyacentes.Any(t => t.Propietario != this.Propietario);
        }

        // Verifica si se puede mover tropas a un territorio adyacente controlado por el mismo jugador
        public bool PuedeMover()
        {
            return Tropas > 1 && Adyacentes.Any(t => t.Propietario == this.Propietario);
        }

        // Devuelve un listado de territorios adyacentes enemigos
        public List<Territorio> EnemigosAdyacentes()
        {
            return Adyacentes.Where(t => t.Propietario != this.Propietario).ToList();
        }

        // Devuelve un listado de territorios adyacentes aliados
        public List<Territorio> AliadosAdyacentes()
        {
            return Adyacentes.Where(t => t.Propietario == this.Propietario).ToList();
        }

        // Muestra información resumida del territorio
        public override string ToString()
        {
            string propietario = Propietario != null ? Propietario.Alias : "Neutral";
            return $"{Nombre} - Propietario: {propietario} - Tropas: {Tropas}";
        }
    }
}