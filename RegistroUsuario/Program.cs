using System;
using System.Text;
using System.Text.RegularExpressions;
class Validaciones
{
    public static bool ValidarUsuario(string Nombre, out string MensajeN)
    {
        if (Nombre.Length >= 5)
        {
            MensajeN = "El Nombre es Valido";
            return true;
        }
        else
        {
            MensajeN = "El nombre requiere de al menos 5 caracteres";
            return false;
        }
    }
    public static bool ValidarContraseña(String Contraseña, out string MensajeC)
    {
        if (Regex.IsMatch(Contraseña, @"^(?=.*[A-Z])(?=.*\d).{8,}$"))
        {
            MensajeC = "La Contraseña es Valida";
            return true;
        }
        else
        {
            MensajeC = "Contraseña Invalidad debe tener al menos 8 caracteres, incluir una mayúscula, una minúscula y un número";
            return false;
        }
    }
    public static bool ValidarCorreo(String Correo, out string MensajeCO)
    {
        if (Regex.IsMatch(Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            MensajeCO = "El correo es valido ";
            return true;
        }
        else
        {
            MensajeCO = "El formato del correo no es valido";
            return false;
        }
    }
    public static (string, string, string) DatosAleatorio()
    {
        string Nombre = "Usaurio" + new Random().Next(10000, 99999);
        string contraseña = ContraseñaAleatoria();
        string Correo = Nombre.ToString() + "@gmail.com";
        return (Nombre, contraseña, Correo);
    }
    public static string ContraseñaAleatoria()
    {
        Random rand = new Random();
        StringBuilder Contraseña = new StringBuilder();
        Contraseña.Append((char)rand.Next(65, 91));
        Contraseña.Append(rand.Next(0, 10));
        for (int i = 1; i < 10; i++)
        {
            if (rand.Next(2) == 0)
                Contraseña.Append((char)rand.Next(65, 91));
            else Contraseña.Append(rand.Next(0, 10));
        }
        return Contraseña.ToString();
    }
}
class Programa
{
    static void Main()
    {
        string Nombre = "", Correo = "", Contraseña = "";
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Sistema de registro y validacion de usuarios");
            Console.WriteLine("1. Ingresar datos");
            Console.WriteLine("2. Generar datos Aletorios");
            Console.WriteLine("3. Modidicar Nombre");
            Console.WriteLine("4. Modidicar Correo");
            Console.WriteLine("5. Modidicar Contraseña");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opcion: ");
            int opcion = Convert.ToInt16(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese nombre: ");
                    Nombre = Console.ReadLine();
                    Console.Write("Ingrese su correo: ");
                    Correo = Console.ReadLine();
                    Console.Write("Ingrese una contraseña:");
                    Contraseña = Console.ReadLine();
                    break;
                case 2:
                    (Nombre, Contraseña, Correo) = Validaciones.DatosAleatorio();
                    Console.WriteLine("Datos generados de forma automatica");
                    Console.WriteLine($"Usuario: {Nombre}");
                    Console.WriteLine($"Correo: {Correo}");
                    Console.WriteLine($"Contraseña: {Contraseña}");
                    break;
                case 3:
                    Console.WriteLine("Modificar Nombre");
                    Console.Write("Ingrese un nombre valido: ");
                    Nombre = Console.ReadLine();
                    Validaciones.ValidarUsuario(Nombre, out string NombreModificado);
                    break;
                case 4:
                    Console.WriteLine("Modificar Correo");
                    Console.Write("Ingrese su nuevo correo: ");
                    Correo = Console.ReadLine();
                    Validaciones.ValidarCorreo(Correo, out string CorreoModificado);
                    break;
                case 5:
                    Console.WriteLine("Modificar Contraseña");
                    Console.Write("Ingrese su nueva contraseña: ");
                    Contraseña = Console.ReadLine();
                    Validaciones.ValidarCorreo(Contraseña, out string ContraseñaModificada);
                    break;
                case 6:
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
            bool NombreValido = Validaciones.ValidarUsuario(Nombre, out string MensajeN);
            bool CorreoValido = Validaciones.ValidarCorreo(Correo, out string MensajeC);
            bool Contraseñavalido = Validaciones.ValidarContraseña(Contraseña, out string MensajeCO);
            Console.WriteLine($"Nombre: {Nombre} {MensajeN}");
            Console.WriteLine($"Correo: {Correo} {MensajeC}");
            Console.WriteLine($"Contraseña: {Contraseña} {MensajeCO}");
            if (NombreValido && CorreoValido && Contraseñavalido)
            {
                Console.WriteLine("Los datos ingresados son correctos, pero ninguno de los datos son guardados");
            }
            else
            {
                Console.WriteLine("Los datos no son validos, corrijalos e intente de nuevo");

            }
        }
    }
}