using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace parcial
{

    public class Empleado
    {
        public Empleado()
        {
            this.Contraseña = "P.a.s.s";
            this.FechaNacimiento = DateTime.Now.Date;
        }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Domicilio { get; set; }
        public string Dpto { get; set; }
        public string Piso { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
