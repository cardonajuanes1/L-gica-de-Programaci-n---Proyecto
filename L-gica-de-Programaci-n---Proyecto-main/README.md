# Proyecto Final - Lógica de Programación

## Descripción

Sistema desarrollado en C# para gestionar ventas y clasificación de pedidos.

---

## Arquitectura del Proyecto

| Archivo | Responsabilidad |
|---|---|
| ProgramaVentas.cs | Registro y reporte de ventas |
| cod.cs | Clasificación de pedidos y costos de envío |

---

## Funciones principales

### ProgramaVentas.cs

- RegistrarVenta()
- MostrarReporte()
- CalcularTotal()
- CalcularPromedio()
- ObtenerMayorVenta()

### cod.cs

- ObtenerCategoriaDespacho()
- CalcularCostoEnvio()
- GenerarMensaje()

---

## Casos de prueba

### Caso 1

Entrada:
- Venta: 100000

Resultado:
- Total actualizado correctamente

---

### Caso 2

Entrada:
- Cliente recurrente
- Compra superior a 200000

Resultado:
- Categoría de envío gratis

---

## Cómo ejecutar

1. Abrir el proyecto en Visual Studio Code.
2. Ejecutar el comando:

dotnet run

3. Usar el menú por consola.

---

## Integrantes

- Juan Esteban Cardona Galeano
- Miguel Angel Velasquez Yepez