
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Text.RegularExpressions;

// ==========================================
// LIBRERÍAS DE QUESTPDF
// ==========================================
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CharlaProyecto_2_
{
    public partial class Form1 : Form
    {
        // ==========================================
        // VARIABLES PARA GUARDAR LOS DATOS
        // ==========================================
        private string correoValidado = "";
        private int edadValidada = 0;
        private bool datosValidos = false;

        public Form1()
        {
            InitializeComponent();
        }

        // ==========================================
        // VALIDAR EDAD AL ESCRIBIR
        // ==========================================
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir únicamente números y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

                // Emitir un sonido cuando se introduce un carácter inválido
                SystemSounds.Beep.Play();
            }
        }

        // ==========================================
        // BOTÓN PROCESAR
        // ==========================================
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Limpiar mensajes anteriores
            errorProviderInput.Clear();

            bool isValid = true;

            // ==========================================
            // VALIDACIÓN DEL CORREO
            // ==========================================
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProviderInput.SetError(
                    txtEmail,
                    "El correo electrónico es obligatorio."
                );

                isValid = false;
            }
            else if (!Regex.IsMatch(
                txtEmail.Text,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProviderInput.SetError(
                    txtEmail,
                    "El formato del correo es inválido."
                );

                isValid = false;
            }

            // Si el correo no es válido, detener el proceso
            if (!isValid)
            {
                datosValidos = false;
                return;
            }

            // ==========================================
            // VALIDACIÓN DE LA EDAD
            // ==========================================
            try
            {
                int age = int.Parse(txtAge.Text);

                // Verificar que la edad esté entre 18 y 99
                if (age < 18 || age > 99)
                {
                    throw new ArgumentOutOfRangeException(
                        "Age",
                        "La edad debe estar entre 18 y 99 años."
                    );
                }

                // ==========================================
                // GUARDAR DATOS VÁLIDOS
                // ==========================================
                correoValidado = txtEmail.Text;
                edadValidada = age;
                datosValidos = true;

                // Si todo está correcto
                MessageBox.Show(
                    "Datos procesados correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException fEx)
            {
                datosValidos = false;

                errorProviderInput.SetError(
                    txtAge,
                    "Debe ingresar un valor entero válido."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"[LOG ERROR]: {fEx.Message}"
                );
            }
            catch (ArgumentOutOfRangeException aEx)
            {
                datosValidos = false;

                errorProviderInput.SetError(
                    txtAge,
                    "La edad debe estar entre 18 y 99 años."
                );

                MessageBox.Show(
                    aEx.Message,
                    "Rango Inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                datosValidos = false;

                MessageBox.Show(
                    $"Error no controlado: {ex.Message}",
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // Mostrar la hora de la última ejecución
                lblStatus.Text =
                    $"Última ejecución: {DateTime.Now:HH:mm:ss}";
            }
        }

        // ==========================================
        // BOTÓN GENERAR PDF
        // ==========================================
        private void btnGeneratePdf_Click(object sender, EventArgs e)
        {
            try
            {
                // ==========================================
                // COMPROBAR SI LOS DATOS SON VÁLIDOS
                // ==========================================
                if (!datosValidos)
                {
                    MessageBox.Show(
                        "Primero debe procesar datos válidos antes de generar el PDF.",
                        "Datos no válidos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // ==========================================
                // CONFIGURAR LICENCIA DE QUESTPDF
                // ==========================================
                QuestPDF.Settings.License = LicenseType.Community;

                // ==========================================
                // NOMBRE DEL ARCHIVO
                // ==========================================
                string filePath =
                    System.IO.Path.Combine(
                        Application.StartupPath,
                        "Reporte_Validacion.pdf"
                    );

                // ==========================================
                // CREAR DOCUMENTO PDF
                // ==========================================
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        // Tamaño de página
                        page.Size(PageSizes.A4);

                        // Márgenes
                        page.Margin(50);

                        // ==========================================
                        // ENCABEZADO
                        // ==========================================
                        page.Header()
                            .AlignCenter()
                            .Text("REPORTE DE VALIDACIÓN")
                            .FontSize(22)
                            .Bold();

                        // ==========================================
                        // CONTENIDO
                        // ==========================================
                        page.Content()
                            .PaddingTop(30)
                            .Column(column =>
                            {
                                column.Spacing(15);

                                column.Item()
                                    .Text("Datos procesados correctamente.")
                                    .FontSize(14);

                                column.Item()
                                    .Text($"Correo electrónico: {correoValidado}")
                                    .FontSize(12);

                                column.Item()
                                    .Text($"Edad: {edadValidada} años")
                                    .FontSize(12);

                                column.Item()
                                    .Text("Estado: DATOS VÁLIDOS")
                                    .FontSize(14)
                                    .Bold();

                                column.Item()
                                    .Text(
                                        $"Fecha: {DateTime.Now:dd/MM/yyyy}"
                                    )
                                    .FontSize(12);

                                column.Item()
                                    .Text(
                                        $"Hora: {DateTime.Now:HH:mm:ss}"
                                    )
                                    .FontSize(12);
                            });

                        // ==========================================
                        // PIE DE PÁGINA
                        // ==========================================
                        page.Footer()
                            .AlignCenter()
                            .Text("Sistema de Validación - CharlaProyecto_2_")
                            .FontSize(10);
                    });
                })
                .GeneratePdf(filePath);

                // ==========================================
                // MENSAJE DE ÉXITO
                // ==========================================
                MessageBox.Show(
                    "El PDF se generó correctamente.\n\n" +
                    $"Ubicación:\n{filePath}",
                    "PDF Generado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar el PDF:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}



