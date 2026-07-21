//Daniel Mendoza Gutierrez 
using System.Globalization;
using System.Text.RegularExpressions;
//Excepciones personalizadas
#region  
public class NombreCompletoException: Exception
{
    public NombreCompletoException():base ("No debe contener números ni caracteres especiales"){}
    public NombreCompletoException(string mensaje):base(mensaje){}
    public NombreCompletoException(string mensaje, Exception interna):base(mensaje,interna){}
}
public class CURPTutorExcpetion: Exception
{
    public CURPTutorExcpetion():base("La CURP del tutor no cumple con los requisitos o no es mayor de 18 años"){}
    public CURPTutorExcpetion(string mensaje): base(mensaje){}
    public CURPTutorExcpetion(string mensaje, Exception interna): base(mensaje, interna){}
}
public class CorreoElectronicoException: Exception
{
    public CorreoElectronicoException():base("El correo ingresado no es correcto "){}
    public CorreoElectronicoException(string mensaje): base(mensaje){}
    public CorreoElectronicoException(string mensaje, Exception interna): base(mensaje, interna){}
}
public class NumeroCelException: Exception
{
    public NumeroCelException():base("El numero ingresado no es correcto deben de ser 10 números, no debe contener guiones ni letras."){}
    public NumeroCelException(string mensaje): base(mensaje){}
    public NumeroCelException(string mensaje, Exception interna): base(mensaje, interna){}
}
public class LugarResidenciaExeption: Exception
{
    public LugarResidenciaExeption():base("El lugar de residencia ingresado no es valido"){}
    public LugarResidenciaExeption(string mensaje): base(mensaje){}
    public LugarResidenciaExeption(string mensaje, Exception interna): base(mensaje, interna){}
}
public class CurpEstudianteException: Exception
{
    public CurpEstudianteException():base("La CURP del estudiante no cumple con los requisitos"){}
    public CurpEstudianteException(string mensaje): base(mensaje){}
    public CurpEstudianteException(string mensaje, Exception interna): base(mensaje, interna){}
}
public class PromedioException: Exception
{
    public PromedioException():base("El promedio ingresado no es valido"){}
    public PromedioException(string mensaje): base(mensaje){}
    public PromedioException(string mensaje, Exception interna): base(mensaje, interna){}
}
#endregion
class programa
{
    //Variables para pdoer almacenar la informacion
    static string NombreDelTtutor="";
    static string CurpDelTutor="";
    static string CorreoDelTuto="";
    static string TelefonoDelTutor="";
    static string residenciaDelTutor="";
    static string  CurpDelEstudiante="";
    static double promedio=0;
    //Metodos de validaciones de los datos ingresados por parte del usuario
    static void ValidarNombre(string nombre)
    {
        if (!Regex.IsMatch(nombre, @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$")) throw new NombreCompletoException();
    }
    static void ValidarCURPTutor(string CURP)
    {
        string C=(CURP ?? "").Trim().ToUpperInvariant();
        if (C.Length !=18) throw new CURPTutorExcpetion("La CURP debe de contar con 18 caracteres");
        string Estructura=@"^[A-ZÑ&]{4}\d{6}[HM][A-Z]{2}[B-DF-HJ-NP-TV-Z]{3}[A-Z0-9]{2}$";
        if (!Regex.IsMatch(C,Estructura)) throw new CURPTutorExcpetion("La CURP ingresada no cumple con las caracteristicas necesarias");
        int Año= int.Parse(CURP.Substring(4,2));
        int Mes= int.Parse(CURP.Substring(6,2));
        int Dia= int.Parse(CURP.Substring(8,2));
        int AñoA=DateTime.Now.Year%100;
        int Añoc=(Año>AñoA) ? 1900+ Año : 2000+Año;
        DateTime FechaNacimiento;
        try
        {
            FechaNacimiento=new DateTime(Añoc,Mes,Dia);
        }
        catch
        {
            throw new CURPTutorExcpetion("La fecha de la CURP no es valida");
        }
        int Años=DateTime.Now.Year-FechaNacimiento.Year;
        if(DateTime.Now <FechaNacimiento.AddYears(Años)) Años--;
        if (Años<18) throw new CURPTutorExcpetion("El tutor debe de ser mayor de 18 años");
    }
    static void ValidarCURPEstudiante(string CURP)
    {
        string C=(CURP ?? "").Trim().ToUpperInvariant();
        if(CURP.Length !=18) throw new CurpEstudianteException();
        string Estructura=@"^[A-ZÑ&]{4}\d{6}[HM][A-Z]{2}[B-DF-HJ-NP-TV-Z]{3}[A-Z0-9]{2}$";
        if (!Regex.IsMatch(C,Estructura)) throw new CurpEstudianteException("La CURP ingresada no cumple con las caracteristicas necesarias");
        int Año= int.Parse(CURP.Substring(4,2));
        int Mes= int.Parse(CURP.Substring(6,2));
        int Dia= int.Parse(CURP.Substring(8,2));
        int AñoA=DateTime.Now.Year%100;
        int Añoc=(Año>AñoA) ? 1900+ Año : 2000+Año;
        DateTime FechaNacimiento;
        try
        {
            FechaNacimiento=new DateTime(Añoc,Mes,Dia);
        }
        catch
        {
            throw new CurpEstudianteException("La fecha del CURP no es valida");
        }
        int Años=DateTime.Now.Year-FechaNacimiento.Year;
        if (DateTime.Now <FechaNacimiento.AddYears(Años)) Años--;
        if (Años>=18) throw new CurpEstudianteException("El estudiante debe de ser menor de 18 años");
    }
    static void ValidarCorreo(string Correo)
    {
        if(string.IsNullOrWhiteSpace(Correo)) throw new CorreoElectronicoException();
        var ES = @"^[^@\s]+@(gmail|outlook|yahoo|icloud|hubspot)\.com$";
        if (!Regex.IsMatch(Correo, ES, RegexOptions.IgnoreCase)) throw new CorreoElectronicoException();
    }
    static void ValidarTelefono(string Telefono)
    {
        if(string.IsNullOrWhiteSpace(Telefono)) throw new NumeroCelException();
        String T=Regex.Replace(Telefono, @"\s|-","");
        if(!Regex.IsMatch(T, @"^\d{10}$")) throw new NumeroCelException();
    }
    static void ValidarResidencia(string Residencia)
    {
        if(string.IsNullOrWhiteSpace(Residencia)) throw new LugarResidenciaExeption();
    }
    static void ValidarPromedio(double Promedio)
    {
        if(Promedio <0.0 || Promedio >10.0) throw new PromedioException();
    }
    //Capturar informaicon del tutor
    static void CapturarDatosTutor()
    {
        try
        {
            Console.Write("Ingrese el nombre completo del tutor: ");
            string nombre=Console.ReadLine()??"";
            ValidarNombre(nombre);
            NombreDelTtutor=nombre.Trim();
            Console.Write("Ingrese el CURP del tutor: ");
            string Curp=Console.ReadLine();
            ValidarCURPTutor(Curp);
            CurpDelTutor=Curp.Trim().ToUpperInvariant();
            Console.Write("Ingrese el correo del tutor: ");
            string correo=Console.ReadLine();
            ValidarCorreo(correo);
            CorreoDelTuto=correo.Trim();
            Console.Write("Ingrese el teléfono celular del tutor: ");
            string telefono=Console.ReadLine();
            ValidarTelefono(telefono);
            TelefonoDelTutor=Regex.Replace(telefono, @"\s|-","");
            Console.Write("Ingrese su lugar de residencia: ");
            string residencia=Console.ReadLine();
            ValidarResidencia(residencia);
            residenciaDelTutor=residencia.Trim();
            Console.WriteLine($"Los datos del tutor {NombreDelTtutor} han sido capturados correctamente");
            Console.WriteLine("==========Informacion guardada del tutor==========");
            Console.WriteLine($"Nombre: {NombreDelTtutor}");
            Console.WriteLine($"CURP del tutor: {CurpDelTutor}");
            Console.WriteLine($"Correo:{CorreoDelTuto}");
            Console.WriteLine($"Telefono: {TelefonoDelTutor}");
            Console.WriteLine($"Residencia: {residenciaDelTutor}");
            Console.WriteLine("==================================================");
        }
        catch (NombreCompletoException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (CURPTutorExcpetion ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (CorreoElectronicoException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (NumeroCelException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (LugarResidenciaExeption ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Informacion invalida verifique sus datos");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"valor invalida verifique sus datos");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        finally
        {
            Console.WriteLine("Termiando el proceso de captura de los datos de los tutores");
        }
    }
    //Capturar informaicon del estudiante
    static void CapturarDatosEstudiante()
    {
        if (string.IsNullOrWhiteSpace(NombreDelTtutor))
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Debe primero capturar los datos del tutor");
            Console.WriteLine("=========================================");
            return;
        }
        try
        {
            Console.Write("Ingrese el CURP del estudiante: ");
            CurpDelEstudiante=Console.ReadLine();
            ValidarCURPEstudiante(CurpDelEstudiante);
            Console.Write("Ingrese el promedio del estudiante: ");
            string prom=Console.ReadLine().Replace(",",".");
            if (!double.TryParse(prom,NumberStyles.Number, CultureInfo.InvariantCulture, out promedio)) throw new PromedioException("El forma ingresado es incorrecto");
            ValidarPromedio(promedio);
            int beca=0;
            if (promedio >=9 && promedio <= 10) beca=3000;
            else if(promedio >=7 && promedio <=8.9) beca=2000;
            else if (promedio < 6)
            {
                Console.WriteLine("No puede obtener los beneficios");
                return;
            }
            string r = residenciaDelTutor.Trim().ToUpperInvariant();
            bool FueraCDMX = r !="CDMX" && r !="cdmx" && r !="Ciudad de México" && r !="Ciudad de Mexico" && r !="CIUDAD DE MÉXICO" && r !="CIUDAD DE MEXICO";
            if (FueraCDMX)
            beca+=200;
            Console.WriteLine($"Beca otorgada: ${beca} pesos");
            Console.WriteLine("==========Informacion guardada del estudiante==========");
            Console.WriteLine($"CURP del estudiante: {CurpDelEstudiante}");
            Console.WriteLine($"Promedio del estudiante: {promedio}");
            Console.WriteLine("=======================================================");

        }
        catch (CurpEstudianteException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (PromedioException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Informacion invalida verifique sus datos");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"valor invalida verifique sus datos");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        finally
        {
            Console.WriteLine("Termiando el proceso de captura de los datos de los estudiantes");
        }
    }

    static void Main()
    {
        int Opcion;
        bool salir=false;
        while (!salir)
        {
            //Menu principal del sistema
            Console.WriteLine("=========================================");
            Console.WriteLine("========Beca Basica Benito Juárez========");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Capturar datos del tutor");
            Console.WriteLine("2. Capturar datos del estudiante");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opcion: ");
            Opcion=int.Parse(Console.ReadLine());
            Console.WriteLine("=========================================");
            switch (Opcion)
            {
                case 1:
                Console.WriteLine("========Capturar datos del tutor ========");
                Console.WriteLine("=========================================");
                CapturarDatosTutor();break;
                case 2: 
                Console.WriteLine("========Capturar datos del estudiante ========");
                Console.WriteLine("=========================================");
                CapturarDatosEstudiante(); break;

                case 3:
                salir=true;
                Console.WriteLine("==========Cerrando programa==========");break;
                default:
                Console.WriteLine("Opcion no validad"); break;
            }
        }
    }
}