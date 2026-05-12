using System;

public class SistemaPedidos
{
    public static void Main()
    {
        MostrarTitulo();

        decimal monto = LeerMonto();
        string ciudad = LeerCiudad();
        string tipoCliente = LeerTipoCliente();
        int cantidadItems = LeerCantidadItems();

        string categoria = ObtenerCategoriaDespacho(monto, tipoCliente, cantidadItems);

        decimal costoEnvio = CalcularCostoEnvio(categoria, ciudad);

        string mensaje = GenerarMensaje(ciudad, categoria);

        MostrarResumen(categoria, costoEnvio, mensaje);
    }

    /// <summary>
    /// Muestra el título principal del sistema.
    /// </summary>
    public static void MostrarTitulo()
    {
        Console.WriteLine("=== SISTEMA DE CLASIFICACIÓN DE PEDIDOS ===\n");
    }

    /// <summary>
    /// Solicita y retorna el monto del pedido.
    /// </summary>
    /// <returns>Monto ingresado por el usuario.</returns>
    public static decimal LeerMonto()
    {
        Console.Write("Ingrese el monto del pedido: ");
        return decimal.Parse(Console.ReadLine());
    }

    /// <summary>
    /// Solicita y retorna la ciudad destino.
    /// </summary>
    /// <returns>Ciudad ingresada.</returns>
    public static string LeerCiudad()
    {
        Console.Write("Ingrese la ciudad destino: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Solicita y retorna el tipo de cliente.
    /// </summary>
    /// <returns>Tipo de cliente.</returns>
    public static string LeerTipoCliente()
    {
        Console.Write("Ingrese el tipo de cliente (nuevo/recurrente): ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Solicita y retorna la cantidad de ítems.
    /// </summary>
    /// <returns>Cantidad de ítems.</returns>
    public static int LeerCantidadItems()
    {
        Console.Write("Ingrese la cantidad de ítems: ");
        return int.Parse(Console.ReadLine());
    }

    /// <summary>
    /// Determina la categoría del despacho según las condiciones del pedido.
    /// </summary>
    /// <param name="monto">Monto total del pedido.</param>
    /// <param name="tipoCliente">Tipo de cliente.</param>
    /// <param name="cantidadItems">Cantidad de productos.</param>
    /// <returns>Categoría del despacho.</returns>
    public static string ObtenerCategoriaDespacho(decimal monto, string tipoCliente, int cantidadItems)
    {
        bool esRecurrente = tipoCliente.Equals("recurrente", StringComparison.OrdinalIgnoreCase);

        if (monto >= 150000 && esRecurrente)
        {
            return "Gratis";
        }
        else if (cantidadItems >= 5 || monto >= 300000)
        {
            return "Express";
        }
        else
        {
            return "Estándar";
        }
    }

    /// <summary>
    /// Calcula el costo del envío según categoría y destino.
    /// </summary>
    /// <param name="categoria">Categoría del despacho.</param>
    /// <param name="ciudad">Ciudad destino.</param>
    /// <returns>Costo total del envío.</returns>
    public static decimal CalcularCostoEnvio(string categoria, string ciudad)
    {
        decimal costo = 0;

        switch (categoria)
        {
            case "Gratis":
                costo = 0;
                break;

            case "Express":
                costo = 25000;
                break;

            default:
                costo = 12000;
                break;
        }

        bool esExterior = ciudad.Equals("exterior", StringComparison.OrdinalIgnoreCase);

        if (esExterior)
        {
            costo += 50000;
        }

        return costo;
    }

    /// <summary>
    /// Genera el mensaje final para el cliente.
    /// </summary>
    /// <param name="ciudad">Ciudad destino.</param>
    /// <param name="categoria">Categoría del despacho.</param>
    /// <returns>Mensaje personalizado.</returns>
    public static string GenerarMensaje(string ciudad, string categoria)
    {
        bool esExterior = ciudad.Equals("exterior", StringComparison.OrdinalIgnoreCase);

        if (esExterior)
        {
            return $"Su pedido internacional categoría {categoria} está en proceso.";
        }

        return $"¡Gracias por su compra! Su envío {categoria} llegará pronto.";
    }

    /// <summary>
    /// Muestra el resumen final del pedido.
    /// </summary>
    /// <param name="categoria">Categoría del envío.</param>
    /// <param name="costoEnvio">Costo total.</param>
    /// <param name="mensaje">Mensaje final.</param>
    public static void MostrarResumen(string categoria, decimal costoEnvio, string mensaje)
    {
        Console.WriteLine("\n--- Resumen de Pedido ---");
        Console.WriteLine($"Categoría: {categoria}");
        Console.WriteLine($"Costo de Envío: ${costoEnvio:N0}");
        Console.WriteLine($"Mensaje: {mensaje}");
        Console.WriteLine("-------------------------");
    }
}
