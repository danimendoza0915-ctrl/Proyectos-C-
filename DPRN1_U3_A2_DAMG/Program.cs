using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("///Bienvenido al gestor de descuentos///");
        Console.Write("Ingrese el tipo de cliente al que pertenece (regular, frecuente, vip):");
        string TipoCliente = Console.ReadLine().Trim().ToLower();
        if (TipoCliente != "regular" && TipoCliente !="frecuente" && TipoCliente !="vip")
        {
            Console.WriteLine("El tipo de usuario ingresado no es valido");return;
        }
        Console.Write("Ingrese el monto de la compra: ");
        if(!decimal.TryParse(Console.ReadLine(),out decimal MontoCompra) || MontoCompra<=0 )
        {
            Console.WriteLine("El monto ingresado no es valido: ");return;
        }
        decimal Descuento = 0;
        if (MontoCompra > 100)
        {
            switch (TipoCliente)
            {
                case "regular":
                Descuento = 0.05m ; break;
                case "frecuente":
                Descuento=MontoCompra > 500 ? 0.15m : 0.10m; break;
                case "vip":
                Descuento=MontoCompra > 500 ? 0.25m : 0.20m; break;
            }
        }
        decimal DescuentoT = MontoCompra * Descuento;
        decimal Total = MontoCompra - DescuentoT;

        Console.WriteLine($"\n///Tipo de usuario: {TipoCliente}///");
        Console.WriteLine($"Descuento aplicado: {Descuento*100}%");
        Console.WriteLine($"Monto descontado: ${DescuentoT:F2}");
        Console.WriteLine($"Total a pagar: ${Total:F2}");
    }
}