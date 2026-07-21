using System;

class Inventario
{
    private int Chocolates;
    private int CocaCola;
    private int Maruchan; 
    private int Pilas;
    private int sabritas;

    public void InicializarProductosProductos()
    { 
        Chocolates=100;
        CocaCola=100;
        Maruchan=100;
        Pilas=100;
        sabritas=100;
        Console.WriteLine("Productos iniciados con cantidad de 100 cada uno");
    }
    public void Agregar1(int AgregarCantidad){
        Chocolates += AgregarCantidad;
    }
     public void Agregar2(int AgregarCantidad){
        CocaCola += AgregarCantidad;
    }
    public void Agregar3(int AgregarCantidad){
        Maruchan += AgregarCantidad;
    }
    public void Agregar4(int AgregarCantidad){
        Pilas += AgregarCantidad;
    }
    public void Agregar5(int AgregarCantidad){
        sabritas+=AgregarCantidad;
    }
    public void Quitar1(int QuitarCantidad){
        if(Chocolates>=QuitarCantidad)
        Chocolates -= QuitarCantidad;
        else Console.WriteLine("No hay sufiete cantidad de Chocolates");
    }
    public void Quitar2(int QuitarCantidad){
        if(CocaCola>=QuitarCantidad)
        CocaCola -=QuitarCantidad;
        else Console.WriteLine("No hay suficiente cantidad de Coca cola");
    }
    public void Quitar3(int QuitarCantidad){
        if (Maruchan>=QuitarCantidad)
        Maruchan-=QuitarCantidad;
        else Console.WriteLine("No hay cantidad sufiente de Maruchan");
    }
    
    public void Quitar4(int QuitarCantidad){
        if (Pilas>=QuitarCantidad)
        Pilas-=QuitarCantidad;
        else Console.WriteLine("No hay cantidad sufiente de Pilas");
    }
    
    public void Quitar5(int QuitarCantidad){
        if (sabritas>=QuitarCantidad)
        sabritas-=QuitarCantidad;
        else Console.WriteLine("No hay cantidad sufiente de Sabritas");
    }
    public void Mostrar()
    {
        Console.WriteLine("Inventario");
        Console.WriteLine($"1. Chocolates: {Chocolates} unidades");
        Console.WriteLine($"2. Coca cola: {CocaCola} unidades");
        Console.WriteLine($"3. Maruchan: {Maruchan} unidades");
        Console.WriteLine($"4. Pilas: {Pilas} unidades");
        Console.WriteLine($"5: Sabritas {sabritas} unidades");
    }
    public void  VerificarStock(int numero){
      switch(numero){
        case 1:
        if (Chocolates>0) 
        Console.WriteLine($"El producto chocolates esta disponble con {Chocolates} unidades ");
        else Console.WriteLine("El producto no esta disponible"); 
        break;
        case 2:
        if (CocaCola>0)
        Console.WriteLine($"El producto Coca cola esta disponble con {CocaCola} unidades ");       
        else Console.WriteLine("El producto no esta disponible");
        break;
        case 3:
        if (Maruchan>0)
        Console.WriteLine($"El producto Maruchan esta disponble con {Maruchan} unidades ");       
        else Console.WriteLine("El producto no esta disponible");
        break;
        case 4:
        if (Pilas>0)
        Console.WriteLine($"El producto pilas esta disponble con {Pilas} unidades ");       
        else  Console.WriteLine("El producto no esta disponible");
        break;
        case 5:
        if (sabritas>0)
        Console.WriteLine($"El producto Sabritas esta disponble con {sabritas} unidades ");       
        else Console.WriteLine("El producto no esta disponible");
        break;
      }
    }
    static void Main()
    {   
        Inventario inventario = new Inventario();
        inventario.InicializarProductosProductos();
        bool salir = false;
        while (!salir)
        {
        Console.WriteLine("Sistema de inventario");
        Console.WriteLine("1. Agregar Cantidad");
        Console.WriteLine("2. Restar cantidad");
        Console.WriteLine("3. Mostrar inventario");
        Console.WriteLine("4. Verificar stock ");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione la opcion: ");
        int opcion= Convert.ToInt16(Console.ReadLine());
        switch(opcion){
            case 1:
            Console.WriteLine("Seleccione la opcion: ");
            Console.WriteLine("---Productos disponibles y cantidades---");
            Console.WriteLine("---1. Chocolates---");
            Console.WriteLine("---2. Coca cola---");
            Console.WriteLine("---3. Maruchan --");
            Console.WriteLine("---4. Pilas --");
            Console.WriteLine("---5. Sabritas --");
            Console.Write("Seleccione el producto: ");
            int opc=Convert.ToInt16(Console.ReadLine());
            Console.Write("Ingrese la unidades que desea agregar: ");
            int AgregarCantidad=int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1: 
                inventario.Agregar1(AgregarCantidad);break;
                case 2: 
                inventario.Agregar2(AgregarCantidad);break;
                case 3: 
                inventario.Agregar3(AgregarCantidad);break;
                case 4:
                inventario.Agregar4(AgregarCantidad);break;
                case 5:
                inventario.Agregar5(AgregarCantidad);break;
            }
            break;
            case 2:
            Console.WriteLine("Seleccione la opcion: ");
            Console.WriteLine("---Productos disponibles y cantidades---");
            Console.WriteLine("---1. Chocolates---");
            Console.WriteLine("---2. Coca cola---");
            Console.WriteLine("---3. Maruchan --");
            Console.WriteLine("---4. Pilas --");
            Console.WriteLine("---5. Sabritas --");
            Console.Write("Seleccione el producto: ");
            int op=Convert.ToInt16(Console.ReadLine());
            Console.Write("Ingrese cuantos productos desea quitar: ");
            int QuitarCantidad=int.Parse(Console.ReadLine());
            switch(op)
            {
                case 1:
                inventario.Quitar1(QuitarCantidad);break; 
                case 2:
                inventario.Quitar2(QuitarCantidad);break; 
                case 3:
                inventario.Quitar3(QuitarCantidad);break; 
                case 4:
                inventario.Quitar4(QuitarCantidad);break;
                case 5:
                inventario.Quitar5(QuitarCantidad);break;             

            }
            break;
            case 3:
            inventario.Mostrar();
            break;
            case 4:
            Console.WriteLine("Seleccione la opcion: ");
            Console.WriteLine("---Productos disponibles y cantidades---");
            Console.WriteLine("---1. Chocolates---");
            Console.WriteLine("---2. Coca cola---");
            Console.WriteLine("---3. Maruchan --");
            Console.WriteLine("---4. Pilas --");
            Console.WriteLine("---5. Sabritas --");
            Console.Write("Seleccione el producto: ");
            int numero=Convert.ToInt16(Console.ReadLine());
            Console.Write("Ingrese la unidades que desea agregar: ");
            switch(numero)
            {
                case 1:
                inventario.VerificarStock(numero);break; 
                case 2:
                inventario.VerificarStock(numero);break; 
                case 3:
                inventario.VerificarStock(numero);break;  
                case 4:
                inventario.VerificarStock(numero);break;  
                case 5:
                inventario.VerificarStock(numero);break;  
            }
            break;
            case 5:
                salir = true;
                Console.WriteLine("Saliendo del programa...");
                break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
        }
        }
    }
}