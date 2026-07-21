// Daniel Mendoza Gutierrez
using System;
using System.Globalization;
using System.Text.RegularExpressions;

// ===================== Excepciones Personalizadas =====================
#region
public class ValorNoNumericoException : Exception
{
    public ValorNoNumericoException() : base("El valor ingresado no es numérico.") { }
    public ValorNoNumericoException(string mensaje) : base(mensaje) { }
    public ValorNoNumericoException(string mensaje, Exception interna) : base(mensaje, interna) { }
}

public class ArregloVacioException : Exception
{
    public ArregloVacioException() : base("El arreglo está vacío. Primero debe ingresar los valores.") { }
    public ArregloVacioException(string mensaje) : base(mensaje) { }
    public ArregloVacioException(string mensaje, Exception interna) : base(mensaje, interna) { }
}
#endregion

class Programa
{
    static double[] temperaturas;

    // ===================== VALIDACIONES =====================

    // Validar valores numéricos
    static double ValidarNumero(string valor)
    {
        valor = valor.Replace(",", ".").Trim();

        if (!double.TryParse(valor, NumberStyles.Float, CultureInfo.InvariantCulture, out double numero))
        {
            throw new ValorNoNumericoException($"'{valor}' no es un número válido.");
        }

        return numero;
    }

    // Validar que el arreglo tenga valores
    static void ValidarArregloNoVacio()
    {
        if (temperaturas == null || temperaturas.Length == 0)
            throw new ArregloVacioException();
    }

    // ===================== CAPTURAR ARREGLO =====================
    static void IngresarArreglo()
    {
        try
        {
            Console.WriteLine("Ingrese las temperaturas separadas por espacio:");
            string entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
                throw new Exception("No se ingresaron valores.");

            string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double[] temporal = new double[partes.Length];

            for (int i = 0; i < partes.Length; i++)
            {
                temporal[i] = ValidarNumero(partes[i]);
            }

            temperaturas = temporal;

            Console.WriteLine("=========================================");
            Console.WriteLine("   Arreglo capturado correctamente");
            Console.WriteLine("=========================================");
        }
        catch (ValorNoNumericoException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Finalizando captura de temperaturas...\n");
        }
    }

    // ===================== MOSTRAR ARREGLO =====================
    static void MostrarArreglo()
    {
        try
        {
            ValidarArregloNoVacio();

            Console.WriteLine("Temperaturas ingresadas:");
            Console.WriteLine(string.Join(", ", temperaturas));
        }
        catch (ArregloVacioException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        finally
        {
            Console.WriteLine();
        }
    }

    // ===================== ORDENAR ARREGLO =====================
    static void OrdenarArreglo()
    {
        try
        {
            ValidarArregloNoVacio();

            double[] copia = (double[])temperaturas.Clone();

            double[] negativos = Array.FindAll(copia, t => t < 0);
            double[] positivos = Array.FindAll(copia, t => t >= 0);

            Array.Sort(positivos);               // ascendente
            Array.Sort(negativos);
            Array.Reverse(negativos);            // descendente

            Console.WriteLine("=========================================");
            Console.WriteLine(" Temperaturas ordenadas según la regla:");
            Console.WriteLine(" - Negativas: descendente");
            Console.WriteLine(" - No negativas: ascendente");
            Console.WriteLine("=========================================");

            Console.WriteLine("Negativas:   " + string.Join(", ", negativos));
            Console.WriteLine("No negativas:" + string.Join(", ", positivos));
        }
        catch (ArregloVacioException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        finally
        {
            Console.WriteLine();
        }
    }

    // ===================== MENÚ PRINCIPAL =====================
    static void Main()
    {
        int opcion = 0;
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("        SISTEMA DE TEMPERATURAS");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ingresar temperaturas");
            Console.WriteLine("2. Mostrar arreglo");
            Console.WriteLine("3. Ordenar arreglo");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string op = Console.ReadLine();

            if (!int.TryParse(op, out opcion))
            {
                Console.WriteLine("Debe ingresar un número entero.\n");
                continue;
            }

            Console.WriteLine();

            switch (opcion)
            {
                case 1: IngresarArreglo(); break;
                case 2: MostrarArreglo(); break;
                case 3: OrdenarArreglo(); break;
                case 4:
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.\n");
                    break;
            }
        }
    }
}

