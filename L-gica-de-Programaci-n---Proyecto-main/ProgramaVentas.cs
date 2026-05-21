using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<double> valoresVentas = new List<double>();

        int opcion;
        do
        {
            Console.WriteLine("\n===== SISTEMA DE CAJA =====");
            Console.WriteLine("1. Registrar venta");
            Console.WriteLine("2. Mostrar reporte del día");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    RegistrarVenta(valoresVentas);
                    break;

                case 2:
                    MostrarReporte(valoresVentas);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 0);
    }
/// <summary>
/// Registra una nueva venta.
/// </summary>
/// <param name="ventas">Lista de ventas.</param>
    static void RegistrarVenta(List<double> listaVentas)
    {
        Console.Write("Ingrese el nombre del producto: ");
        string nombreProducto = Console.ReadLine();

        int cantidad;
        Console.Write("Ingrese la cantidad: ");
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
        {
            Console.Write("Cantidad inválida. Ingrese un número válido mayor a 0: ");
        }

        double valorUnitario;
        Console.Write("Ingrese el valor unitario: ");
        while (!double.TryParse(Console.ReadLine(), out valorUnitario) || valorUnitario <= 0)
        {
            Console.Write("Valor inválido. Ingrese un número válido mayor a 0: ");
        }

        double valorTotalVenta = cantidad * valorUnitario;

        listaVentas.Add(valorTotalVenta);

        Console.WriteLine($"Venta registrada: {nombreProducto} | Total: ${valorTotalVenta}");
    }

   
/// <summary>
/// Muestra el reporte general de ventas.
/// </summary>
/// <param name="ventas">Lista de ventas registradas.</param>
static void MostrarReporte(List<double> ventas)
{
    Console.WriteLine("\n===== REPORTE DEL DÍA =====");

    Console.WriteLine($"Total vendido: {CalcularTotal(ventas)}");

    Console.WriteLine($"Promedio de ventas: {CalcularPromedio(ventas)}");

    Console.WriteLine($"Venta más alta: {ObtenerMayorVenta(ventas)}");
}/// <summary>
/// Calcula el total acumulado de ventas.
/// </summary>
/// <param name="ventas">Lista de ventas.</param>
/// <returns>Total vendido.</returns>
static double CalcularTotal(List<double> ventas)
{
    double total = 0;

    foreach (double venta in ventas)
    {
        total += venta;
    }

    return total;
}
/// <summary>
/// Calcula el promedio de ventas.
/// </summary>
/// <param name="ventas">Lista de ventas.</param>
/// <returns>Promedio de ventas.</returns>
static double CalcularPromedio(List<double> ventas)
{
    if (ventas.Count == 0)
    {
        return 0;
    }

    return CalcularTotal(ventas) / ventas.Count;
}/// <summary>
/// Obtiene la venta más alta.
/// </summary>
/// <param name="ventas">Lista de ventas.</param>
/// <returns>Mayor venta registrada.</returns>
static double ObtenerMayorVenta(List<double> ventas)
{
    double mayor = ventas[0];

    foreach (double venta in ventas)
    {
        if (venta > mayor)
        {
            mayor = venta;
        }
    }

    return mayor;
}
}