using parcial.Security;

namespace parcial
{
    public partial class FormLogin : Form
    {
        // Universidad Tecnologica Nacional - Tecnicatura Superior en Programacion
        // Laboratorio de Programacion 1 - Segundo Parcial - 23/06/2022
        // Rey, Benjamin - 42006789
        // Marcos Cortez - 45275543
        //

        int log_cont = 0; //Variable global
        string user_verification;
        string pass_verification;
        public FormLogin()
        {
            InitializeComponent();

        }
        public void Home() // Funcion para llamar el menu principal del programa
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        public void login()
        {
            string pathCarpeta = @"C:\Parcial\"; //Ruta de los archivos txt
            string loginArchivo = @"Users.txt"; //Ruta del archivo con la informacion de logeo
            string rutaArchivoLogin = Path.Combine(pathCarpeta, loginArchivo);
            log_cont++; // Contador de intentos de logeo
            try
            {
                user_verification = txbUser.Text;
                pass_verification = HashDirectory.ToSHA256(txbPass.Text);
                string login;
                string[] array = new string[2];
                char[] separador = { '-' }; // Separador para el archivo txt
                bool autorizado = false;
                StreamReader readusers;
                readusers = File.OpenText(rutaArchivoLogin); // Leemos el archivo Login.txt
                login = readusers.ReadLine();
                while (login != null && autorizado == false)
                {
                    array = login.Split(separador);
                    if (array[0].Trim().Equals(user_verification) && array[1].Trim().Equals(pass_verification))
                    {
                        MessageBox.Show("Usuario y contraseña correctas", "Login correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        autorizado = true;
                        Home();
                    }
                    else
                    {
                        login = readusers.ReadLine();
                    }
                    if (autorizado == false)
                    {

                        MessageBox.Show("Usuario o contraseña incorrectos.", $"Intentos fallidos {log_cont}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (log_cont > 2)
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            login();
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void registerlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewEmployee Empleados = new NewEmployee();
            Empleados.Show();
        }
    }
}
