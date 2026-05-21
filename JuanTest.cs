using System;

public class SistemaPedidos
{
    public static void Main()
    {
        Console.WriteLine("=== SISTEMA DE CLASIFICACIÓN DE PEDIDOS ===\n");

        // Lectura de datos
        Console.Write("Ingrese el monto del pedido: ");
        decimal monto = decimal.Parse(Console.ReadLine());

        Console.Write("Ingrese la ciudad destino: ");
        string ciudad = Console.ReadLine();

        Console.Write("Ingrese el tipo de cliente (nuevo/recurrente): ");
        string tipoCliente = Console.ReadLine();

        Console.Write("Ingrese la cantidad de ítems: ");
        int cantidadItems = int.Parse(Console.ReadLine());

        ClasificarPedido(monto, ciudad, tipoCliente, cantidadItems);
    }

    public static void ClasificarPedido(decimal monto, string ciudad, string tipoCliente, int cantidadItems)
    {
        string categoriaDespacho;
        decimal costoEnvio;
        string mensaje;

        //  Determinar categoría
        if (monto >= 150000 && tipoCliente.ToLower() == "recurrente")
        {
            categoriaDespacho = "Gratis";
            costoEnvio = 0;
        }
        else if (cantidadItems >= 5 || monto >= 300000)
        {
            categoriaDespacho = "Express";
            costoEnvio = 25000;
        }
        else
        {
            categoriaDespacho = "Estándar";
            costoEnvio = 12000;
        }

        //  Recargo internacional
        if (ciudad.ToLower() == "exterior")
        {
            costoEnvio += 50000;
            mensaje = $"Su pedido internacional categoría {categoriaDespacho} está en proceso.";
        }
        else
        {
            mensaje = $"¡Gracias por su compra! Su envío {categoriaDespacho} llegará pronto.";
        }

        //  Mostrar resultados
        Console.WriteLine("\n--- Resumen de Pedido ---");
        Console.WriteLine($"Categoría: {categoriaDespacho}");
        Console.WriteLine($"Costo de Envío: ${costoEnvio:N0}");
        Console.WriteLine($"Mensaje: {mensaje}");
        Console.WriteLine("-------------------------");
    }
}
