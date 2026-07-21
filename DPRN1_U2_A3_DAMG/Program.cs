using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizadorEnergiaDomotica
{
    // ============================
    // Clase base
    // ============================
    public class GestorConsumo
    {
        public string IdVivienda { get; set; }
        public string PerfilOriginal { get; set; } = "";   // e.g. "4567823"
        public string PerfilOptimizado { get; set; } = "";
        public DateTime FechaRegistro { get; set; }

        public GestorConsumo(string idVivienda, string perfilOriginal)
        {
            IdVivienda = idVivienda;
            PerfilOriginal = perfilOriginal ?? "";
            PerfilOptimizado = PerfilOriginal;
            FechaRegistro = DateTime.Now;
        }

        // Convierte perfil string a lista de ints (cada char = dígito '1'..'9').
        protected List<int> PerfilToList(string perfil)
        {
            var list = new List<int>();
            if (string.IsNullOrWhiteSpace(perfil)) return list;
            foreach (char c in perfil)
            {
                if (char.IsDigit(c))
                {
                    int v = c - '0';
                    // Aseguramos rango mínimo 1
                    if (v < 1) v = 1;
                    list.Add(v);
                }
            }
            return list;
        }

        // Convierte lista ints a perfil string
        protected string ListToPerfilString(List<int> list)
        {
            if (list == null) return "";
            return string.Join("", list.Select(x => Math.Max(1, x).ToString()));
        }

        // Método virtual: aplica estrategia concreta (sobrescribir en derivados)
        public virtual void OptimizarConsumo()
        {
            // Por defecto: no cambia nada
            PerfilOptimizado = PerfilOriginal;
        }

        // Restaurar perfil original
        public virtual void RestaurarPerfil()
        {
            PerfilOptimizado = PerfilOriginal;
        }

        // Calcula costo total usando tarifa por kWh (por defecto 0.15 MXN)
        public virtual double CalcularCostoTotal(double tarifa = 0.15)
        {
            var list = PerfilToList(PerfilOptimizado);
            return list.Sum() * tarifa;
        }

        // Utilitarios para mostrar perfiles
        public void MostrarPerfiles()
        {
            Console.WriteLine($"Vivienda: {IdVivienda}  (registro: {FechaRegistro})");
            Console.WriteLine($"Perfil original:   {PerfilOriginal}");
            Console.WriteLine($"Perfil optimizado: {PerfilOptimizado}");
        }

        // Suma kWh de un perfil
        public double SumaPerfilOriginal()
        {
            return PerfilToList(PerfilOriginal).Sum();
        }
        public double SumaPerfilOptimizado()
        {
            return PerfilToList(PerfilOptimizado).Sum();
        }
    }

    // ============================
    // GestorTarifaHoraria
    // ============================
    public class GestorTarifaHoraria : GestorConsumo
    {
        public List<int> HorasPico { get; set; } = new List<int>(); // índices 0-based
        public int PorcentajeReduccion { get; set; } = 10; // 10-50
        public double TarifaPico { get; set; } = 0.25;
        public double TarifaValle { get; set; } = 0.10;

        public GestorTarifaHoraria(string idVivienda, string perfilOriginal)
            : base(idVivienda, perfilOriginal) { }

        // Optimiza reduciendo consumo en horas pico
        public override void OptimizarConsumo()
        {
            var arr = PerfilToList(PerfilOriginal);
            // Aseguramos que PerfilOptimizado tenga mismo tamaño
            var optim = new List<int>(arr);

            foreach (int i in HorasPico)
            {
                if (i < 0 || i >= optim.Count) continue;
                double consumo = arr[i];
                double nuevo = consumo * (100 - PorcentajeReduccion) / 100.0;
                if (nuevo < 1) nuevo = 1;
                optim[i] = (int)Math.Round(nuevo, MidpointRounding.AwayFromZero);
                if (optim[i] < 1) optim[i] = 1;
            }

            PerfilOptimizado = ListToPerfilString(optim);
        }

        // Calcula costo considerando tarifas pico/valle
        public override double CalcularCostoTotal(double tarifa = 0.15)
        {
            var optim = PerfilToList(PerfilOptimizado);
            double costo = 0.0;
            for (int i = 0; i < optim.Count; i++)
            {
                int consumo = optim[i];
                if (HorasPico.Contains(i))
                    costo += consumo * TarifaPico;
                else
                    costo += consumo * TarifaValle;
            }
            return costo;
        }
    }

    // ============================
    // GestorSolar
    // ============================
    public class GestorSolar : GestorConsumo
    {
        public List<int> HorasSolares { get; set; } = new List<int>(); // índices 0-based
        public int GeneracionPorHora { get; set; } = 1; // 1-5 kWh
        public double CapacidadInstalada { get; set; } = 1.0; // kW (no usado en cálculo directo, pero se guarda)
        public int EficienciaActual { get; set; } = 100; // 80-100 %

        public GestorSolar(string idVivienda, string perfilOriginal)
            : base(idVivienda, perfilOriginal) { }

        public override void OptimizarConsumo()
        {
            var arr = PerfilToList(PerfilOriginal);
            var optim = new List<int>(arr);

            double factor = EficienciaActual / 100.0;
            foreach (int i in HorasSolares)
            {
                if (i < 0 || i >= optim.Count) continue;
                double consumo = arr[i];
                double generacion = GeneracionPorHora * factor;
                double nuevo = consumo - generacion;
                if (nuevo < 1) nuevo = 1;
                optim[i] = (int)Math.Round(nuevo, MidpointRounding.AwayFromZero);
                if (optim[i] < 1) optim[i] = 1;
            }

            PerfilOptimizado = ListToPerfilString(optim);
        }

        // Calcula ahorro en kWh y en dinero (usando 0.15 MXN/kWh)
        public (double ahorro_kWh, double ahorro_mxn) CalcularAhorroSolar()
        {
            double sOrig = SumaPerfilOriginal();
            double sOpt = SumaPerfilOptimizado();
            double ahorro_kWh = sOrig - sOpt;
            double ahorro_dinero = ahorro_kWh * 0.15;
            return (ahorro_kWh, ahorro_dinero);
        }
    }

    // ============================
    // GestorInteligenteDemanda (hereda de GestorSolar)
    // ============================
    public class GestorInteligenteDemanda : GestorSolar
    {
        public string AlgoritmoML { get; set; } = "ReglaSimple";
        public int NivelBalanceo { get; set; } = 1; // 1-3
        public string SenalRed { get; set; } = "Normal"; // "Normal","Alerta","Critico"

        public GestorInteligenteDemanda(string idVivienda, string perfilOriginal)
            : base(idVivienda, perfilOriginal) { }

        public override void OptimizarConsumo()
        {
            // 1) Ejecutar optimización del padre (reducción por generación solar si aplica)
            base.OptimizarConsumo();

            // Trabajaremos sobre PerfilOptimizado
            var optim = PerfilToList(PerfilOptimizado);

            // 2) Balanceo de curva: repetir NivelBalanceo veces
            for (int r = 0; r < NivelBalanceo; r++)
            {
                bool changed = true;
                // Repetir mientras exista diferencia mayor a 2 entre pico y valle
                while (true)
                {
                    if (optim.Count == 0) break;
                    int maxVal = optim.Max();
                    int minVal = optim.Min();
                    if ((maxVal - minVal) <= 2) break;

                    int posPico = optim.IndexOf(maxVal);
                    int posValle = optim.IndexOf(minVal);

                    // Ajuste: decrementar pico y aumentar valle
                    optim[posPico] = Math.Max(1, optim[posPico] - 1);
                    optim[posValle] = optim[posValle] + 1;
                }
            }

            // 3) Si señal crítica, limitar consumos > 6 a 6
            if (SenalRed.Equals("Critico", StringComparison.OrdinalIgnoreCase))
            {
                for (int i = 0; i < optim.Count; i++)
                {
                    if (optim[i] > 6) optim[i] = 6;
                }
            }

            PerfilOptimizado = ListToPerfilString(optim);
        }
    }

    // ============================
    // GestorMultiDispositivo (hereda de GestorTarifaHoraria)
    // ============================
    public class GestorMultiDispositivo : GestorTarifaHoraria
    {
        // TipoGestion: "Casa-Completa" (perfil string) o "Dispositivos-Individuales" (double[])
        public string TipoGestion { get; set; } = "Casa-Completa";
        public int LimiteCapacidad { get; set; } = 9; // límite por hora si se trabaja con string perfiles
        public int[] PrioridadesDispositivos { get; set; } = new int[0]; // correspondencia con double[] dispositivos
        public double ConsumoMinimo { get; set; } = 0.1; // kWh mínimo por dispositivo

        public GestorMultiDispositivo(string idVivienda, string perfilOriginal)
            : base(idVivienda, perfilOriginal) { }

        // Sobrecarga: OptimizarConsumo() sin parámetros -> usa el perfil (string) aplicando reducciones y límites
        public override void OptimizarConsumo()
        {
            if (TipoGestion == "Casa-Completa")
            {
                // Aplicar reducción por horas pico heredada
                base.OptimizarConsumo();
                // Luego aplicar límite de capacidad por hora
                var optim = PerfilToList(PerfilOptimizado);
                for (int i = 0; i < optim.Count; i++)
                {
                    if (optim[i] > LimiteCapacidad) optim[i] = LimiteCapacidad;
                }
                PerfilOptimizado = ListToPerfilString(optim);
            }
            else
            {
                // Si TipoGestion es Dispositivos-Individuales, no hay perfil string para manejar aquí.
                // Mantener igual o lanzar aviso
                // No cambia PerfilOptimizado
            }
        }

        // Sobrecarga: OptimizarConsumo para lista de dispositivos (double[])
        // Este método administra consumos por dispositivo respetando prioridades y ConsumoMinimo
        public void OptimizarConsumo(double[] dispositivos)
        {
            if (dispositivos == null || dispositivos.Length == 0)
            {
                Console.WriteLine("No hay dispositivos para optimizar.");
                return;
            }

            int n = dispositivos.Length;
            // Asociamos cada dispositivo con su prioridad (si no existe, prioridad 1)
            int[] prioridades = new int[n];
            for (int i = 0; i < n; i++)
            {
                prioridades[i] = (i < PrioridadesDispositivos.Length) ? PrioridadesDispositivos[i] : 1;
            }

            // 1) ordenar por prioridad ascendente -> obtenemos índices ordenados
            var indicesOrdenadosAsc = Enumerable.Range(0, n).OrderBy(i => prioridades[i]).ToArray();

            // 2) calculamos consumo total y objetivo (reducir 30%)
            double consumoTotal = dispositivos.Sum();
            double objetivo = consumoTotal * 0.7; // reducir 30%
            double diferencia = consumoTotal - objetivo;

            // 3) recorrer en orden descendente de prioridad (según el enunciado)
            var indicesDesc = indicesOrdenadosAsc.Reverse().ToArray();

            double[] consumos = (double[])dispositivos.Clone();

            foreach (int idx in indicesDesc)
            {
                if (diferencia <= 0) break;

                int prioridad = prioridades[idx];
                // Sólo reducimos si prioridad >= 3 (según enunciado)
                if (prioridad >= 3)
                {
                    double reducible = consumos[idx] - ConsumoMinimo;
                    if (reducible <= 0) continue;

                    if (reducible >= diferencia)
                    {
                        consumos[idx] -= diferencia;
                        diferencia = 0;
                        break;
                    }
                    else
                    {
                        consumos[idx] = ConsumoMinimo;
                        diferencia -= reducible;
                    }
                }
            }

            // Mostrar resultado
            Console.WriteLine("Consumo original por dispositivo:");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"  Dispositivo {i + 1}: {dispositivos[i]:F2} kWh  (Prioridad {prioridades[i]})");

            Console.WriteLine("\nConsumo optimizado por dispositivo:");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"  Dispositivo {i + 1}: {consumos[i]:F2} kWh  (Prioridad {prioridades[i]})");

            double sumaNew = consumos.Sum();
            double ahorro = consumoTotal - sumaNew;
            Console.WriteLine($"\nConsumo total original: {consumoTotal:F2} kWh");
            Console.WriteLine($"Consumo total optimizado: {sumaNew:F2} kWh");
            Console.WriteLine($"Ahorro: {ahorro:F2} kWh  → ${ahorro * 0.15:F2} MXN (tarifa base)");
        }
    }

    // ============================
    // Menú interactivo
    // ============================
    public static class Menu
    {
        public static void Run()
        {
            GestorConsumo gestor = null;

            while (true)
            {
                Console.WriteLine("\n==== SISTEMA DE OPTIMIZACIÓN ENERGÉTICA DOMÓTICA ====");
                Console.WriteLine("1) Crear Gestor: Tarifa Horaria");
                Console.WriteLine("2) Crear Gestor: Solar");
                Console.WriteLine("3) Crear Gestor: Inteligente Demanda");
                Console.WriteLine("4) Crear Gestor: MultiDispositivo");
                Console.WriteLine("5) Configurar perfil en gestor actual");
                Console.WriteLine("6) Ejecutar optimización en gestor actual");
                Console.WriteLine("7) Restaurar perfil en gestor actual");
                Console.WriteLine("8) Mostrar perfiles / costos / ahorros");
                Console.WriteLine("9) Optimizar lista de dispositivos (solo MultiDispositivo)");
                Console.WriteLine("0) Salir");
                Console.Write("Seleccione opción: ");
                string opt = Console.ReadLine();

                if (!int.TryParse(opt, out int opcion)) { Console.WriteLine("Opción no válida."); continue; }

                switch (opcion)
                {
                    case 0:
                        return;

                    case 1:
                        {
                            Console.Write("Id vivienda: ");
                            string id = Console.ReadLine();
                            Console.Write("Perfil (ej. 4567823): ");
                            string perfil = Console.ReadLine();
                            var g = new GestorTarifaHoraria(id, perfil);
                            Console.Write("Ingrese horas pico separadas por coma (índices 0-based, ej. 1,2): ");
                            string hs = Console.ReadLine();
                            g.HorasPico = ParseIndices(hs);
                            Console.Write("Porcentaje reducción (10-50): ");
                            if (int.TryParse(Console.ReadLine(), out int pr)) g.PorcentajeReduccion = Math.Clamp(pr, 10, 50);
                            Console.Write("Tarifa pico (ej. 0.25): ");
                            if (double.TryParse(Console.ReadLine(), out double tp)) g.TarifaPico = tp;
                            Console.Write("Tarifa valle (ej. 0.10): ");
                            if (double.TryParse(Console.ReadLine(), out double tv)) g.TarifaValle = tv;
                            gestor = g;
                            Console.WriteLine("Gestor Tarifa Horaria creado.");
                        }
                        break;

                    case 2:
                        {
                            Console.Write("Id vivienda: ");
                            string id = Console.ReadLine();
                            Console.Write("Perfil (ej. 4567823): ");
                            string perfil = Console.ReadLine();
                            var g = new GestorSolar(id, perfil);
                            Console.Write("Horas solares (indices 0-based, ej. 2,3): ");
                            g.HorasSolares = ParseIndices(Console.ReadLine());
                            Console.Write("Generacion por hora (1-5): ");
                            if (int.TryParse(Console.ReadLine(), out int gen)) g.GeneracionPorHora = Math.Clamp(gen, 1, 5);
                            Console.Write("Eficiencia actual (80-100): ");
                            if (int.TryParse(Console.ReadLine(), out int eff)) g.EficienciaActual = Math.Clamp(eff, 80, 100);
                            Console.Write("Capacidad instalada (kW) (opcional): ");
                            if (double.TryParse(Console.ReadLine(), out double cap)) g.CapacidadInstalada = cap;
                            gestor = g;
                            Console.WriteLine("Gestor Solar creado.");
                        }
                        break;

                    case 3:
                        {
                            Console.Write("Id vivienda: ");
                            string id = Console.ReadLine();
                            Console.Write("Perfil (ej. 4567823): ");
                            string perfil = Console.ReadLine();
                            var g = new GestorInteligenteDemanda(id, perfil);
                            Console.Write("Horas solares (indices 0-based, ej. 2,3): ");
                            g.HorasSolares = ParseIndices(Console.ReadLine());
                            Console.Write("Generacion por hora (1-5): ");
                            if (int.TryParse(Console.ReadLine(), out int gen)) g.GeneracionPorHora = Math.Clamp(gen, 1, 5);
                            Console.Write("Eficiencia actual (80-100): ");
                            if (int.TryParse(Console.ReadLine(), out int eff)) g.EficienciaActual = Math.Clamp(eff, 80, 100);
                            Console.Write("Nivel Balanceo (1-3): ");
                            if (int.TryParse(Console.ReadLine(), out int nb)) g.NivelBalanceo = Math.Clamp(nb, 1, 3);
                            Console.Write("Señal red (Normal/Alerta/Critico): ");
                            string s = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(s)) g.SenalRed = s;
                            gestor = g;
                            Console.WriteLine("Gestor Inteligente de Demanda creado.");
                        }
                        break;

                    case 4:
                        {
                            Console.Write("Id vivienda: ");
                            string id = Console.ReadLine();
                            Console.Write("Perfil (ej. 4567823): ");
                            string perfil = Console.ReadLine();
                            var g = new GestorMultiDispositivo(id, perfil);
                            Console.Write("Tipo gestion (Casa-Completa / Dispositivos-Individuales): ");
                            string t = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(t)) g.TipoGestion = t;
                            Console.Write("Horas pico (indices 0-based, ej. 1,2): ");
                            g.HorasPico = ParseIndices(Console.ReadLine());
                            Console.Write("Porcentaje reducción (10-50): ");
                            if (int.TryParse(Console.ReadLine(), out int pr)) g.PorcentajeReduccion = Math.Clamp(pr, 10, 50);
                            Console.Write("Limite capacidad por hora (int): ");
                            if (int.TryParse(Console.ReadLine(), out int lim)) g.LimiteCapacidad = Math.Max(1, lim);
                            Console.Write("Consumo mínimo por dispositivo (ej. 0.1): ");
                            if (double.TryParse(Console.ReadLine(), out double cm)) g.ConsumoMinimo = Math.Max(0.0, cm);

                            Console.Write("Prioridades dispositivos (opcional, ej. 1,2,3): ");
                            var prios = ParseIndices(Console.ReadLine());
                            if (prios != null && prios.Count > 0) g.PrioridadesDispositivos = prios.ToArray();

                            gestor = g;
                            Console.WriteLine("Gestor MultiDispositivo creado.");
                        }
                        break;

                    case 5:
                        if (gestor == null) { Console.WriteLine("No hay gestor creado."); break; }
                        Console.Write("Ingrese nuevo perfil (ej. 4567823): ");
                        string perfilNew = Console.ReadLine();
                        gestor.PerfilOriginal = perfilNew;
                        gestor.RestaurarPerfil();
                        gestor.FechaRegistro = DateTime.Now;
                        Console.WriteLine("Perfil actualizado y restaurado.");
                        break;

                    case 6:
                        if (gestor == null) { Console.WriteLine("No hay gestor creado."); break; }
                        gestor.OptimizarConsumo();
                        Console.WriteLine("Optimización ejecutada.");
                        break;

                    case 7:
                        if (gestor == null) { Console.WriteLine("No hay gestor creado."); break; }
                        gestor.RestaurarPerfil();
                        Console.WriteLine("Perfil restaurado al original.");
                        break;

                    case 8:
                        if (gestor == null) { Console.WriteLine("No hay gestor creado."); break; }
                        gestor.MostrarPerfiles();
                        // Mostrar costo por defecto y, si aplica, info extra
                        double costo = gestor.CalcularCostoTotal();
                        Console.WriteLine($"Costo total estimado (tarifa base 0.15): ${costo:F2} MXN");
                        // Si es GestorSolar, mostrar ahorro
                        if (gestor is GestorSolar gs)
                        {
                            var (ahKwh, ahMxn) = gs.CalcularAhorroSolar();
                            Console.WriteLine($"Ahorro solar: {ahKwh:F2} kWh  → ${ahMxn:F2} MXN");
                        }
                        break;

                    case 9:
                        if (gestor == null) { Console.WriteLine("No hay gestor creado."); break; }
                        if (gestor is GestorMultiDispositivo gm)
                        {
                            Console.Write("Ingrese consumos por dispositivo separados por coma (ej. 1.2,0.5,2.0): ");
                            string line = Console.ReadLine();
                            var parts = (line ?? "").Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                            double[] disp = parts.Select(p =>
                            {
                                if (double.TryParse(p.Trim(), out double v)) return v;
                                return 0.0;
                            }).ToArray();
                            if (disp.Length == 0) { Console.WriteLine("No se detectaron consumos válidos."); break; }
                            // Si hay prioridades almacenadas se usan
                            gm.OptimizarConsumo(disp);
                        }
                        else
                        {
                            Console.WriteLine("El gestor actual no es MultiDispositivo.");
                        }
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }

        private static List<int> ParseIndices(string s)
        {
            var res = new List<int>();
            if (string.IsNullOrWhiteSpace(s)) return res;
            var parts = s.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in parts)
            {
                if (int.TryParse(p.Trim(), out int idx))
                    res.Add(idx);
            }
            return res;
        }
    }

    // ============================
    // Program
    // ============================
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Run();
        }
    }
}

