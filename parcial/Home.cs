using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parcial
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Panel_Empleados_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btn_empleados_Click(object sender, EventArgs e)
        {
            Panel_Empleados.Visible = true;
            panelEmpleadoSuperior.Visible = true;
            panelEmpleadoInferior.Visible = true;
        }

        private void btn_employee_exit_Click(object sender, EventArgs e)
        {
            Panel_Empleados.Visible = false;
            panelEmpleadoSuperior.Visible = false;
            panelEmpleadoInferior.Visible = false;
        }

        private void btn_new_employee_Click(object sender, EventArgs e)
        {
            NewEmployee Empleado = new NewEmployee();
            Empleado.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void cargarGrid()
        {
            Empleado EmpleadoNuevo = new Empleado();
            char separador = '-'; //Separador para txt
            string pathCarpeta = @"C:\Parcial\"; //Ubicacion donde se van a generar los archivos
            string loginArchivo = @"Users.txt"; //Ruta del archivo con la informacion de logeo
            string nombreArchivo = @"Datos.txt"; //Nombre del archivo txt con datos de los empleados
            string rutaArchivoLogin = Path.Combine(pathCarpeta, loginArchivo);
            string rutaArchivoDatos = Path.Combine(pathCarpeta, nombreArchivo);
            string[] datos = new string[9]; // Arreglo para escribir o leer datos
            string[] usuario = new string[2];
            int i=0;
            int columnas = 1;
            try //Intentamos acceder al archivo con los datos
            {
                using (var streamdata = File.Create(rutaArchivoDatos));  
                StreamReader streamReaderDatos = new StreamReader(rutaArchivoDatos);
                StreamReader streamReaderUsuarios = new StreamReader(rutaArchivoLogin);
                string json = streamReaderDatos.ReadLine();
                string jsonUsers = streamReaderUsuarios.ReadLine();
                while (json != null && jsonUsers != null )
                {
                    int legajo = Convert.ToInt32(datos[0]);
                    int DNI = Convert.ToInt32(datos[3]);
                    datos = json.Split(separador);
                    usuario = jsonUsers.Split(separador);
                    EmpleadoNuevo.Legajo = legajo;
                    EmpleadoNuevo.Apellido = datos[1];
                    EmpleadoNuevo.Nombre = datos[2];
                    EmpleadoNuevo.DNI = DNI;
                    EmpleadoNuevo.FechaNacimiento = Convert.ToDateTime(datos[4]);
                    EmpleadoNuevo.Domicilio = datos[5];
                    EmpleadoNuevo.Dpto = datos[6];
                    EmpleadoNuevo.Piso = datos[7];
                    EmpleadoNuevo.Usuario = usuario[0];
                    json = streamReaderDatos.ReadLine();
                    GridEmpleados.Rows[columnas].Cells[1].Value=EmpleadoNuevo.Legajo;
                    GridEmpleados.Rows[columnas].Cells[2].Value = EmpleadoNuevo.Apellido;
                    GridEmpleados.Rows[columnas].Cells[3].Value = EmpleadoNuevo.Nombre;
                    GridEmpleados.Rows[columnas].Cells[4].Value = EmpleadoNuevo.DNI;
                    GridEmpleados.Rows[columnas].Cells[5].Value = EmpleadoNuevo.FechaNacimiento;
                    GridEmpleados.Rows[columnas].Cells[6].Value = EmpleadoNuevo.Domicilio;
                    GridEmpleados.Rows[columnas].Cells[7].Value = EmpleadoNuevo.Dpto;
                    GridEmpleados.Rows[columnas].Cells[8].Value = EmpleadoNuevo.Piso;
                    GridEmpleados.Rows[columnas].Cells[9].Value = EmpleadoNuevo.Usuario;
                    columnas++;
                }
                streamReaderDatos.Close();
                streamReaderUsuarios.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }

        private void labelUsuarioConectado_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
    }
}
