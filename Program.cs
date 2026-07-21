using System;
using System.Collections.Generic;

class Program
{
    // ======= ESTRUCTURAS =======
    struct Estudiante
    {
        public int Id;
        public string Nombre;
        public string Carrera;
        public string Estatus;
        public List<string> Materias;
    }

    struct Solicitud
    {
        public string Tipo;
        public string Prioridad;
        public string Estado;
    }

    struct Pago
    {
        public string Concepto;
        public decimal Monto;
        public string Periodo;
    }

    // ======= LISTAS =======
    static List<Estudiante> estudiantes = new List<Estudiante>();
    static List<Solicitud> solicitudes = new List<Solicitud>();
    static List<Pago> pagos = new List<Pago>();

    // ======= MATERIAS DISPONIBLES =======
    static Dictionary<string, int> materias = new Dictionary<string, int>()
    {
        {"Programacion", 3},
        {"BasesDatos", 2},
        {"Redes", 2},
        {"Web", 4}
    };

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== SIGA — SISTEMA ACADEMICO =====");
            Console.WriteLine("1. Gestion Estudiantes");
            Console.WriteLine("2. Inscripciones");
            Console.WriteLine("3. Servicios Escolares");
            Console.WriteLine("4. Pagos");
            Console.WriteLine("5. Reportes");
            Console.WriteLine("0. Salir");

            switch (Console.ReadLine())
            {
                case "1": ModuloEstudiantes(); break;
                case "2": ModuloInscripciones(); break;
                case "3": ModuloServicios(); break;
                case "4": ModuloPagos(); break;
                case "5": Reportes(); break;
                case "0": return;
            }
        }
    }

    // ===============================
    static void ModuloEstudiantes()
    {
        Console.Clear();
        Console.WriteLine("=== Registro de Estudiante ===");

        Estudiante e = new Estudiante();
        e.Materias = new List<string>();

        Console.Write("ID: ");
        e.Id = int.Parse(Console.ReadLine());

        Console.Write("Nombre: ");
        e.Nombre = Console.ReadLine();

        Console.Write("Carrera: ");
        e.Carrera = Console.ReadLine();

        Console.Write("Estatus: ");
        e.Estatus = Console.ReadLine();

        estudiantes.Add(e);

        Console.WriteLine("Registrado ✔");
        Console.ReadKey();
    }

    // ===============================
    static void ModuloInscripciones()
    {
        Console.Clear();
        Console.WriteLine("=== Inscripcion ===");

        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes");
            Console.ReadKey();
            return;
        }

        MostrarEstudiantes();
        Console.Write("Seleccione ID: ");
        int id = int.Parse(Console.ReadLine());

        int index = estudiantes.FindIndex(x => x.Id == id);
        if (index == -1) return;

        Console.WriteLine("Materias disponibles:");
        foreach (var m in materias)
            Console.WriteLine($"{m.Key} — Cupo:{m.Value}");

        Console.Write("Materia: ");
        string mat = Console.ReadLine();

        if (materias.ContainsKey(mat) && materias[mat] > 0)
        {
            materias[mat]--;
            var est = estudiantes[index];
            est.Materias.Add(mat);
            estudiantes[index] = est;

            Console.WriteLine("Inscrito ✔");
        }
        else
            Console.WriteLine("Sin cupo ✖");

        Console.ReadKey();
    }

    // ===============================
    static void ModuloServicios()
    {
        Console.Clear();
        Console.WriteLine("=== Solicitud ===");

        Solicitud s = new Solicitud();

        Console.Write("Tipo: ");
        s.Tipo = Console.ReadLine();

        Console.Write("Prioridad: ");
        s.Prioridad = Console.ReadLine();

        s.Estado = "Registrado";

        solicitudes.Add(s);

        Console.WriteLine("Solicitud guardada ✔");
        Console.ReadKey();
    }

    // ===============================
    static void ModuloPagos()
    {
        Console.Clear();
        Console.WriteLine("=== Pagos ===");

        Pago p = new Pago();

        Console.Write("Concepto: ");
        p.Concepto = Console.ReadLine();

        Console.Write("Monto: ");
        p.Monto = decimal.Parse(Console.ReadLine());

        Console.Write("Periodo: ");
        p.Periodo = Console.ReadLine();

        Console.Write("Descuento % (0 si no): ");
        decimal d = decimal.Parse(Console.ReadLine());

        if (d > 0)
            p.Monto -= p.Monto * (d / 100);

        pagos.Add(p);

        Console.WriteLine("Pago registrado ✔");
        Console.ReadKey();
    }

    // ===============================
    static void Reportes()
    {
        Console.Clear();

        Console.WriteLine("=== REPORTE ESTUDIANTES ===");
        foreach (var e in estudiantes)
        {
            Console.WriteLine($"{e.Id} {e.Nombre} {e.Carrera} {e.Estatus}");
            Console.WriteLine("Materias: " + string.Join(",", e.Materias));
        }

        Console.WriteLine("\n=== REPORTE PAGOS ===");
        decimal total = 0;
        foreach (var p in pagos)
        {
            Console.WriteLine($"{p.Concepto} {p.Periodo} ${p.Monto}");
            total += p.Monto;
        }

        Console.WriteLine($"TOTAL: ${total}");

        Console.ReadKey();
    }

    // ===============================
    static void MostrarEstudiantes()
    {
        foreach (var e in estudiantes)
            Console.WriteLine($"{e.Id} — {e.Nombre}");
    }
}
