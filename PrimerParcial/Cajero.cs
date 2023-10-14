using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Cajero : Empleado
    {
        private int propinaActual;
        private int cajaAsignada;

        private Cajero(string nombre, int legajo, ETurnos turnoDeTrabajo):base(nombre, legajo, turnoDeTrabajo)
        {
        }

        private Cajero(string nombre, int legajo, ETurnos turnoDeTrabajo, int propinaActual):this(nombre, legajo, turnoDeTrabajo)
        {
            this.propinaActual = propinaActual;
        }

        public Cajero(string nombre, int legajo, ETurnos turnoDeTrabajo, int propinaActual, int cajaAsignada):this(nombre, legajo, turnoDeTrabajo, propinaActual)
        {
            this.cajaAsignada = cajaAsignada;
        }

        public int PropinaActual
        {
            get { return this.propinaActual; }
            set { this.propinaActual = value; }
        }

        public int CajaAsignada
        {
            get { return this.cajaAsignada; }
            set { this.cajaAsignada = value; }
        }

        public override void CambiarDisponibilidadHorasExtras()
        {
            this.disponibleHorasExtras = !this.disponibleHorasExtras;
            Console.WriteLine("Disponibilidad para hacer horas extras cambiada");
        }

        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine($"Propina actual: {this.propinaActual}");
            sb.AppendLine($"Caja asignada: {this.cajaAsignada}");

            return sb.ToString();
        }
    }
}
