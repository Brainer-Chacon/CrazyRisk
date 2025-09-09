using CrazyRisk.Core;
using CrazyRisk.Shared;
using System;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a Crazy Risk!");

        var juego = new Juego();

        // Crear jugadores
        juego.Jugadores.Add(new Jugador { Alias = "Jugador1", Color = ColorEjercito.Rojo });
        juego.Jugadores.Add(new Jugador { Alias = "Jugador2", Color = ColorEjercito.Azul });
        juego.Jugadores.Add(new Jugador { Alias = "Neutral", Color = ColorEjercito.Neutro });

        // Inicializar juego
        juego.InicializarJuego();

        Console.WriteLine("Territorios asignados a cada jugador:");
        foreach (var jugador in juego.Jugadores)
        {
            Console.WriteLine($"{jugador.Alias} ({jugador.Color}) controla:");
            foreach (var t in jugador.Territorios)
            {
                Console.WriteLine($"- {t.Nombre} con {t.Tropas} tropa(s)");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Comenzando el juego...\n");

        // Simulación de turnos
        Jugador ganador;
        int turno = 1;
        while (!juego.VerificarVictoria(out ganador))
        {
            Console.WriteLine($"=== Turno {turno} ===");
            foreach (var jugador in juego.Jugadores)
            {
                if (jugador.Territorios.Count == 0) continue; // jugador eliminado
                juego.TurnoJugador(jugador);
            }
            turno++;
            Thread.Sleep(1000); // Pausa visual
        }

        Console.WriteLine($"\n¡El ganador es {ganador.Alias} ({ganador.Color})!");
        Console.WriteLine("Juego finalizado.");
    }
}
