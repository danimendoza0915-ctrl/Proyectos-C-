using System;
class Programa
{
    static void Main()
    {
        int Numero, Numerofactores = 0;
        do
        {
            Console.Write("Ingrese un numero: ");
            int.TryParse(Console.ReadLine(), out Numero);
        } while (Numero <= 0);
        int NumeroIngresado = Numero;
        Console.Write(+NumeroIngresado + "= ");
        for (int Divisor = 2; Numero > 1; Divisor++)
        {
            int Veces = 0;
            while (Numero % Divisor == 0)
            {
                Veces++;
                Numero /= Divisor;
            }
            if (Veces > 0)
            {
                if (Numerofactores > 0) Console.Write(" + ");
                Console.Write(+Divisor + "^" + Veces);
                Numerofactores++;
            }
        }
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla para salir");
        Console.ReadKey();
    }
}