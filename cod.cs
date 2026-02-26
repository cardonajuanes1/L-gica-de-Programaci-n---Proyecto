using System;

public class SistemaPedidos
{
    public static void Main()
    {
        // Ejemplo de uso
        ClasificarPedido(160000, "Medellín", "recurrente", 3);
        ClasificarPedido(50000, "Madrid", "nuevo", 6);
        ClasificarPedido(320000, "Bogotá", "nuevo", 2);
    }

    public static void ClasificarPedido(decimal monto, string ciudad, string tipoCliente, int cantidadItems)
    {
        string categoriaDespacho;
        decimal costoEnvio = 0;
        string mensaje;

        // 1. Determinar Categoría de Despacho
        if (monto >= 150000 && tipoCliente.ToLower() == "recurrente")
        {
            categoriaDespacho = "Gratis";
            costoEnvio = 0;
        }
        else if (cantidadItems >= 5 || monto >= 300000)
        {
            categoriaDespacho = "Express";
            costoEnvio = 25000; // Valor base para express
        }
        else
        {
            categoriaDespacho = "Estándar";
            costoEnvio = 12000; // Valor base para estándar
        }

        // 2. Aplicar recargo por ciudad exterior
        if (ciudad.ToLower() == "exterior")
        {
            costoEnvio += 50000; // Recargo por envío internacional
            mensaje = $"Su pedido internacional categoría {categoriaDespacho} está en proceso.";
        }
        else
        {
            mensaje = $"¡Gracias por su compra! Su envío {categoriaDespacho} llegará pronto.";
        }

        // Mostrar Resultados
        Console.WriteLine("--- Resumen de Pedido ---");
        Console.WriteLine($"Categoría: {categoriaDespacho}");
        Console.WriteLine($"Costo de Envío: ${costoEnvio:N0}");
        Console.WriteLine($"Mensaje: {mensaje}");
        Console.WriteLine("-------------------------\n");
    }
}