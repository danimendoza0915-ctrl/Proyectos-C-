//Daniel Mendoza Gutierrez    ES231109257
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Optimizador
{
    //Clase Gestor de consumo 
    public class GestorConsumo
    {
        //Atributos
        public string IdVivienda { get; set; }
        public string PerfilOriginal { get; set; }
        public string PerfilOptimizado { get; set; }
        public DateTime FechaRegistro { get; set; }

        //Constructor 
        public GestorConsumo(string idVivienda, string perfilOriginal)
        {
            IdVivienda=idVivienda;
            PerfilOriginal= perfilOriginal;
            PerfilOptimizado = perfilOriginal;
            FechaRegistro = DateTime.Now;
        }

        //Metodos virtuales
        public virtual void OptimizarConsumo()
        {
            
        }
        public virtual void RestaurarPerfil()
        {
            PerfilOptimizado = PerfilOriginal;
        }
        public virtual void CalcularCostoTotal(double tarifa = 0.15)
        {
            double costo =0;
            foreach (char c in PerfilOptimizado)
            {
                int consumo = int.Parse(c.ToString());
                costo+=consumo *tarifa;
            }
            Console.WriteLine($"La tarifa es de: {tarifa}");
            Console.WriteLine($"Costo toal de:$ {costo} MXN");
        }
    }
    //Clase Gestotr Tarifa horaria
    public class GestorTarifaHoraria : GestorConsumo
    {
        //Atributos 
        private List<int> HorasPico{get; set;}=new List<int>();
        private int PorcentajeReduccion {get; set;}
        private double TarifaPico {get; set;}
        private double TarifaValle {get; set;}
        //Constructor
        public GestorTarifaHoraria(string idVivienda, string perfilOriginal, List<int> horasPico,int porcentajeReduccion, double tarifaPico,double tarifaValle)
        : base(idVivienda, perfilOriginal)
        {
            HorasPico= horasPico;
            PorcentajeReduccion=porcentajeReduccion;
            TarifaPico=tarifaPico;
            TarifaValle=tarifaValle;
        }
        //Metodo para poder optimizar el consumo
        public override void OptimizarConsumo()
        {
            char[]Perfil=PerfilOriginal.ToCharArray();
            char[]Optimizado=(char[])Perfil.Clone();
            foreach (int hora in HorasPico)
            {
                if(hora>=0 && hora < Perfil.Length)
                {
                    int consumo = int.Parse(Perfil[hora].ToString());
                    double nuevo =consumo*(100-PorcentajeReduccion)/100.0;
                    if (nuevo <1) nuevo =1;
                    Optimizado[hora]=char.Parse(Math.Round(nuevo).ToString());
                }
            }
            PerfilOptimizado = new string(Optimizado);
            Console.WriteLine("===Se aplicó correctamente la optimización de la tarifa horaria===");
        }
        //Metodo para pdoer calcular el costo total 
        public override void CalcularCostoTotal(double tarifa=0.15)
        {
            double costo=0;
            char[] Perfil=PerfilOptimizado.ToCharArray();
            for (int i=0; i< Perfil.Length;i++)
            {
                int consumo = int.Parse(Perfil[i].ToString());
                bool pico = false;
                foreach (var h in HorasPico)
                {
                    if(h==i) {pico=true;break;}
                }
                if (pico)
                costo +=consumo*TarifaPico;
                else
                costo+=consumo*TarifaValle;
            }
            Console.WriteLine($"===Costo total: ${costo} MXN===");
        }
    }
    //Clase Gestotor Solar
    public class GestorSolar : GestorConsumo
    {
        //Atributos
        private List<int> ListasSolares {get; set;}
        private int GeneracionPorHora {get; set;}
        private double CapacidadInstalada {get; set;}
        private int EficienciaActual {get;set;}

        //Construictor
        public GestorSolar(string idVivienda, string perfilOriginal, List<int> listaSolares, int generacionPorHora, double capacidadInstalada, int eficienciaActual) 
        : base(idVivienda, perfilOriginal)
        {
            ListasSolares= listaSolares;
            GeneracionPorHora= generacionPorHora;
            CapacidadInstalada = capacidadInstalada;
            EficienciaActual= eficienciaActual;
        }
        //Metodo para poder optimizar el consumo
        public override void OptimizarConsumo()
        {
            char[] Perfil=PerfilOriginal.ToCharArray();
            char[] Optimizado=(char[])Perfil.Clone();
            foreach (int hora in ListasSolares)
            {
                if (hora >= 0 && hora<Perfil.Length)
                {
                    int consumo = int.Parse(Perfil[hora].ToString());
                    double generacion =(double)(GeneracionPorHora*(EficienciaActual/100.0));
                    if (generacion >CapacidadInstalada)
                    generacion = (double)CapacidadInstalada;
                    double nuevo= consumo -generacion;
                    if(nuevo <1)
                    nuevo=1;
                    Optimizado[hora] =char.Parse(Math.Round(nuevo).ToString());
                }
            }
            PerfilOptimizado = new string(Optimizado);
            Console.WriteLine("===Se aplicó correctamente la optimización oir gestión solar===");
        }
        //Metodo para pdoer calcular el ahorro total 
        public void CalcularAhorroSolar()
        {
            int sumaOriginal=0;
            int sumaOptimizado=0;
            foreach (char c in PerfilOriginal)
            {
                sumaOriginal+= int.Parse(c.ToString());
            }
            foreach (char c in PerfilOptimizado)
            {
                sumaOptimizado+=int.Parse(c.ToString());                
            }
            int ahorroEnKwh = sumaOriginal-sumaOptimizado;
            double ahoro= ahorroEnKwh*0.15;
            Console.WriteLine($"===Ahorro de energia: {ahorroEnKwh} kwh===");
            Console.WriteLine($"===Ahorro en pesos: {ahoro:N2} MXN===");
        }
    }
    //Clase Gestotor de demanda inteligente
    public class GestorInteligenteDemanda : GestorSolar
    {
        //Atributos
        private string AlgoritmoML{get;set;}="";
        private int NivelBalanceo{get;set;}
        private string SeñalRed{get; set;}
        //Constructor
        public GestorInteligenteDemanda(string idVivienda, string perfilOriginal, List<int> listaSolares, int generacionPorHora, double capacidadInstalada,
        int eficienciaActual,string algoritmoML,int nivelBalanceo, string señalRed)
        : base(idVivienda, perfilOriginal,listaSolares,generacionPorHora,capacidadInstalada,eficienciaActual)
        {
            AlgoritmoML=algoritmoML;
            NivelBalanceo= nivelBalanceo;
            SeñalRed= señalRed;
        }
        //Metodo para poder optimizar el consumo
        public override void OptimizarConsumo()
        {
            base.OptimizarConsumo();
            for(int b = 0; b <NivelBalanceo; b++)
            {
                char[]perfil = PerfilOptimizado.ToArray();
                bool balanceado=false;
                while (!balanceado)
                {
                    int maximo= int.MinValue;
                    int minimo= int.MaxValue;
                    int posmaximo =-1;
                    int posminimo=-1;
                    for (int i = 0; i < perfil.Length; i++)
                    {
                        int consumo = int.Parse(perfil[i].ToString());
                        if (consumo>maximo) {maximo=consumo;posmaximo=i;}
                        if (consumo<minimo) {minimo=consumo;posminimo=i;}
                    }
                    if ((maximo - minimo) > 2)
                    {
                        perfil[posmaximo]=char.Parse((maximo-1).ToString());
                        perfil[posminimo]=char.Parse((minimo+1).ToString());
                    }
                    else
                    {
                        balanceado=true;
                    }
                }
                PerfilOptimizado=new string(perfil);
            }
            if (SeñalRed=="Critico")
            {
                char[]perfil = PerfilOptimizado.ToCharArray();
                for (int i = 0; i < perfil.Length; i++)
                {
                    int consumo= int.Parse(perfil[i].ToString());
                    if(consumo>6)
                    perfil[i]='6';
                }
                PerfilOptimizado=new string(perfil);
            }
            Console.WriteLine("===Se aplicó correctamente la optimización por gestión inteligente  de demanda===");
        }
    }
    //Clase Gestor multi dispotivio
    public class GestorMultidispositivo : GestorTarifaHoraria
    {
        //Atributos
        private string TipoDeGestion {get; set;}="Casa-Completa";
        private int LimiteCapacidad {get; set;}
        private int[] PrioridadesDispotivos {get; set;} =Array.Empty<int>();
        private double ConsumoMinimo {get; set;}=0;
        //Metodo para poder optimizar el consumo mediante el tipo de gestión
        public GestorMultidispositivo(string idVivienda, string perfilOriginal, List<int> horasPico,int porcentajeReduccion,double tarifaPico, double tarifaValle, string tipoDeGestion, int limiteCapacidad,
        int [] prioridadesDispositivos, double consumoMinimo) :
        base(idVivienda, perfilOriginal,horasPico,porcentajeReduccion,tarifaPico,tarifaValle)
        {
            TipoDeGestion= tipoDeGestion;
            LimiteCapacidad= limiteCapacidad;
            PrioridadesDispotivos= prioridadesDispositivos;
            ConsumoMinimo= consumoMinimo;
        }
        private int[] convertirCadena(string Pefil)
        {
            return Pefil.Select(c=>int.Parse(c.ToString())).ToArray();
        }
        private string convertirArreglo(int[] arr)
        {
            return string.Concat(arr.Select(n=> n.ToString()));
        }
        public override void OptimizarConsumo()
        {
            if(!string.Equals(TipoDeGestion,"Casa-Completa",StringComparison.OrdinalIgnoreCase))return;
            Console.WriteLine("optimización completa");
            int ConsumoIncial=PerfilOriginal.Sum(c=>int.Parse(c.ToString()));
            base.OptimizarConsumo();
            int[] arr = convertirCadena(PerfilOptimizado);
            for (int i=0; i<arr.Length;i++)
            {
                if(arr[i]>LimiteCapacidad)
                arr[i]=LimiteCapacidad;
            }
            PerfilOptimizado=convertirArreglo(arr);
            int ConsumoOptimizado=PerfilOptimizado.Sum(c=>int.Parse(c.ToString()));
            int ahorrokWh= ConsumoIncial-ConsumoOptimizado;
            double ahorro= ahorrokWh*0.15;
            Console.WriteLine($"Pefil optimizado: {PerfilOptimizado}");
            Console.WriteLine($"Consumo inicial: {ConsumoIncial} kWh");
            Console.WriteLine($"consumo optimizado: {ConsumoOptimizado} kWh");
            Console.WriteLine($"Ahorro total: {ahorrokWh} kWh");
            Console.WriteLine($"Ahorro: ${ahorro:F2} MXN");
        }
        public void OptimizarConsumo(double[]dispositivos)
        {
            if (TipoDeGestion != "Dispositivos-Individuales")
            {
                Console.WriteLine("Tipo de gestión no valido"); return;
            }
            if (dispositivos== null || dispositivos.Length == 0)
            {
                Console.WriteLine("Debe de ingresar consumos para pdoer relizar el calculo"); return;
            }
            if (PrioridadesDispotivos.Length != dispositivos.Length)
            {
                Console.WriteLine("La cantidad ingresada no es correcto"); return;
            }
            double Total = dispositivos.Sum();
            double objetivo= Total*0.70;
            double diferencia= Total-objetivo;

            var ordenados = Enumerable.Range(0, dispositivos.Length).Select(i =>new{Index = i, Valor = dispositivos[i], prioridad=PrioridadesDispotivos[i]}).
            OrderBy(x => x.prioridad).ThenByDescending(x => x.Valor).ToList();
            foreach(var disp in ordenados)
            {
                if (diferencia <=0)
                break;
                if (disp.prioridad >= 3)
                {
                    double consumoActual= dispositivos[disp.Index];
                    double reducible = consumoActual - ConsumoMinimo;
                    if(reducible <=0) continue;
                    if (reducible >= diferencia)
                    {
                        dispositivos[disp.Index] -= diferencia;
                        diferencia=0;
                    }
                    else
                    {
                        dispositivos[disp.Index] = ConsumoMinimo;
                        diferencia -= reducible;
                    }
                }
            }
            PerfilOptimizado = string.Join(",",dispositivos.Select(d=>d.ToString("F2")));
            double ahorro=Total-dispositivos.Sum();
            Console.WriteLine($"Consumo total inicia: {Total:F2} kWh");
            Console.WriteLine($"Consomo optimizado: {dispositivos.Sum():F2} kWh");
            Console.WriteLine($"Ahorro: {ahorro:F2} KWH" );
            Console.WriteLine($"Ahorro $ {(Total-dispositivos.Sum())*0.15:F2} MXN");
        }
    }
    class Programa()
    {
        static void Main()
        {
            bool salir=false;
            string IdGeneral="";
            string Pefilinicial= null;
            string PerfilGeneral=null;
            GestorConsumo gestorBase = null;
            GestorTarifaHoraria gestortarifa= null;
            GestorSolar gestorSolar = null;
            GestorInteligenteDemanda gestorInteligenteDemanda = null;
            GestorMultidispositivo gestorMultidispositivo = null;
            DateTime fechainicial= DateTime.Now;
            while (!salir)
            {
                Console.WriteLine("\n==========Sistema de optimización==========");
                Console.WriteLine("1. Ingresar ID y el perfil de consumo");
                Console.WriteLine("2. Gestor de consumo ");
                Console.WriteLine("3. Gestor Tarifa horaria");
                Console.WriteLine("4. Gestor Solar");
                Console.WriteLine("5. Gestor inteligente de demanda");
                Console.WriteLine("6. Gestor multidispositivo");
                Console.WriteLine("7. Restaurar perfil original");
                Console.WriteLine("8. Mostrar perfiles ");
                Console.WriteLine("9. Salir");
                Console.WriteLine("=============================================");
                Console.Write("Seleccione una opcion: ");
                int opcion = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("=============================================");
                if (opcion !=1 && (string.IsNullOrEmpty(IdGeneral) || string.IsNullOrEmpty(PerfilGeneral)))
                {
                    Console.WriteLine("Ingrese primero el ID y el perfil de consumo para poder continuar");
                    continue;
                }
                switch (opcion)
                {
                    case 1:
                    Console.WriteLine("==========INGRESAR INFORMACIÓN==========");
                    Console.Write("Ingrese el id de la vivienda: ");
                    IdGeneral = Console.ReadLine();
                    Console.Write("Ingrese su perfil de consumo: ");
                    PerfilGeneral = Console.ReadLine();
                    Pefilinicial=PerfilGeneral;
                    fechainicial=DateTime.Now;
                    Console.WriteLine("Información ingresada correctamente");
                    Console.WriteLine("========================================");break;
                    case 2:
                    Console.WriteLine("==========GESTOR DE CONSUMO==========");
                    gestorBase = new GestorConsumo(IdGeneral, PerfilGeneral);
                    Console.WriteLine($"Fecha de creeación: {gestorBase.FechaRegistro}");
                    gestorBase.CalcularCostoTotal();
                    Console.WriteLine("=====================================");break;
                    case 3:
                    Console.WriteLine("==========GESTOR TARIFA HORARIA==========");
                    Console.Write("Ingrese las horas pico de forma separada por una coma ejemplo:(1,2,3,4,5): ");
                    var h= Console.ReadLine();
                    List<int> horaspico= new List<int> ();
                    foreach(var s in h.Split(',',StringSplitOptions.RemoveEmptyEntries))
                    horaspico.Add(int.Parse(s.Trim()));
                    Console.Write("Ingrese el porcentaje de: (10-50): ");
                    int p= int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la tarifa pico ejemplo (0.50): ");
                    double Pi = double.Parse(Console.ReadLine());
                    Console.Write ("Ingrese la tarifa valle ejemplo: (0.10): ");
                    double Va = double.Parse(Console.ReadLine());
                    gestortarifa = new GestorTarifaHoraria(IdGeneral, PerfilGeneral,horaspico, p,Pi,Va);
                    Console.WriteLine($"Fecha de creación: {gestortarifa.FechaRegistro} ");
                    gestortarifa.OptimizarConsumo();
                    gestortarifa.CalcularCostoTotal();
                    Console.WriteLine("========================================");break;
                    case 4:
                    Console.WriteLine("==========GESTOR SOLAR==========");
                    Console.Write("Ingrese las horas horas solares de forma sepada por una coma ejemplo(1,2,3,4,5): ");
                    var hr = Console.ReadLine();
                    List<int> horasSolares = new List<int>();
                    foreach(var s in hr.Split(',',StringSplitOptions.RemoveEmptyEntries))
                    horasSolares.Add(int.Parse(s.Trim()));
                    Console.Write("Ingrese la generación por hora de: (1-5): ");
                    int g = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la capacidad instalada de KW: ");
                    double c = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese la efiencia actual de (80-100): ");
                    int e= int.Parse(Console.ReadLine());
                    gestorSolar = new GestorSolar (IdGeneral,PerfilGeneral,horasSolares,g,c,e);
                    Console.WriteLine($"Fecha de creación: {gestorSolar.FechaRegistro}");
                    gestorSolar.OptimizarConsumo();
                    gestorSolar.CalcularAhorroSolar();
                    Console.WriteLine("================================");break;
                    case 5:
                    Console.WriteLine("==========GESTOR INTELIGENTE DE DEMANDA==========");
                    Console.Write("Ingrese las horas horas solares de forma sepada por una coma ejemplo(1,2,3,4,5): ");
                    var hrs = Console.ReadLine();
                    List <int> horaS= new List<int>();
                    foreach (var s in hrs.Split(',',StringSplitOptions.RemoveEmptyEntries))
                    horaS.Add(int.Parse(s.Trim()));
                    Console.Write("Ingrese la generación por hora de: (1-5): ");
                    int ge = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la capacidad instalada de KW: ");
                    double ca = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese la efiencia actual de (80-100): ");
                    int ef= int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el Algoritmo ML: ");
                    string a =Console.ReadLine();
                    Console.Write("Ingrese el nivel de valance de (1-3): ");
                    int n =int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la señal de red de (Normal/Alerta, Critico): ");
                    string se = Console.ReadLine();
                    gestorInteligenteDemanda= new GestorInteligenteDemanda (IdGeneral,PerfilGeneral,horaS,ge,ca,ef,a,n,se);
                    Console.WriteLine($"Fecha de creación: {gestorInteligenteDemanda.FechaRegistro}");
                    gestorInteligenteDemanda.OptimizarConsumo();
                    gestorInteligenteDemanda.CalcularAhorroSolar();
                    Console.WriteLine("===============================================");break;
                    case 6:
                    Console.WriteLine("==========GESTOR MULTI DISPOSITIVO==========");
                    Console.Write("INgrese las hora pico de forma separads podr coma ejemplo: (1,2,3,4,5):");
                    var Hrs = Console.ReadLine();
                    List <int> Hpm = new List<int> ();
                    if (!string.IsNullOrWhiteSpace(Hrs))
                        {
                            foreach (var s in Hrs.Split(',', StringSplitOptions.RemoveEmptyEntries))
                            Hpm.Add(int.Parse(s.Trim()));
                        }
                    Console.Write("Ingrese el porcentaje de reducción de (10-50): ");
                    int Por = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la tarifa pico ejemplo (0.50): ");
                    double tp = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese la tarifa valle ejemplo (0,10): ");
                    double tv= double.Parse(Console.ReadLine());
                    Console.Write("Ingrese el tipo de gestión Casa-Completa / Dispositivos-Individuales: ");
                    string tipo=Console.ReadLine();
                    Console.Write("Ingrese el limite de capacidad por hora en numero entero: ");
                    int l= int.Parse(Console.ReadLine());
                    Console.Write("Ingree las prioridades o conumos de los dispositivos de forma separada por una coma ejemplo: (1.2.3.4.): ");
                    var pc= Console.ReadLine();
                    int[] prioridades= Array.ConvertAll(pc.Split(',', StringSplitOptions.RemoveEmptyEntries), s=>int.Parse(s.Trim()));
                    Console.Write("Ingerese el consumo minimo por dispostivo ejemplo (1.0): ");
                    double con = double.Parse(Console.ReadLine());
                    gestorMultidispositivo = new GestorMultidispositivo (IdGeneral, PerfilGeneral,Hpm,Por,tp, tv, tipo,l,prioridades,con);
                    Console.WriteLine($"Fecha de creación: {gestorMultidispositivo.FechaRegistro}");
                    if(string.Equals(tipo, "Casa-Completa", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Optimización Casa-Completa");
                            gestorMultidispositivo.OptimizarConsumo();
                        }
                        else if (string.Equals(tipo, "Dispositivos-Individuales",StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Optimizacion Dispsositivos-Individuales: ");
                            Console.WriteLine("Ingrese el consumo real de los dispositivos por separado separado por comas ejemplo(1,2,3,4): ");
                            var cons =Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(cons))
                            {
                                Console.WriteLine("Los valores ingresados no son validos");
                            }
                            else
                            {
                                double[] dispositivos;
                                try
                                {
                                    dispositivos=Array.ConvertAll(cons.Split(',', StringSplitOptions.RemoveEmptyEntries), s=> double.Parse(s.Trim()));
                                    gestorMultidispositivo.OptimizarConsumo(dispositivos);
                                }
                                catch
                                {
                                    Console.WriteLine("Formato no valido.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tipo de gestión ingresada no conocida");
                        }
                    Console.WriteLine("========================================");break;
                    case 7: 
                    Console.WriteLine("==========Restauración de perfiles al original==========");
                    if(gestorBase !=null) gestorBase.RestaurarPerfil();
                    if(gestortarifa !=null) gestortarifa.RestaurarPerfil();
                    if(gestorSolar != null) gestorSolar.RestaurarPerfil();
                    if(gestorInteligenteDemanda !=null) gestorInteligenteDemanda.RestaurarPerfil();
                    if(gestorMultidispositivo !=null) gestorMultidispositivo.RestaurarPerfil();
                    gestorBase= null;
                    gestortarifa= null;
                    gestorSolar =null;
                    gestorInteligenteDemanda = null;
                    gestorMultidispositivo= null;
                    Console.WriteLine ($"Todos los perfiles fueron restaurados al original: {Pefilinicial}");
                    Console.WriteLine("=========================================================");break;
                    case 8:
                    Console.WriteLine("==========Perfiles generados==========");
                    Console.WriteLine($"Pefil inicial: {Pefilinicial} | Fecha de creación: {fechainicial}");
                    if (gestorBase!= null) Console.WriteLine($"Gestor de consumo: {gestorBase.PerfilOptimizado} | Fecha de creación: {gestorBase.FechaRegistro}");
                    if (gestortarifa != null) Console.WriteLine($"Gesrtor de tarifa horaria: {gestortarifa.PerfilOptimizado} | Fecha de creación: {gestortarifa.FechaRegistro}");
                    if(gestorSolar!= null) Console.WriteLine($"Gestor Solar: {gestorSolar.PerfilOptimizado} | Fecha de creación: {gestorSolar.FechaRegistro}");
                    if(gestorInteligenteDemanda!=null) Console.WriteLine($"Gestor inteligente de demanda: {gestorInteligenteDemanda.PerfilOptimizado} | Fecha de registro: {gestorInteligenteDemanda.FechaRegistro}"); 
                    if (gestorMultidispositivo!=null) Console.WriteLine($"Gestor multidispositivo: {gestorMultidispositivo.PerfilOptimizado} | fecha de registro {gestorMultidispositivo.FechaRegistro}"); break;
                    case 9:
                    salir=true;
                    Console.WriteLine("==========Cerrando programa==========");break;
                    default:
                    Console.WriteLine("Opcion no validad"); break;

                }
            }
        }
    }
}
