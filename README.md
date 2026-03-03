using System;

public class SistemaPedidos
{
    public static void Main()
    {
        Console.WriteLine("=== BIENVENIDO AL SISTEMA DE DESPACHOS ===");

        // 1. Captura de datos del usuario
        Console.Write("Ingrese el monto del pedido: ");
        decimal monto = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Ingrese la ciudad de destino: ");
        string ciudad = Console.ReadLine();

        Console.Write("¿Es cliente 'nuevo' o 'recurrente'?: ");
        string tipoCliente = Console.ReadLine();

        Console.Write("Ingrese la cantidad de ítems: ");
        int cantidadItems = Convert.ToInt32(Console.ReadLine());

        // 2. Llamada a la función con los datos ingresados
        ClasificarPedido(monto, ciudad, tipoCliente, cantidadItems);
        
        // Mantener la consola abierta
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }

    public static void ClasificarPedido(decimal monto, string ciudad, string tipoCliente, int cantidadItems)
    {
        string categoriaDespacho;
        decimal costoEnvio = 0;
        string mensaje;

        // Lógica de clasificación
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

        // Recargo por envío al exterior
        if (ciudad.ToLower() == "exterior")
        {
            costoEnvio += 50000;
            mensaje = $"Su pedido internacional categoría {categoriaDespacho} está en proceso.";
        }
        else
        {
            mensaje = $"¡Gracias por su compra! Su envío {categoriaDespacho} llegará pronto.";
        }

        // Mostrar Resultados
        Console.WriteLine("\n-------------------------");
        Console.WriteLine("--- RESUMEN DE PEDIDO ---");
        Console.WriteLine($"Monto: ${monto:N0}");
        Console.WriteLine($"Ciudad: {ciudad}");
        Console.WriteLine($"Categoría: {categoriaDespacho}");
        Console.WriteLine($"Costo de Envío: ${costoEnvio:N0}");
        Console.WriteLine($"Total a Pagar: ${(monto + costoEnvio):N0}");
        Console.WriteLine($"Mensaje: {mensaje}");
        Console.WriteLine("-------------------------\n");
    }
}
