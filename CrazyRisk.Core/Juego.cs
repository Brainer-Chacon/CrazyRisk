using CrazyRisk.Shared;
using System;

namespace CrazyRisk.Core
{
    public class Juego   //clase principal del juego
    {
        public List<Jugador> Jugadores { get; set; } = new List<Jugador>();
        public Mapa Mapa { get; set; } = new Mapa();

        public void InicializarJuego()
        {
            // Inicializar mapa y territorios
            Mapa.InicializarMapa();

            // Distribuir territorios entre jugadores y ejército neutro
            DistribuirTerritorios();

            // Colocar tropas iniciales
            ColocarTropasIniciales();
        }

        public void DistribuirTerritorios()
        {
            var territorios = Mapa.Territorios.OrderBy(t => Guid.NewGuid()).ToList();
            int jugadorIndex = 0;

            foreach (var territorio in territorios)
            {
                var jugador = Jugadores[jugadorIndex];
                territorio.Propietario = jugador;
                jugador.Territorios.Add(territorio);

                jugadorIndex++;
                if (jugadorIndex >= Jugadores.Count) jugadorIndex = 0;
            }
        }

        public void ColocarTropasIniciales()
        {
            foreach (var jugador in Jugadores)
            {
                foreach (var territorio in jugador.Territorios)
                {
                    jugador.TropasDisponibles--;
                    territorio.Tropas = 1;
                }
            }
        }

        // ---------------- Refuerzos ----------------
        public void CalcularRefuerzos(Jugador jugador)
        {
            int refuerzos = Math.Max(jugador.Territorios.Count / 3, 3);
            refuerzos += BonificacionContinentes(jugador);

            jugador.TropasDisponibles += refuerzos;
            Console.WriteLine($"{jugador.Alias} recibe {refuerzos} tropas de refuerzo. Total disponibles: {jugador.TropasDisponibles}");
        }

        private int BonificacionContinentes(Jugador jugador)
        {
            int bonus = 0;
            var continentes = new Dictionary<string, int>
            {
                { "Asia", 7 },
                { "Europa", 5 },
                { "América del Norte", 3 },
                { "África", 3 },
                { "América del Sur", 2 },
                { "Oceanía", 2 }
            };

            foreach (var c in continentes)
            {
                if (jugador.Territorios.All(t => t.Nombre.Contains(c.Key)))
                {
                    bonus += c.Value;
                }
            }

            return bonus;
        }

        // ---------------- Turno del jugador ----------------
        public void TurnoJugador(Jugador jugador)
        {
            Console.WriteLine($"\n--- Turno de {jugador.Alias} ---");

            // Refuerzos
            CalcularRefuerzos(jugador);
            ColocarTropas(jugador);

            // Ataques
            RealizarAtaques(jugador);

            // Movimientos
            MoverTropasJugador(jugador);
        }

        // ---------------- Colocar tropas ----------------
        private void ColocarTropas(Jugador jugador)
        {
            while (jugador.TropasDisponibles > 0)
            {
                var territorio = jugador.Territorios[new Random().Next(jugador.Territorios.Count)];
                territorio.Tropas++;
                jugador.TropasDisponibles--;
            }
        }

        // ---------------- Ataques ----------------
        private void RealizarAtaques(Jugador jugador)
        {
            foreach (var territorio in jugador.Territorios)
            {
                if (territorio.Tropas < 2) continue;

                foreach (var enemigo in territorio.Adyacentes.Where(t => t.Propietario != jugador))
                {
                    Ataque(territorio, enemigo);
                }
            }
        }

        private void Ataque(Territorio atacante, Territorio defensor)
        {
            var rnd = new Random();
            int tropasAtacante = Math.Min(3, atacante.Tropas - 1);
            int tropasDefensor = Math.Min(2, defensor.Tropas);

            var dadosAtacante = new List<int>();
            var dadosDefensor = new List<int>();

            for (int i = 0; i < tropasAtacante; i++) dadosAtacante.Add(rnd.Next(1, 7));
            for (int i = 0; i < tropasDefensor; i++) dadosDefensor.Add(rnd.Next(1, 7));

            dadosAtacante.Sort((a, b) => b.CompareTo(a));
            dadosDefensor.Sort((a, b) => b.CompareTo(a));

            int comparaciones = Math.Min(dadosAtacante.Count, dadosDefensor.Count);
            for (int i = 0; i < comparaciones; i++)
            {
                if (dadosAtacante[i] > dadosDefensor[i])
                    defensor.Tropas--;
                else
                    atacante.Tropas--;
            }

            // Conquista
            if (defensor.Tropas <= 0)
            {
                defensor.Propietario.Territorios.Remove(defensor);
                defensor.Propietario = atacante.Propietario;
                atacante.Propietario.Territorios.Add(defensor);

                int mover = tropasAtacante; // mover tropas mínimo
                atacante.Tropas -= mover;
                defensor.Tropas = mover;

                Console.WriteLine($"{atacante.Propietario.Alias} conquistó {defensor.Nombre}!");
            }
        }

        // ---------------- Movimientos ----------------
        private void MoverTropasJugador(Jugador jugador)
        {
            foreach (var t in jugador.Territorios)
            {
                var ady = t.Adyacentes.FirstOrDefault(a => a.Propietario == jugador);
                if (ady != null && t.Tropas > 1)
                {
                    int mover = (t.Tropas - 1) / 2;
                    t.Tropas -= mover;
                    ady.Tropas += mover;
                }
            }
        }

        // ---------------- Verificar victoria ----------------
        public bool VerificarVictoria(out Jugador ganador)
        {
            ganador = Jugadores.FirstOrDefault(j => j.Territorios.Count == Mapa.Territorios.Count);
            return ganador != null;
        }
    }
}