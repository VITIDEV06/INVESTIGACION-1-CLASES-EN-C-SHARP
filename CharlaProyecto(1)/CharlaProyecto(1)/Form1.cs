
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CharlaProyecto_1_
{
    public partial class Form1 : Form
    {
        // Lista de empleados
        private List<EmployeeModel> _employeeList;

        // Lista vinculada al DataGridView
        private BindingList<EmployeeModel> _employeeBindingList;

        public Form1()
        {
            InitializeComponent();

            // Inicializar la lista de empleados
            _employeeList = new List<EmployeeModel>();

            // Inicializar la lista vinculada
            _employeeBindingList = new BindingList<EmployeeModel>(_employeeList);

            // Conectar el DataGridView con la lista
            dataGridViewEmployees.DataSource = _employeeBindingList;

            // Configurar las columnas del DataGridView
            dataGridViewEmployees.AutoGenerateColumns = true;
            dataGridViewEmployees.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Agregar departamentos al ComboBox
            cbDepartment.Items.Add("Sistemas");
            cbDepartment.Items.Add("Recursos Humanos");
            cbDepartment.Items.Add("Contabilidad");
            cbDepartment.Items.Add("Ventas");
            cbDepartment.Items.Add("Administración");

            // Seleccionar el primer departamento
            cbDepartment.SelectedIndex = 0;
        }

        // ==========================================
        // BOTÓN: AGREGAR EMPLEADO
        // ==========================================
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar nombre
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show(
                        "Ingrese el nombre del empleado.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtName.Focus();
                    return;
                }

                // Validar salario
                if (!decimal.TryParse(txtSalary.Text, out decimal salary))
                {
                    MessageBox.Show(
                        "Ingrese un salario válido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSalary.Focus();
                    return;
                }

                // Crear un nuevo empleado
                EmployeeModel employee = new EmployeeModel
                {
                    Id = _employeeList.Count + 1,
                    FullName = txtName.Text,
                    Department = cbDepartment.SelectedItem?.ToString() ?? "General",
                    Salary = salary
                };

                // Agregar empleado a la lista
                _employeeBindingList.Add(employee);

                MessageBox.Show(
                    "Empleado agregado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Limpiar los campos
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al agregar el empleado: {ex.Message}",
                    "Excepción",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // BOTÓN: EXPORTAR JSON
        // ==========================================
        private void btnExportJson_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que existan empleados
                if (_employeeList.Count == 0)
                {
                    MessageBox.Show(
                        "No hay empleados para exportar.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Convertir la lista a formato JSON
                string jsonOutput = JsonConvert.SerializeObject(
                    _employeeList,
                    Formatting.Indented
                );

                // Crear el archivo JSON
                string filePath = Path.Combine(
                    Application.StartupPath,
                    "employees_data.json"
                );

                File.WriteAllText(filePath, jsonOutput);

                MessageBox.Show(
                    $"Datos exportados correctamente.\n\nArchivo guardado en:\n{filePath}",
                    "Exportación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error durante la serialización: {ex.Message}",
                    "Excepción",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // LIMPIAR CAMPOS
        // ==========================================
        private void ClearInputs()
        {
            txtName.Clear();
            txtSalary.Clear();

            if (cbDepartment.Items.Count > 0)
            {
                cbDepartment.SelectedIndex = 0;
            }

            txtName.Focus();
        }
    }
}


