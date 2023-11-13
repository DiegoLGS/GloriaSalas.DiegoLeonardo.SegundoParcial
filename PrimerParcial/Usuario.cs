using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    /// <summary>
    /// Usuario almacena los datos del usuario logeado en la aplicación, puede mostrarlos junto con la fecha o fecha y hora
    /// del momento del ingreso.
    /// </summary>
    public class Usuario : IMostrarDatos
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string perfil { get; set; }

        private string ObtenerFechaActual(string formato)
        {
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = fechaActual.ToString(formato);

            return fechaFormateada;
        }

        public override string ToString()
        {
            return $"Bienvenido/a: {this.nombre} {this.apellido} - Fecha: {this.ObtenerFechaActual("dd/MM/yyyy")}";
        }

        /// <summary>
        /// MostrarDatos() Realiza una descripción completa del usuario logeado incluyendo fecha y hora del ingreso.
        /// </summary>
        /// <returns>La información reunida.</returns>
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------------------------------");
            sb.AppendLine($"Apellido: {this.apellido}");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Legajo: {this.legajo}");
            sb.AppendLine($"Correo: {this.correo}");
            sb.AppendLine($"Clave: {this.clave}");
            sb.AppendLine($"Perfil: {this.perfil}");
            sb.AppendLine($"Fecha y hora: {this.ObtenerFechaActual("yyyy-MM-dd HH:mm:ss")}");
            sb.AppendLine("---------------------------------------");

            return sb.ToString();
        }
    }
}
