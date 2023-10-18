using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    /// <summary>
    /// Mesero obtiene características de la clase abstracta Empleado, agrega zonaDeAtención(string) y numeroDeMesas(int)
    /// que corresponde a sus características exclusivas.
    /// </summary>
    public class Mesero : Empleado
    {
        private string zonaDeAtencion;
        private int numeroDeMesas;

        private Mesero(string nombre, int legajo, ETurnos turnoDeTrabajo):base(nombre, legajo, turnoDeTrabajo)
        {            
        }

        private Mesero(string nombre, int legajo, ETurnos turnoDeTrabajo, string zonaDeAtencion):this(nombre, legajo, turnoDeTrabajo)
        {
            this.zonaDeAtencion = zonaDeAtencion;
        }

        public Mesero(string nombre, int legajo, ETurnos turnoDeTrabajo, string zonaDeAtencion, int numeroDeMesas):this(nombre, legajo, turnoDeTrabajo, zonaDeAtencion)
        {
            this.numeroDeMesas = numeroDeMesas;
        }

        public string ZonaDeAtencion
        {
            get { return this.zonaDeAtencion; }
            set { this.zonaDeAtencion = value; }
        }

        public int NumeroDeMesas
        {
            get { return this.numeroDeMesas; }
            set { this.numeroDeMesas= value; }
        }

        public override void CambiarDisponibilidadHorasExtras()
        {
            this.disponibleHorasExtras = !this.disponibleHorasExtras;
        }

        public override string MostrarDatos(string titulo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos(titulo));
            sb.AppendLine($"Zona de atención: {this.zonaDeAtencion}");
            sb.AppendLine($"Número de mesas: {this.numeroDeMesas}");

            return sb.ToString();
        }

        public override string MostrarDatos()
        {
            return "Mesero: " + base.MostrarDatos();
        }
    }
}
