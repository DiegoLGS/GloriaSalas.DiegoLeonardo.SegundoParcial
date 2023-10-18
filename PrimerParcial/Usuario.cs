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
    public class Usuario
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string perfil { get; set; }

        private string ObtenerFechaActual()
        {
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = fechaActual.ToString("dd/MM/yyyy");

            return fechaFormateada;
        }

        private string ObtenerFechaYHoraActual()
        {
            DateTime fechaYHora = DateTime.Now;
            string formato = "yyyy-MM-dd HH:mm:ss";
            string fechaYHoraFormateada = fechaYHora.ToString(formato);
            return fechaYHoraFormateada;
        }

        public override string ToString()
        {
            return $"Bienvenido/a: {this.nombre} {this.apellido} - Fecha: {this.ObtenerFechaActual()}";
        }

        /// <summary>
        /// ObtenerDatosLog() Realiza una descripción completa del usuario logeado incluyendo fecha y hora del ingreso.
        /// </summary>
        /// <returns>La información reunida.</returns>
        public string ObtenerDatosLog()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------------------------------");
            sb.AppendLine($"Apellido: {this.apellido}");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Legajo: {this.legajo}");
            sb.AppendLine($"Correo: {this.correo}");
            sb.AppendLine($"Clave: {this.clave}");
            sb.AppendLine($"Perfil: {this.perfil}");
            sb.AppendLine($"Fecha y hora: {this.ObtenerFechaYHoraActual()}");
            sb.AppendLine("---------------------------------------");

            return sb.ToString();
        }
    }
}
