using System;
using System.Collections;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
//DANIEL MENDOZA GUTIERREZ      MATRICULA: ES231109257
public class Personaje
{
    //Atributos//
    private string nombre;
    private string perfil;
    private string altura;
    private string peso;
    private string puntofuerte;
    private string ataque360;
    private string embestida;
    private List<string> citas;
    private int fuerza;
    private int velocidad;
    private int destreza;
    private int vida;

    //Encapsulamiento//
    public string Nombre { get => nombre; set => nombre = value; }
    public string Perfil { get => perfil; set => perfil = value; }
    public string Altura { get => altura; set => altura = value; }
    public string Peso { get => peso; set => peso = value; }
    public string Puntofuerte { get => puntofuerte; set => puntofuerte = value; }
    public string Ataque360 { get => ataque360; set => ataque360 = value; }
    public string Embestida { get => embestida; set => embestida = value; }
    public List<string> Citas { get => citas; set => citas = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Vida { get => vida; set => vida = value; }

    //Constructor 1//
    public Personaje(string nombre, string perfil, string altura, string peso, string puntofuerte,
    string ataque360, string embestida, List<string> citas, int fuerza, int velocidad, int destreza)
    {
        this.Nombre = nombre;
        this.Perfil = perfil;
        this.Altura = altura;
        this.Peso = peso;
        this.Puntofuerte = puntofuerte;
        this.Ataque360 = ataque360;
        this.Embestida = embestida;
        this.Citas = citas;
        this.Fuerza = fuerza;
        this.Velocidad = velocidad;
        this.Destreza = destreza;
        this.Vida = 100;

    }
    //constructor 2"//
    public Personaje(string nombre)
    {
        this.Nombre = nombre;
        this.Perfil = "No asignado";
        this.Altura = "No asignado";
        this.Peso = "No asignado";
        this.Puntofuerte = "básico";
        this.Ataque360 = "básico";
        this.Embestida = "0";
        this.Citas = new List<string> { "básico" };
        this.Fuerza = 1;
        this.Velocidad = 1;
        this.Destreza = 1;
        this.vida = 100;
    }
    //Métodos
    public void RecibirDaño(int cantidad)
    {
        Vida -= cantidad;
        if (vida <= 0)
        {
            Console.WriteLine($"Ha sido derrotado:{Nombre}");
        }
    }
    public void ActivarAtaque360()
    {
        Console.WriteLine($"El personaje:{Nombre} activo su habilidad: {Ataque360}");
    }
    public void Embestidas(Personaje objetivo)
    {
        Random aleatorio = new Random();
        int porcentaje;
        porcentaje = aleatorio.Next(15, 21);
        int Daño = (objetivo.vida * porcentaje) / 100;
        objetivo.RecibirDaño(Daño);
        Console.WriteLine($"Lo cual ocasiono un daño de {Daño} a su oponente: {objetivo.Nombre}");
        Console.WriteLine($"Por lo cual: {objetivo.nombre} quedo con {objetivo.vida} de vida");
    
    }
    public void Cita(Personaje p)
    {
        Random random = new Random();
        int aleatorio = random.Next(p.Citas.Count);
        Console.WriteLine($"El personaje: {p.Nombre} dice: {p.Citas[aleatorio]}");
    }
    public void Valores(int valor)
    {
        if (fuerza >=1 && fuerza <=5 && 
            velocidad >=1 && velocidad <=5 &&
            destreza >=1 && destreza <=5)
        {
            Console.WriteLine("Valores no validos");
        }
    }

    public void MostrarInformacion()
    {

        Console.WriteLine("==========INFORMACIÓN DEL PERSONAJE==========");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Perfil: {Perfil}");
        Console.WriteLine($"Altura: {Altura}");
        Console.WriteLine($"Peso: {Peso}");
        Console.WriteLine($"Punto Fuerte: {Puntofuerte}");
        Console.WriteLine($"Ataque 360°: {Ataque360}");
        Console.WriteLine($"Embestidad: {Embestida}");
        Console.WriteLine($"Citas: {string.Join(",", citas)})");
        Console.WriteLine($"Fuerza: {Fuerza}/5");
        Console.WriteLine($"Velocidad: {Velocidad}/5");
        Console.WriteLine($"Destreza: {Destreza}/5");
        Console.WriteLine($"vida: {Vida}");
        Console.WriteLine("==============================================");

    }
}

class Programa
{
    static void Main()
    {
        //Personaje 1

        Personaje MustaphaCairo = new Personaje("Mustapha Cairo", "Ingeniero y amigo de Jack", "1.98m (6 pies, 6 pulgadas)", "68kg (149.6 libras)",
        "Patada Voladora", "Patada Tornado", "Doble Patada Voladora", new List<string> { "Bad To The Bone!", "I'm A Bad Mamba Jamma!", },
        3, 5, 3);

        //Personaje 2

        Personaje MessBradovich = new Personaje("Mess O'Bradovich", "Elude su pasado", "2.05m (6 pies, 9 pulgadas)", "97kg (213.4 libras)", "Fuerza", "Puñetazo",
        "Golpe con todo el cuerpo", new List<string> { "Number One Baby!", "I'm Just Too Cool!" }, 5, 2, 4);

        //Mostrar información de los personajes 
        
        MustaphaCairo.MostrarInformacion();
        MessBradovich.MostrarInformacion();

        //Función para iniciar combate de los personajes

        Console.WriteLine("====================INICIO DEL COMBATE====================");

        MustaphaCairo.ActivarAtaque360();
        MustaphaCairo.Embestidas(MessBradovich);
        MustaphaCairo.Cita(MustaphaCairo);
        Console.WriteLine("==========================================================");
        MessBradovich.ActivarAtaque360();
        MessBradovich.Embestidas(MustaphaCairo);
        MessBradovich.Cita(MessBradovich);
        Console.WriteLine("=====================FIN DEL COMBATE======================");
    }
}