//Daniel Mendoza Gutierrez   Matricula:ES231109257
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
//Claase base escaner 
public class Escaner
{
    //Atributos de la clases base 
    public string TipoEscaner{get;set;}
    public string SistemaEscaneado{get;set;}
    public bool Estado{get;set;}
    //Metodos
    public virtual void Escanea()
    {
        Console.WriteLine($"Se esta realizando el escandeado {SistemaEscaneado}");
        GeneraEstado();
    }
    public virtual void GeneraEstado()
    {
        Random rnd= new Random();
        Estado =rnd.Next(0,2) ==1;
    }
    public virtual void Diagnostico()
    {
        if (Estado)
        {
            Console.WriteLine($"El {SistemaEscaneado} presenta fallos");
        }
        else
        {
            Console.WriteLine($"El {SistemaEscaneado} funciona correctamente");
        }
    }
    public virtual void EliminarErrores()
    {
        if (!Estado)
        {
            Console.WriteLine("No hay nada que eliminar");
        }
        else
        {
            Estado=false;
            Console.WriteLine("Errorres eliminados de la computadora");
        }
    }
}
//Clase de escaner basico
public class EscanerBasico : Escaner
{
    //Atributos 
    public string VidaLuces{get;set;}
    public string TipoLuces{get;set;}
    
    public EscanerBasico(string tipoLuces)
    {
        TipoEscaner="Escaner básico";
        SistemaEscaneado="Sistema Electrico";
        TipoLuces=tipoLuces;
        VidaLuces=ObtenerVidaLuces();
    }
    
    //Metodos
    public override void Escanea()
    {
        Console.WriteLine($"Se esta realizando el escandeado {TipoLuces} del vehiculo");
        GeneraEstado();
    }
    public override void Diagnostico()
    {
        string estado=Estado ? "No funciona de forma correcta" : "Funciona de forma correcta";
        Console.WriteLine($"El sistema de iluminación {TipoLuces} del vehiculo presenta {VidaLuces} y {estado}");
    }
    public string ObtenerVidaLuces()
    {
        Random rdn=new Random();
        int horas =rdn.Next(1001);
        return $"{horas} horas";
    }
}
//Clase de escaner gama media
public class EscaGamaMedia : Escaner
{
    //Atributos
    public string Transmision{get;set;}
    public int Velocidades{get;set;}
    public EscaGamaMedia(string transmision, int velocidades)
    {
        TipoEscaner="Escaner de gama media";
        SistemaEscaneado="Transmisión";
        Transmision=transmision;
        Velocidades=transmision=="Estandar"? velocidades:0;
    }
    //Metodos
    public override void Escanea()
    {
        Console.WriteLine($"Escanenado la transmisión {Transmision} del vehiculo");
        GeneraEstado();
    }
    public override void Diagnostico()
    {
        string estado= Estado ? "presenta problemas" : "Funciona de forma correcta";
        if (Transmision =="Estandar")
        Console.WriteLine($"La transmion estandar de {Velocidades} velocidad {estado}");
        else
        Console.WriteLine($"La transmion automatica {estado}");
    }
}
//Clase gama media Alta 
public class EscanerGamaMediaAlta : Escaner
{
    //Atributos
    public string cilindradaMotor{get;set;}
    public int NumeroCilindros{get;set;}

    public EscanerGamaMediaAlta(string cilindra, int numeroCilindros)
    {
        TipoEscaner="Gama Media Alta";
        SistemaEscaneado="Motor";
        cilindradaMotor=cilindra;
        NumeroCilindros=numeroCilindros;
    }
    //Metodos
    public override void Escanea()
    {
        Console.WriteLine($"Escanendo el motor del vehiculo de {cilindradaMotor}");
        GeneraEstado();
    }
    public override void Diagnostico()
    {
        string estado=Estado ? "Presenta porblemas": "Funciona de forma correcta";
        Console.WriteLine($"El motor de {NumeroCilindros} cilindro {estado}");
    }
}
//Escaner Gama Alta
public class EscanerGamaAlta : Escaner
{
    //Atributos
    public EscanerBasico esbasico{get;set;}
    public EscaGamaMedia escGM{get;set;}
    public EscanerGamaMediaAlta escGMA{get;set;}
    public string VIN{get;set;}
    public EscanerGamaAlta()
    {
        TipoEscaner="Gama Alta";
        SistemaEscaneado="Todos los sistema";
        Console.Write("Ingrese los 17 digitos del VIN:  ");
        VIN=Console.ReadLine();
        esbasico=new EscanerBasico("LED");
        escGM=new EscaGamaMedia ("Automatico",0);
        escGMA = new EscanerGamaMediaAlta("2.0L",4);
    }
    //Metodos
    public override void Escanea()
    {
        esbasico.Escanea();
        escGM.Escanea();
        escGMA.Escanea();
    }
    public override void Diagnostico()
    {
        Console.WriteLine($"Escaneando el vehiculo con VIN: {VIN}");
        esbasico.Diagnostico();
        escGM.Diagnostico();
        escGMA.Diagnostico();
    }
    public string ObtenerVidaLuces()
    {
        return esbasico.ObtenerVidaLuces();
    }
}
class Programa
{
    static void Main()
    {
        Escaner escaner=null;
        int opcion;
        bool salir=false;
        while (!salir)
        {
            Console.WriteLine("=========Escaner Automotriz==========");
            Console.WriteLine("1. Crear innstancias de escaner"); 
            Console.WriteLine("2. Escaneo del sistema del vehiculo");
            Console.WriteLine("3. Diagnostico del sistema del vehiculo");
            Console.WriteLine("4. Eliminar errores");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese una opcion: ");
            opcion=int.Parse(Console.ReadLine());
            Console.WriteLine("=====================================");
            switch (opcion)
            {
                case 1:
                Console.WriteLine("=========Lista de tipos de escaner==========");
                Console.WriteLine("1. Escaner Basico");
                Console.WriteLine("2. Escaner Gama Media");
                Console.WriteLine("3. Gama Media Alta");
                Console.WriteLine("4. Gama Alta");
                Console.Write("Seleccione una opcion: ");
                int tipo=int.Parse(Console.ReadLine());
                Console.WriteLine("=============================================");

                switch (tipo)
                    {
                        case 1:
                        Console.Write("Ingrese el tipo de luces: ");
                        escaner=new EscanerBasico(Console.ReadLine()); break;
                        case 2:
                        Console.Write("Ingrese el tipo de transmision Automatico o Estandar: ");
                        string trans = Console.ReadLine();
                        int veloci=0;
                        if (trans == "Estandar")
                            {
                                Console.Write("Ingrese las velocidades: ");
                                veloci= int.Parse(Console.ReadLine());
                            }
                            escaner=new EscaGamaMedia(trans,veloci); break;
                        case 3:
                        Console.Write("Ingrese el valor de la cilindrada: ");
                        string cilin= Console.ReadLine();
                        Console.Write("Ingrese el numero de cilindros: ");
                        int Numcilin = int.Parse(Console.ReadLine());
                        escaner= new EscanerGamaMediaAlta(cilin, Numcilin); break;
                        case 4:
                        escaner= new EscanerGamaAlta(); break;
                    }

                break;
                case 2:
                if (escaner !=null)
                escaner.Escanea();
                else
                    {
                        Console.WriteLine("Debe primero crear un tipo de escaner");
                    } break;
                case 3:
                if (escaner !=null)
                escaner.Diagnostico();
                else
                    {
                        Console.WriteLine("Debe primero crear un tipo de escaner");
                    } break;
                case 4:
                if (escaner !=null)
                escaner.EliminarErrores();
                else
                    {
                        Console.WriteLine("Debe primero crear un tipo de escaner");
                    } break;
                case 5:
                salir=true;
                Console.WriteLine("==========Cerrando programa==========");break;
                default:
                Console.WriteLine("Opcion no validad"); break;
            }           
        }
    }
}