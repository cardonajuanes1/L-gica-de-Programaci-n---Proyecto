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

    static void MostrarReporte(List<double> listaVentas)
    {
        if (listaVentas.Count == 0)
        {
            Console.WriteLine("⚠️ No hay ventas registradas en el día.");
            return;
        }

        double totalVendido = 0; // acumulador
        int cantidadVentas = listaVentas.Count; // contador

        foreach (double venta in listaVentas)
        {
            totalVendido += venta;
        }

        double promedioVenta = totalVendido / cantidadVentas;
        double ventaMayor = listaVentas.Max();

        Console.WriteLine("\n===== REPORTE DEL DÍA =====");
        Console.WriteLine($"Total vendido: ${totalVendido}");
        Console.WriteLine($"Promedio por venta: ${promedioVenta}");
        Console.WriteLine($"Venta de mayor valor: ${ventaMayor}");
        Console.WriteLine($"Cantidad de ventas registradas: {cantidadVentas}");
    }
}