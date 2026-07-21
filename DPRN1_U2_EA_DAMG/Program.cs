using System;
class Analisis
{
    static double  HorasSolares;
    static double PromedioViento;
    static double TemperaturaMedia;
    static double InclinacionSubsuelo;
    static string TipoSuerficie;
    static double TemperaturaSubsuelo;
    static double ProfundidadFuente;

    public static void RecopilarDatosAmbientales()
    {
        while(true)
        {
            Console.Write("Ingrese las horas sol anuales: [0, 4000 horas]: ");
            if(double.TryParse(Console.ReadLine(), out HorasSolares) && HorasSolares >= 0 && HorasSolares <= 4000) break;
            Console.WriteLine("El valor no es valido, se debe de ingresar un valor entre 0 y 4000");
        }
        while(true)
        {
            Console.Write("Ingrese la velocidad promedio del viento [0 m/s, 30 m/s]:");
            if(double.TryParse(Console.ReadLine(), out PromedioViento) && PromedioViento >=0 && PromedioViento <=30)break;
            Console.WriteLine("El valor no es valido, se debe de ingresar un valor entre 0 y 30");
        }
        while(true)
        {
            Console.Write("Ingrese la temperatura media anual: [-50°C, 50°C]:");
            if(double.TryParse(Console.ReadLine(), out TemperaturaMedia) && TemperaturaMedia >=-50 && TemperaturaMedia <=50)break;
            Console.WriteLine("El valor no es valido, se debe de ingresar un valor entre -50 y 50");

        }
        while(true)
        {
            Console.Write("Ingrese la inclinacion del suelo [0°, 90°]: ");
            if(double.TryParse(Console.ReadLine(),out InclinacionSubsuelo) && InclinacionSubsuelo >=0 && InclinacionSubsuelo <=90)break;
            Console.WriteLine("El valor no es valido, se debe de ingresar un valor entre 0 y 90");
        }
        while(true)
        {
            Console.Write("Ingrese el tipo de superficie (roca, arenoso, arcilloso): ");
            TipoSuerficie = Console.ReadLine().Trim().ToLower();
            if(TipoSuerficie == "roca" || TipoSuerficie == "arenoso" || TipoSuerficie == "arcilloso")break;
            Console.WriteLine("El material Ingresado no es valido");
        }
    }
    public static void RecopilarDatosGeotermicos()
    {
        while(true)
        {
            Console.Write("Ingrese la temperatura del subsuelo [50°C, 300°C ]: ");
            if(double.TryParse(Console.ReadLine(),out TemperaturaSubsuelo) && TemperaturaSubsuelo>=50 && TemperaturaSubsuelo<=300)break;
            Console.WriteLine("El valor no es valido, se debe de ingresar un valor entre 50 y 300");
        }
        while (true)
        {
            Console.Write("Ingrese la profundiadad de la fuente geotermica [0 m, 5000 m]: ");
            if(double.TryParse(Console.ReadLine(), out ProfundidadFuente) && ProfundidadFuente>=0 && ProfundidadFuente<=5000) break;
            Console.WriteLine("El valor no es valido, se debe de ingresar un valor entre 0 y 5000");
        }
    }
    public static bool CalcularViabilidadSolar()
    {
        double FactorSolar = HorasSolares / 1000 + (TipoSuerficie == "roca" ? 0.2 : TipoSuerficie == "arena" ? 0.1 : 0.05);
        return FactorSolar >1.5;
    }
    public static bool CalcularViabilidadEolica()
    {
        double FactorEolico = PromedioViento * (1 - (InclinacionSubsuelo / 100));
        return FactorEolico >8;
    }
    public static bool CalcularViabilidadGeotermica()
    {
        double FactorGeotermico = TemperaturaSubsuelo / ProfundidadFuente;
        return FactorGeotermico >0.02;
    }
    public static void ViabilidadAmbientales()
    {
        Console.WriteLine($"Energia solar: {(CalcularViabilidadSolar()? "Viable": "No viable")}");
        Console.WriteLine($"Energia eolica: {(CalcularViabilidadEolica()? "Viable": "No viable")}");
    }
    public static void ViabilidadGeotermica()
    {
        Console.WriteLine($"Energia Geotermico: {(CalcularViabilidadGeotermica()? "Viable": "No viable")}");
    }
}

class programa
{
    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\nPlataoforma de gestion y Analisis de datos para Energias Renovables");
            Console.WriteLine("1. Recopilacion de datos ambientales");
            Console.WriteLine("2. Recopilacion de datos geotermicos");
            Console.WriteLine("3. Calcular viabilidad de las diferentes fuentes de energia");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opcion: ");
            int opcion =Convert.ToInt16(Console.ReadLine());
            switch(opcion)
            {
                case 1:
                Analisis.RecopilarDatosAmbientales();break;
                case 2:
                Analisis.RecopilarDatosGeotermicos();break;
                case 3:
                Console.WriteLine("Calcular viabilidad de las diferentes fuentes de energia");
                Console.WriteLine("\nRESULTADOS VIABILIDAD AMBIENTALES");
                Analisis.ViabilidadAmbientales();
                Console.WriteLine("\nRESULTADOS VIABILIDAD GEOTERMICAS");
                Analisis.ViabilidadGeotermica();break;
                case 4:
                salir=true;
                Console.WriteLine("Saliendo del programa");break;
                default:
                Console.WriteLine("Opcion no valida, intente de nuevo");break;
            }
        }

    }
}