using System.Timers;
using Finanzas;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a Calculadora Financiera");

        Console.WriteLine("//CALCULADORA INTERES SIMPLE Y COMPUESTO//");
        // Solicitar datos para calcular interés simple
        Console.Write("Ingresa el capital inicial: $");
        double capital = Convert.ToDouble(Console.ReadLine());

        //TODO 1: Solicitar tasa de interés anual
        Console.Write("Ingrese la tasa de interes anual (%): ");
        double tasaInteres =Convert.ToDouble(Console.ReadLine());

        //TODO 2: Solicitar el tiempo en años
        Console.Write("Ingresa el tiempo en años: ");
        double tiempo =Convert.ToDouble(Console.ReadLine());

        // Calcular interés simple
        double interesSimple = FinanceCalculator.CalcularInteresSimple(capital, tasaInteres, tiempo);

        //TODO 3:Imprimir interes simple
        Console.WriteLine("El interes simplea pagar es " +  interesSimple);

        //TODO 4: Calcular interés compuesto
        double interesCompuesto = FinanceCalculator.CalcularInteresCompuesto(capital,tasaInteres,tiempo);

        //TODO 5: Imprimir interes compuesto
        Console.WriteLine("El interes compuesto a pagar es $" + interesCompuesto);

        Console.WriteLine("//CALCULADORA MENSUALIDADES//");
        //TODO 6: Solicitar datos para calcular mensualidad
        Console.Write("Ingrese el monto: $");
        double monto = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese el Interes (%): ");
        double interes = Convert.ToDouble(Console.ReadLine());

        //TODO 7: solicitar meses en que se pagará el prestamos
        Console.Write("Ingrese datos de mensualidad: ");
        int meses = Convert.ToInt32(Console.ReadLine());

        //TODO 8: Calcular y mostrar monto de la mensualidad
        double mensualidad = FinanceCalculator.CalcularMensualidad(monto,interes,meses);
        Console.Write("La mensualidad a pagar es $ " + mensualidad);
    }   
}
