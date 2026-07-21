using System;
using System.Diagnostics.Tracing;
using Geolocation;
namespace MonitoreoMamiferos
{
    public class RegistroMonitoreo
    {
        public double LatitudInicio { get; set; }
        public double LongitudInicio { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public double LatitudFin { get; set; }
        public double LongitudFin { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public RegistroMonitoreo(double latInicio, double lonInicio, DateTime fechaInicio, double latFin, double lonFin, DateTime fechaFin)
        {
            LatitudInicio = latInicio; 
            LongitudInicio = lonInicio; 
            FechaHoraInicio = fechaInicio; 
            LatitudFin = latFin; 
            LongitudFin = lonFin; 
            FechaHoraFin = fechaFin;
        }
        public double CalcularDistancia()
        {
            var inicio = new Coordinate(LatitudInicio, LongitudInicio);
            var fin = new Coordinate(LatitudFin, LongitudFin); 
            return GeoCalculator.GetDistance(inicio, fin, 1, DistanceUnit.Kilometers);
        }
        public string CalcularDireccionCardinal()
        {
            var bearing = GeoCalculator.GetBearing(new Coordinate(LatitudInicio, LongitudInicio), new Coordinate(LatitudFin, LongitudFin)); 
            if (bearing >= 0 && bearing <= 45 || bearing > 315 && bearing <= 360) return "Norte"; 
            if (bearing > 45 && bearing <= 135) return "Este"; 
            if (bearing > 135 && bearing <= 225) return "Sur"; 
            return "Oeste";
        }
    }
    public class ProgramaMonitoreo
    {
        private RegistroMonitoreo[] registros = new RegistroMonitoreo[5];
        public void AgregarDatos(int dia, double latInicio, double lonInicio, DateTime fechaInicio, double latFin, double lonFin, DateTime fechaFin)
        {
            if (dia < 1 || dia > 5) throw new ArgumentOutOfRangeException("El día debe estar entre 1 y 5.");
            registros[dia - 1] = new RegistroMonitoreo(latInicio, lonInicio, fechaInicio, latFin, lonFin, fechaFin);
        }
        public void MostrarDatos(){
            double distanciaTotal = 0;
            int diaMenorDistancia = 0;
            double menorDistancia = double.MaxValue;
            for (int i = 0; i < registros.Length; i++)
            {
                double distancia = registros[i].CalcularDistancia(); distanciaTotal += distancia;
                Console.WriteLine($"Día {i + 1}:");
                Console.WriteLine($" Distancia: {distancia:F2} km");
                Console.WriteLine($" Dirección cardinal: {registros[i].CalcularDireccionCardinal()}");
                if (distancia < menorDistancia){
                    menorDistancia = distancia; diaMenorDistancia = i + 1;
                }
            }
            double velocidadPromedio = distanciaTotal / 5; Console.WriteLine($"\nDistancia total recorrida: {distanciaTotal:F2} km");
            Console.WriteLine($"Velocidad promedio: {velocidadPromedio:F2} km/día");
            Console.WriteLine($"Área de interés: Día {diaMenorDistancia} con {menorDistancia:F2} km recorridos.");
        }
        public void PredecirProximaUbicacion()
        {
            double promedioLatitud = 0, promedioLongitud = 0; for (int i = 1; i < registros.Length; i++)
            {
              promedioLatitud += (registros[i].LatitudFin - registros[i - 1].LatitudFin);
              promedioLongitud += (registros[i].LongitudFin - registros[i - 1].LongitudFin);  
            }
            promedioLatitud /= 4;
            promedioLongitud /= 4;
            double nuevaLatitud = registros[4].LatitudFin + promedioLatitud; 
            double nuevaLongitud = registros[4].LongitudFin + promedioLongitud;
            Console.WriteLine("\nPredicción de la ubicación para el sexto día:");
            Console.WriteLine($"Latitud: {nuevaLatitud:F6}"); 
            Console.WriteLine($"Longitud: {nuevaLongitud:F6}");

        }
    }
    class Program
    {
      static void Main(string[] args){
        ProgramaMonitoreo programa = new ProgramaMonitoreo();
        //TODO 1 Solicitar los datos al usuario para monitorear 5 días 
        //latitud de inicio, longitud de inicio, fecha y hora de inicio, latitud de fin, longitud de fin, fecha y hora de fin
        for(int dia=1 ; dia<=5; dia++ ){
            Console.WriteLine ("Ingrese los datos del dia: " +dia);
            Console.WriteLine("Ingrese la latitud inicial: ");
            double latInicio=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese los datos de la longitud inicial: ");
            double lonInicio=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese la fehca y hora de incio (año/mes/dia hora:min): ");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine()!);
            Console.WriteLine("Ingrese la latitud final: ");
            double latFin=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese la longitud final: ");
            double lonFin=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese la fehca y hora de fin (año/mes/dia hora:min): ");
            DateTime fechaFin = DateTime.Parse(Console.ReadLine()!);
            programa.AgregarDatos(dia, latInicio,lonInicio,fechaInicio,latFin,lonFin,fechaFin);
        }
        //TODO 3 llamar al método MostrarDatos 
        programa.MostrarDatos();
        //TODO 4 llamar al método PredecirProximaUbicacion
        programa.PredecirProximaUbicacion();
      }  
    }
} 