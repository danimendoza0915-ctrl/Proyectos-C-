//Daniel Mnedoza Gutierrez   ES231109257

using System.Globalization;
#region
//Manejo de excepciones personalizadas 
public class ArregloVacionException : Exception
{
    public ArregloVacionException() : base("El arreglo esta vacio. Ingrese valores para pdoer conttinuar") { }
    public ArregloVacionException(string Message) : base(Message) { }
    public ArregloVacionException(string Message, Exception interna) : base(Message, interna) { }
}
public class ValidacionDeNumerosException : Exception
{
    public ValidacionDeNumerosException() : base("Verifique que sus datos sean numericos") { }
    public ValidacionDeNumerosException(string Message) : base(Message) { }
    public ValidacionDeNumerosException(string Message, Exception interna) : base(Message, interna) { }
}
#endregion

class programa
{
    //Arreglo para pdoer almacenar los valores ingresados 
    static double[] Temperaturas;

    //Metodos de validaciones 
    static double ValidacionDeNumeros(string valor)
    {
        valor = valor.Replace(",", ".").Trim();
        if (!double.TryParse(valor, NumberStyles.Float, CultureInfo.InvariantCulture, out double Numero))
        {
            throw new ValidacionDeNumerosException($"El valor: {valor} no es valido");
        }
        return Numero;
    }
    static void validarArregloVacio()
    {
        if (Temperaturas == null || Temperaturas.Length == 0) throw new ArregloVacionException();
    }
    //Metodo para pdoer caputar y validar el arreglo
    static void CapturaDeArreglo()
    {
        try
        {
            Console.Write("Ingrese las cantidades de las temperaturas separadas por un espacio: ");
            string T = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(T)) throw new Exception("No hay valores ingresados");
            string[] L = T.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double[] D = new double[L.Length];
            for (int i = 0; i < L.Length; i++)
            {
                D[i] = ValidacionDeNumeros(L[i]);
            }
            Temperaturas = D;
            Console.WriteLine("========================================================");
            Console.WriteLine("==========Se guardaron correctamente los datos==========");
            Console.WriteLine("========================================================");
        }
        catch (ValidacionDeNumerosException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        finally
        {
            Console.WriteLine("Se capturaron de forma correcta las temeperaturas");
        }
    }
    //Metodo que contiene el arreglo actual y los muestra al usuario 
    static void MostrarCapura()
    {
        try
        {
            validarArregloVacio();
            Console.WriteLine("=====Temperaturas ingresadas=====");
            Console.WriteLine(string.Join(" ", Temperaturas));
        }
        catch (ArregloVacionException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
    //Metodo para pdoer ordentar el arreglo 
    static void OrdenarCantidadArreglo()
    {
        try
        {
            validarArregloVacio();
            double[] Respaldo = (double[])Temperaturas.Clone();
            int VPositivo=0, VNegativo=0;
            foreach (double t in Respaldo)
            {
                if (t>=0) VPositivo++;
                else VNegativo++;
            } 
            double[] Positivo= new double[VPositivo];
            double[] Negativo= new double[VNegativo];
            int p=0, n=0;
            foreach (double t in Respaldo)
            {
                if(t>=0) Positivo[p++] =t;
                else Negativo[n++]=t;
            }
            for (int i=0; i <Positivo.Length - 1; i++)
            {
                for (int j = i+1; j< Positivo.Length;j++)
                {
                    if(Positivo[i] > Positivo[j])
                    {
                      double te=Positivo[i];
                      Positivo[i]=Positivo[j];
                      Positivo[j]=te;  
                    }
                }
            }
            for (int i=0; i <Negativo.Length - 1; i++)
            {
                for (int j = i+1; j< Negativo.Length;j++)
                {
                    if(Negativo[i] < Negativo[j])
                    {
                      double te=Negativo[i];
                      Negativo[i]=Negativo[j];
                      Negativo[j]=te;  
                    }
                }
            }
            double[]r =new double [Respaldo.Length];
            int I=0;
            foreach (double Vp in Positivo) r[I++] =Vp;
            foreach (double Vn in Negativo) r[I++] =Vn;
            Console.WriteLine("==========ORDENADO CORRECTAMENTE==========");
            Console.WriteLine(string.Join(" ", r));
        }
        catch(Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
    static void Main()
    {
        //Menu principal 
        int Opcion;
        bool salir=false;
        while (!salir)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("=========Sistema para analisis de temperaturas=========");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Ingrese o modifique el arreglo de temperaturas");
            Console.WriteLine("2. Mostrar el arreglo actual");
            Console.WriteLine("3. Ordenar el arreglo de mayor a menor");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opcion: ");
            Opcion=int.Parse(Console.ReadLine());
            Console.WriteLine("=======================================================");
            switch (Opcion)
            {
                case 1:
                CapturaDeArreglo();break;
                case 2:
                MostrarCapura();break;
                case 3:
                OrdenarCantidadArreglo();break;
                case 4:
                salir=true;
                Console.WriteLine("==========Cerrando programa==========");break;
                default:
                Console.WriteLine("Opcion no validad"); break;
            }

        }
    }

}