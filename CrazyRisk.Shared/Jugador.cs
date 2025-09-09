namespace CrazyRisk.Shared
{
    public enum ColorEjercito // Colores disponibles para los ejércitos de los jugadores
    {
        Rojo,
        Azul,
        Verde,
        Amarillo,
        Neutro
    }

    public class Jugador  //clase que representa a un jugador del juego
    {
        public string Alias { get; set; }  // Nombre del jugador
        public ColorEjercito Color { get; set; }  // Color de su ejército
        public int TropasDisponibles { get; set; } = 40; // Tropas iniciales

        // Territorios que controla
        public List<Territorio> Territorios { get; set; } = new List<Territorio>();

        // Tarjetas de refuerzo
        public List<Tarjeta> Tarjetas { get; set; } = new List<Tarjeta>();

        // ---------------- Métodos útiles ----------------

        // Agregar territorio al jugador
        public void AgregarTerritorio(Territorio territorio)
        {
            Territorios.Add(territorio);
            territorio.Propietario = this;
        }

        // Remover territorio del jugador
        public void RemoverTerritorio(Territorio territorio)
        {
            Territorios.Remove(territorio);
            territorio.Propietario = null;
        }

        // Agregar tarjeta
        public void AgregarTarjeta(Tarjeta tarjeta)
        {
            if (Tarjetas.Count < 5)
            {
                Tarjetas.Add(tarjeta);
                tarjeta.Propietario = this;
            }
            else
            {
                Console.WriteLine($"{Alias} ya tiene 5 tarjetas. Debe canjear un trío antes de recibir otra.");
            }
        }

        // Mostrar información del jugador
        public void MostrarInfo()
        {
            Console.WriteLine($"Jugador: {Alias}, Color: {Color}, Tropas Disponibles: {TropasDisponibles}");
            Console.WriteLine("Territorios:");
            foreach (var t in Territorios)
            {
                Console.WriteLine($"  - {t}");
            }
            Console.WriteLine("Tarjetas:");
            foreach (var tarjeta in Tarjetas)
            {
                Console.WriteLine($"  - {tarjeta}");
            }
        }
    }
}