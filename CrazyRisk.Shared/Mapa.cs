namespace CrazyRisk.Shared
{
    public class Mapa
    {
        public List<Territorio> Territorios { get; set; } = new List<Territorio>();

        public void InicializarMapa()
        {
            // ---------------- Continentes y territorios ----------------
            // Asia (7)
            var asia1 = new Territorio { Nombre = "China" };
            var asia2 = new Territorio { Nombre = "India" };
            var asia3 = new Territorio { Nombre = "Rusia" };
            var asia4 = new Territorio { Nombre = "Japón" };
            var asia5 = new Territorio { Nombre = "Irán" };
            var asia6 = new Territorio { Nombre = "Turquía" };
            var asia7 = new Territorio { Nombre = "Arabia Saudita" };

            // Europa (5)
            var eu1 = new Territorio { Nombre = "España" };
            var eu2 = new Territorio { Nombre = "Francia" };
            var eu3 = new Territorio { Nombre = "Alemania" };
            var eu4 = new Territorio { Nombre = "Reino Unido" };
            var eu5 = new Territorio { Nombre = "Italia" };

            // América del Norte (3)
            var amn1 = new Territorio { Nombre = "USA" };
            var amn2 = new Territorio { Nombre = "Canadá" };
            var amn3 = new Territorio { Nombre = "México" };

            // África (3)
            var af1 = new Territorio { Nombre = "Egipto" };
            var af2 = new Territorio { Nombre = "Sudáfrica" };
            var af3 = new Territorio { Nombre = "Nigeria" };

            // América del Sur (2)
            var ams1 = new Territorio { Nombre = "Brasil" };
            var ams2 = new Territorio { Nombre = "Argentina" };

            // Oceanía (2)
            var oc1 = new Territorio { Nombre = "Australia" };
            var oc2 = new Territorio { Nombre = "Nueva Zelanda" };

            // ---------------- Lista completa ----------------
            Territorios.AddRange(new[] {
                asia1, asia2, asia3, asia4, asia5, asia6, asia7,
                eu1, eu2, eu3, eu4, eu5,
                amn1, amn2, amn3,
                af1, af2, af3,
                ams1, ams2,
                oc1, oc2
            });

            // ---------------- Adyacencias ejemplo ----------------
            // Asia
            asia1.Adyacentes.AddRange(new[] { asia2, asia3, eu5 });
            asia2.Adyacentes.AddRange(new[] { asia1, asia3, asia5 });
            asia3.Adyacentes.AddRange(new[] { asia1, asia2, eu3 });
            asia4.Adyacentes.AddRange(new[] { asia1, asia2 });
            asia5.Adyacentes.AddRange(new[] { asia2, asia6 });
            asia6.Adyacentes.AddRange(new[] { asia5, asia3 });
            asia7.Adyacentes.AddRange(new[] { asia5 });

            // Europa
            eu1.Adyacentes.AddRange(new[] { eu2, eu5 });
            eu2.Adyacentes.AddRange(new[] { eu1, eu3 });
            eu3.Adyacentes.AddRange(new[] { eu2, eu4, asia3 });
            eu4.Adyacentes.AddRange(new[] { eu3, eu5 });
            eu5.Adyacentes.AddRange(new[] { eu1, eu4, asia1 });

            // América del Norte
            amn1.Adyacentes.AddRange(new[] { amn2, amn3 });
            amn2.Adyacentes.AddRange(new[] { amn1 });
            amn3.Adyacentes.AddRange(new[] { amn1 });

            // África
            af1.Adyacentes.AddRange(new[] { af2, af3 });
            af2.Adyacentes.AddRange(new[] { af1 });
            af3.Adyacentes.AddRange(new[] { af1 });

            // América del Sur
            ams1.Adyacentes.Add(ams2);
            ams2.Adyacentes.Add(ams1);

            // Oceanía
            oc1.Adyacentes.Add(oc2);
            oc2.Adyacentes.Add(oc1);
        }

        // Obtener territorios por continente (opcional)
        public List<Territorio> ObtenerPorContinente(string continente)
        {
            return Territorios.Where(t => t.Nombre.Contains(continente)).ToList();
        }
    }
}