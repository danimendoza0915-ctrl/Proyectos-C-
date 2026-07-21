
using System.Runtime.CompilerServices;

public class Especie
{
    //Atributos
    private string nombreCientifico;
    private string clasificacion;
    private string funcionEcologica;
    private string codigoGenetico;
    private float abundancia;

    //Encapsulamiento
    public string NombreCientifico { get => nombreCientifico; set => nombreCientifico = value; }
    public string Clasificacion { get => clasificacion; set => clasificacion = value; }
    public string FuncionEcologica { get => funcionEcologica; set => funcionEcologica = value; }
    public string CodigoGenetico { get => codigoGenetico; set => codigoGenetico = value; }
    public float Abundancia { get => abundancia; set => abundancia = value; }

    //Constructor 
    public Especie(string nombreCientifico, string clasificacion, string funcionEcologica, string codigoGenetico,
    float abundancia)
    {
        this.NombreCientifico = nombreCientifico;
        this.Clasificacion = clasificacion;
        this.FuncionEcologica = funcionEcologica;
        this.CodigoGenetico = codigoGenetico;
        this.Abundancia = abundancia;
    }
    //Metodos 
    public void compararEspecies(Especie OtraEspecie)
    {
        int iguales = 0;
        for (int i = 0; i < Math.Min(this.codigoGenetico.Length, OtraEspecie.codigoGenetico.Length); i++)
            if (this.codigoGenetico[i] == OtraEspecie.codigoGenetico[i]) iguales++;
        Console.WriteLine("=====================================");
        double similitud = (double)iguales / Math.Max(this.codigoGenetico.Length, OtraEspecie.codigoGenetico.Length);
        float diferencia = Math.Abs((this.abundancia - OtraEspecie.abundancia) * 100);
        Console.WriteLine($"{this.NombreCientifico} vs {OtraEspecie.nombreCientifico}");
        Console.WriteLine($"Similitud: {similitud * 100:F2}%"); 
        Console.WriteLine($"Abundancia: {this.abundancia * 100}%  vs {OtraEspecie.Abundancia * 100}%");
        Console.WriteLine($"Diferencia de abundancia: {diferencia:F2}%");
        if (similitud >= 0.8 && similitud <= 1.0)
        {
            Console.WriteLine("Existe una alta similitud genetica");
        }
        else if (similitud >= 0.5 && similitud < 0.8)
        {
            Console.WriteLine("Existe una media similitud genetica");
        }
        else if (similitud >= 0.0 && similitud < 0.5)
        {
            Console.WriteLine("Existe una baja similitud genetica");
        }
    }
    public void ModificarAbundancia(float nuevaAbundancia)
    {
        if (nuevaAbundancia >= 0f && nuevaAbundancia <= 1f)
        {
            abundancia = nuevaAbundancia;
            Console.WriteLine("================================================");
            Console.WriteLine($"Se actualizo la abndancia de {NombreCientifico} a {nuevaAbundancia * 100:F2}%");
            Console.WriteLine("================================================");
        }
        else
        {
            Console.WriteLine("El valor ingresado no es valido");
            return;
        }
    }
    public void MostrarInformacionDetallada()
    {
        Console.WriteLine("==========INFORMACIÓN==========");
        Console.WriteLine($"Nombre cientfico de la especie: {nombreCientifico}");
        Console.WriteLine($"Clasificación taxomónica: {clasificacion}");
        Console.WriteLine($"Rol en el ecosistema: {FuncionEcologica}");
        Console.WriteLine($"Identificador génerico(Simulado): {codigoGenetico}");
        Console.WriteLine($"Porcentaje de presencia en el ecosistema: {abundancia*100:F2}%");
        Console.WriteLine("===============================");
    }
    public void SimularInteraccionEcologica(Especie OtraEspecie, int opcion)
    {
        Console.WriteLine($"Simulación entre {NombreCientifico} y {OtraEspecie.NombreCientifico}");
        Console.WriteLine("=================================================");
        string TipodeRelación = "";
        string razon = "";
        switch (opcion)
        {
            //Mutualismo
            case 1:
                TipodeRelación = "Mutualismo (Relación Beneficiosa)";
                if (NombreCientifico == "Mimosa tenuiflora" && OtraEspecie.NombreCientifico == "Quercus rugosa")
                    razon = "Fija nitrógeno y mejora el suelo, lo que favoreceal roble.";
                else if (NombreCientifico == "Apis mellifera" && OtraEspecie.NombreCientifico == "Ficus insipida")
                    razon = "Abeja polinizadora y árbol frugívoro, beneficio mutuo.";
                else if (NombreCientifico == "Ficus insipida" && OtraEspecie.NombreCientifico == "Strix varia")
                    razon = "El árbol provee frutos, que atraen roedores alimento para el búho.";
                else if (NombreCientifico == "Pinus montezumae" && OtraEspecie.NombreCientifico == "Mimosa tenuiflora")
                    razon = "El pino recibe beneficios de la fertilidad del suelo enriquecido.";
                else
                    razon = "No hay una relación entre estas especies";
                break;
            //Competencia
            case 2:
                TipodeRelación = "Competencia (Interacción Negativa por Recursos)";
                if (NombreCientifico == "Quercus rugosa" && OtraEspecie.NombreCientifico == "Pinus montezumae")
                    razon = "Ambos son árboles productores, compiten por agua, luz y espacio.";
                else if (NombreCientifico == "Ficus insipida" && OtraEspecie.NombreCientifico == "Quercus rugosa")
                    razon = "Árboles grandes que compiten por luz y espacio en el dosel.";
                else if (NombreCientifico == "Strix varia" && OtraEspecie.NombreCientifico == "Felis concolor")
                    razon = "Ambos depredadores, compiten indirectamente porpresas pequeñas.";
                else
                    razon = "No hay relacion entre estas especies";
                break;
            //Neutralismo
            case 3:
                TipodeRelación = "Neutralismo (Sin Relación Significativa)";
                if (NombreCientifico == "Apis mellifera" && OtraEspecie.NombreCientifico == "Strix varia")
                    razon = "Polinizador y ave nocturna, funciones no relacionadas.";
                else if (NombreCientifico == "Pinus montezumae" && OtraEspecie.NombreCientifico == "Felis concolor")
                    razon = "Árbol productor y depredador tope, sin interacción directa.";
                else if (NombreCientifico == "Mimosa tenuiflora" && OtraEspecie.NombreCientifico == "Felis concolor")
                    razon = "Arbusto fijador de nitrógeno y depredador, roles no relacionados..";
                else if (NombreCientifico == "Ficus insipida" && OtraEspecie.NombreCientifico == "Apis mellifera")
                    razon = "Si no hay coincidencia temporal de floración, la relación es neutra.";
                else if (NombreCientifico == "Ficus insipida" && OtraEspecie.NombreCientifico == "Apis mellifera")
                    razon = "Si no hay coincidencia temporal de floración, la relación es neutra.";
                else
                    razon = "No hay relacion entre estas especies";
                break;
            //Efecto de abundancia
            case 4:
                TipodeRelación = "Efecto de Abundancia (Dominancia Ecológica)";
                if (NombreCientifico == "Quercus rugosa" && OtraEspecie.NombreCientifico == "Felis concolor")
                    razon = "La alta abundancia de robles determina la estructura del ecosistema.";
                else if (NombreCientifico == "Pinus montezumae" && OtraEspecie.NombreCientifico == "Mimosa tenuiflora")
                    razon = "Si la diferencia supera 50%, el pino limita el crecimiento de mimosas";
                else if (NombreCientifico == "Apis mellifera" && OtraEspecie.NombreCientifico == "Strix varia")
                    razon = "No hay interacción directa, pero la abeja podría dominar en cantidad.";
                else
                    razon = "No hay una relación entre estas especies";
                break;
        }
        Console.WriteLine($"{TipodeRelación}");
        Console.WriteLine("==================================================================================================================================");
        Console.WriteLine($"{"Espeie 1",-25} | {"Especie 2",-25} | {"Razón"}");
        Console.WriteLine("==================================================================================================================================");
        if (opcion == 4)
        {
            Console.WriteLine($"{NombreCientifico,-18}{Abundancia * 100}{"%",-8} | {OtraEspecie.NombreCientifico,-18}{OtraEspecie.Abundancia * 100}{"%",-8} | {razon}");
        }
        else
        {
            Console.WriteLine($"{NombreCientifico,-18}| {OtraEspecie.NombreCientifico,-18}| {razon}");
        }
        Console.WriteLine("==================================================================================================================================");
    }
    public Especie ClonarEspecie()
    {
            Console.WriteLine($"Se ha clonado: {NombreCientifico}");
            return new Especie(NombreCientifico, clasificacion, funcionEcologica, codigoGenetico, abundancia);
    }
}
class Program
{
    static List<Especie> Especies = new List<Especie>()
    {
        new Especie ("Quercus rugosa","Plantae, Magnoliophyta, Fagales", "Árbol productor de sombra","ATCGGCTAAGCT",0.42f),
        new Especie ("Pinus montezumae","Plantae,Pinophyta, Pinales","Árbol productor, retención de carbono","TCGATGCAAGTT",0.35f),
        new Especie("Mimosa tenuiflora","Plantae, Magnoliophyta, Fabales","Fijadora de nitrógeno en el suelo","GCTAGCTAATCG",0.25f),
        new Especie("Apis mellifera", "Animalia, Arthropoda, Hymenoptera", "Polinizador", "ATGCTAGCTTAC",0.18f),
        new Especie("Strix varia","Animalia, Chordata, Strigiformes","Ave depredadora (control de roedores)","CTAGTCGATGAC",0.12f),
        new Especie("Ficus insipida", "Plantae, Magnoliophyta, Rosales", "Árbol frugívoro, alimento para aves","TCGGATCGTAGC", 0.20f),
        new Especie("Felis concolor","Animalia, Chordata, Carnivora", "Depredador tope", "GATCGTACGTAG", 0.08f)
    };
    static void Indice()
    {
        int indice = 0;
        foreach (Especie especie in Especies)
        {
            Console.WriteLine($"{indice + 1}. {especie.NombreCientifico}");
            indice++;
        }
    }
    static void SComprar()
    {
        Console.WriteLine("==========Comparar Especies==========");
        Indice();
        Console.WriteLine("=====================================");
        Console.Write("Selecciones la primera espeice: ");
        int Especie1 = Convert.ToInt16(Console.ReadLine())-1;
        Console.WriteLine("=====================================");
        Indice();
        Console.WriteLine("=====================================");
        Console.Write("Selecciones la segunda espeice: ");
        int Especie2 = Convert.ToInt16(Console.ReadLine())-1;
        if (Especie1 < 0 || Especie1 >= Especies.Count && Especie2 <=0 || Especie2 >= Especies.Count)
        {
            Console.WriteLine("El valor ingresado no es valido");
            return;
        }
        Especies[Especie1].compararEspecies(Especies[Especie2]);
        Console.WriteLine("=====================================");
    }
    static void sModificar()
    {
        Console.WriteLine("==========Modificar abundancia==========");
        Indice();
        Console.WriteLine("================================================");
        Console.Write("Seleccione la especie que desea cambiar la: ");
        int Especie1 = Convert.ToInt16(Console.ReadLine())-1;
        if (Especie1 < 0 || Especie1 >= Especies.Count)
        {
            Console.WriteLine("El valor ingresado no es valido");
            return;
        }
        Console.WriteLine("================================================");
        Console.Write("Ingrese el nuevo valor en ddeciaml, ejemplo:(40% = 0.40): ");
        float Nuevovalor = float.Parse(Console.ReadLine());
        Especies[Especie1].ModificarAbundancia(Nuevovalor);
    }
    static void sClonar()
    {
        Console.WriteLine("=================Clonar Especie=================");
        Indice();
        Console.WriteLine("================================================");
        Console.Write("Seleccione la especie que sea clonar: ");
        int Especie1 = int.Parse(Console.ReadLine()) - 1;
        if (Especie1 < 0 || Especie1 >= Especies.Count)
        {
            Console.WriteLine("El valor ingresado no es valido");
            return;
        }
        Console.WriteLine("================================================");
        Especie clon = Especies[Especie1].ClonarEspecie();
        Especies.Add(clon);
    }
    static void sSimular()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("==========Simular Interacción Ecologica==========");
            Console.WriteLine("1. Mutualismo (Relación beneficiosa)");
            Console.WriteLine("2. Competencia (Interacción Negativa por Recursos)");
            Console.WriteLine("3. Neutralismo (Sin Relación Significativa)");
            Console.WriteLine("4. Efecto de Abundancia (Dominancia Ecológica)");
            Console.WriteLine("5. Salir");
            Console.WriteLine("==================================================");
            Console.Write("Seleccione una opcion: ");
            int opcion = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("=================================================");
            if (opcion == 5)
            {
                Console.WriteLine("Saliendor de la simulación");
                Console.WriteLine("Regresando al menu");
                salir = true;
                break;
            }
            Indice();
            Console.WriteLine("=================================================");
            Console.Write("Selecciones la primera espeice: ");
            int Especie1 = Convert.ToInt16(Console.ReadLine())-1;
            Console.WriteLine("=================================================");
            Console.Write("Selecciones la segunda espeice: ");
            int Especie2 = Convert.ToInt16(Console.ReadLine())-1;
            if (Especie1 < 0 || Especie1 >= Especies.Count &&  Especie2 <= 0 || Especie2 >= Especies.Count)
            {
                Console.WriteLine("El valor ingresado no es valido");
                continue;
            }
            Especies[Especie1].SimularInteraccionEcologica(Especies[Especie2],opcion);
        }

    }
    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("============MENU============");
            Console.WriteLine("1. Comparar Esepecies");
            Console.WriteLine("2. Modificar Abundancia");
            Console.WriteLine("3. Mostrar informacion de forma detalalda");
            Console.WriteLine("4. Simulación de interacción Ecologica");
            Console.WriteLine("5. Clonar Especie");
            Console.WriteLine("6. Salir");
            Console.WriteLine("============================");
            Console.Write("Seleccione una opcion: ");
            int opcion = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("============================");
            switch (opcion)
            {
                case 1:
                    Program.SComprar();
                    break;
                case 2:
                    Program.sModificar();
                    break;
                case 3:
                    foreach (var especie in Especies)
                    {
                        especie.MostrarInformacionDetallada();
                    }
                    break;
                case 4:
                    Program.sSimular();
                    break;
                case 5:
                    Program.sClonar();
                    break;
                case 6:
                    salir = true;
                    Console.WriteLine("Saliendo del programa"); 
                    break;
                default:
                    Console.WriteLine("Opcion no valida, intente de nuevo"); 
                    continue;
            }

        }
    }
}
