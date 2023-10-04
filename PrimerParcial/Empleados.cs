using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public abstract class Empleado
    {
        protected string nombre;
        protected int legajo;
        protected int antiguedad;
        protected bool disponibleHorasExtras = true;

        private Empleado(string nombre)
        {
            this.nombre = nombre;
            this.antiguedad = 0;
        }

        public Empleado(string nombre, int legajo):this(nombre)
        {
            this.legajo = legajo;
        }

        public Empleado(string nombre, int legajo, int antiguedad):this(nombre, legajo)
        {
            this.antiguedad = antiguedad;
        }

        protected abstract void CambiarHorasExtras();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.nombre} - {this.legajo} - {this.antiguedad}");
            return sb.ToString();
        }
    }
}
