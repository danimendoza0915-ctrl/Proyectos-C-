using System;
class Banco
{
    private static string Pin = "2232";
    private static string PinDinamico = " ";
    private static DateTime Tiempolimite;
    private static decimal Cantidad =24221.21m;
    static void Main()
    {
        if (Autentificacion())
        {
            Pindi();
            Menu();
        }
        else
        {
            Console.WriteLine("Se ha alcanzado el numero de intentos");
            Console.WriteLine("Acceso bloqueado");
        }
    }
    static void Menu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n Operaciones disponibles");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opcion: ");
            int opcion = Convert.ToInt16(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                Consulta(); break;
                case 2:
                Deposito();break;
                case 3:
                Retirar();break;
                case 4:
                salir =true;
                Console.WriteLine("Hata luego"); break;
                default:
                Console.WriteLine("Opcion no valida"); break;
            }
        }

    }
    static bool Autentificacion()
    {
        int intentos = 3;
        while (intentos > 0)
        {
            Console.WriteLine("\nBienvenido a Banca segura en linea");
            Console.Write("Ingrese su Pin de 4 digitos:  ");
            string PinIN = Console.ReadLine();
            if (PinIN == Pin)
            {
                Console.WriteLine("Ingreso exitoso");
                return true;
            }
            else
            {
                intentos--;
                Console.WriteLine($"Codigo incorrecto intento: {intentos} ");
            }
        }
        return false;
    }
    static void Pindi()
    {
        PinDinamico = new Random().Next(1000, 9999).ToString();
        Tiempolimite = DateTime.Now.AddSeconds(90);
        Console.WriteLine($"\nPin dinamico genrado es: ({PinDinamico}) valido hasta {Tiempolimite} ");
    }
    static bool ValidacionPinDi()
    {
        if (DateTime.Now > Tiempolimite) 
        {
            Console.WriteLine("El pin ya se ha vencido, genere otro pin");
            Pindi();
        }
        while (true)
        {
            Console.WriteLine($"\nSu pin dinamico es: ({PinDinamico})");   
            Console.Write("\nIngrese su Pin dinámico: ");
            string PinIngresado = Console.ReadLine();
            if (PinIngresado == PinDinamico)
        {
            return true;
        }
        else
        {
            Console.WriteLine("El pin dinámico ingresado es incorrecto, intente de nuevo.");
        }
    }
}
    static void Consulta()
    {
        if (ValidacionPinDi())
        {
            Console.WriteLine($"Su saldo es:${Cantidad:F2}");return;
        }
    }
    static void Deposito()
    {
        if (ValidacionPinDi())
        {
            Console.Write("Ingrese la cantidad que desea depositar:$");
            if (!decimal.TryParse(Console.ReadLine(), out decimal Depositar) || Depositar >= 0)
            {
                Cantidad += Depositar;
                Console.WriteLine($"Su nuevo saldo es:${Cantidad:F2}");return;
            }
            else
            {
                Console.WriteLine("El monto ingresado no es valido");return;
            }
        }
    }
    static void Retirar()
    {
        if (ValidacionPinDi())
        {
            Console.Write("Ingrese la cantidad que desea retirar:$");
            if (!decimal.TryParse(Console.ReadLine(), out decimal Retiro) || Retiro >= 0)
            {
                if (Retiro <= Cantidad)
                {
                    Cantidad -= Retiro;
                    Console.WriteLine($"Su nuevo saldo es:$ {Cantidad:F2}");return;
                }
                else 
                {
                Console.WriteLine("No se cuenta con el saldo suficiente");return;
                }
            }
            else
            {
                Console.WriteLine("El monto ingresado no es valido");return;
            }
        }
    }
}