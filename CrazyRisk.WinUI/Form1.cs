using CrazyRisk.Core;
using CrazyRisk.Shared;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CrazyRisk.WinUI
{
    public partial class Form1 : Form
    {
        private Juego juego;   
        private int turnoActual = 0;
        private Button territorioSeleccionado = null;

        public Form1()
        {
            InitializeComponent();
            InicializarJuego();
        }

        private void InicializarJuego()
        {
            juego = new Juego();

            // Crear jugadores
            juego.Jugadores.Add(new Jugador { Alias = "Jugador1", Color = ColorEjercito.Rojo });
            juego.Jugadores.Add(new Jugador { Alias = "Jugador2", Color = ColorEjercito.Azul });
            juego.Jugadores.Add(new Jugador { Alias = "Neutral", Color = ColorEjercito.Neutro });

            // Inicializar mapa y territorios
            juego.InicializarJuego();

            ActualizarListBox();
            DibujarMapa();
        }

        private void buttonTurno_Click(object sender, EventArgs e)
        {
            if (juego.Jugadores.Count == 0) return;

            var jugador = juego.Jugadores[turnoActual];

            juego.TurnoJugador(jugador); // Ejecutar turno completo

            if (juego.VerificarVictoria(out Jugador ganador))
            {
                MessageBox.Show($"¡{ganador.Alias} ha ganado el juego!", "Victoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonTurno.Enabled = false;
                return;
            }

            turnoActual = (turnoActual + 1) % juego.Jugadores.Count;
            ActualizarListBox();
            DibujarMapa();
        }

        private void ActualizarListBox()
        {
            listBoxJugadores.Items.Clear();
            foreach (var jugador in juego.Jugadores)
            {
                listBoxJugadores.Items.Add($"{jugador.Alias} ({jugador.Color}) - Tropas: {jugador.TropasDisponibles}");
                foreach (var t in jugador.Territorios)
                    listBoxJugadores.Items.Add($"  - {t.Nombre}: {t.Tropas} tropas");
            }
        }

        private void DibujarMapa()
        {
            panelMapa.Controls.Clear();
            int x = 10, y = 10;
            int maxWidth = panelMapa.Width - 90;

            foreach (var territorio in juego.Mapa.Territorios)
            {
                var btn = new Button
                {
                    Text = $"{territorio.Nombre}\n{territorio.Tropas}",
                    Width = 90,
                    Height = 60,
                    Left = x,
                    Top = y,
                    BackColor = ObtenerColorJugador(territorio.Propietario),
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    Tag = territorio
                };

                btn.Click += Btn_Click;
                panelMapa.Controls.Add(btn);

                x += 100;
                if (x > maxWidth)
                {
                    x = 10;
                    y += 70;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var territorio = btn.Tag as Territorio;

            if (territorio.Propietario != juego.Jugadores[turnoActual])
            {
                MessageBox.Show("No puedes seleccionar territorios enemigos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            territorioSeleccionado = btn;
            MessageBox.Show($"{territorio.Nombre} seleccionado. Tropas: {territorio.Tropas}", "Territorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Color ObtenerColorJugador(Jugador jugador)
        {
            return jugador.Color switch
            {
                ColorEjercito.Rojo => Color.Red,
                ColorEjercito.Azul => Color.Blue,
                ColorEjercito.Neutro => Color.Gray,
                _ => Color.Black
            };
        }
    }
}