using System;
using ClosedXML.Excel;

namespace SistemaNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("     SISTEMA DE NOTAS DE ESTUDIANTES");
            Console.WriteLine("======================================");
            Console.WriteLine();

            // Solicitar nombre
            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine();

            // Solicitar notas
            double nota1 = LeerNota("Nota 1: ");
            double nota2 = LeerNota("Nota 2: ");
            double nota3 = LeerNota("Nota 3: ");

            // Calcular promedio
            double promedio = (nota1 + nota2 + nota3) / 3;

            // Determinar estado
            string estado;

            if (promedio >= 71)
            {
                estado = "Aprobado";
            }
            else
            {
                estado = "Reprobado";
            }

            // Mostrar resultados
            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("             REPORTE");
            Console.WriteLine("======================================");
            Console.WriteLine("Nombre:   " + nombre);
            Console.WriteLine("Nota 1:   " + nota1);
            Console.WriteLine("Nota 2:   " + nota2);
            Console.WriteLine("Nota 3:   " + nota3);
            Console.WriteLine();
            Console.WriteLine("Promedio: " + promedio.ToString("0.00"));
            Console.WriteLine("Estado:   " + estado);
            Console.WriteLine("======================================");

            // Preguntar si desea exportar
            Console.WriteLine();
            Console.Write("¿Desea exportar el reporte a Excel? S/N: ");
            string respuesta = Console.ReadLine();

            if (respuesta.ToUpper() == "S")
            {
                ExportarExcel(nombre, nota1, nota2, nota3, promedio, estado);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No se generó ningún archivo Excel.");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Método para leer y validar las notas
        static double LeerNota(string mensaje)
        {
            double nota;

            while (true)
            {
                Console.Write(mensaje);

                if (double.TryParse(Console.ReadLine(), out nota))
                {
                    if (nota >= 0 && nota <= 100)
                    {
                        return nota;
                    }
                }

                Console.WriteLine("Error: Introduzca una nota entre 0 y 100.");
            }
        }

        // Método para generar el archivo Excel
        static void ExportarExcel(
            string nombre,
            double nota1,
            double nota2,
            double nota3,
            double promedio,
            string estado)
        {
            string nombreArchivo = "Reporte_Notas.xlsx";

            using (XLWorkbook libro = new XLWorkbook())
            {
                // Crear hoja
                IXLWorksheet hoja = libro.Worksheets.Add("Notas");

                // Título
                hoja.Cell("A1").Value = "REPORTE DE NOTAS";
                hoja.Range("A1:B1").Merge();

                // Datos del estudiante
                hoja.Cell("A3").Value = "Nombre";
                hoja.Cell("B3").Value = nombre;

                hoja.Cell("A4").Value = "Nota 1";
                hoja.Cell("B4").Value = nota1;

                hoja.Cell("A5").Value = "Nota 2";
                hoja.Cell("B5").Value = nota2;

                hoja.Cell("A6").Value = "Nota 3";
                hoja.Cell("B6").Value = nota3;

                hoja.Cell("A7").Value = "Promedio";
                hoja.Cell("B7").Value = promedio;

                hoja.Cell("A8").Value = "Estado";
                hoja.Cell("B8").Value = estado;

                // Formato del título
                hoja.Range("A1:B1").Style.Font.Bold = true;
                hoja.Range("A1:B1").Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;

                // Formato de los encabezados
                hoja.Range("A3:A8").Style.Font.Bold = true;

                // Formato del promedio
                hoja.Cell("B7").Style.NumberFormat.Format = "0.00";

                // Ajustar ancho de columnas
                hoja.Columns().AdjustToContents();

                // Guardar archivo
                libro.SaveAs(nombreArchivo);
            }

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("Excel generado correctamente.");
            Console.WriteLine("Archivo: " + nombreArchivo);
            Console.WriteLine("======================================");
        }
    }
}
