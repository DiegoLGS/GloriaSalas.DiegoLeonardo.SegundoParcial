using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Cocinero : Empleado
    {
        private string especialidad;
        private string certificacion;

        private Cocinero(string nombre, int legajo, ETurnos turnoDeTrabajo):base(nombre, legajo, turnoDeTrabajo)
        {
        }

        private Cocinero(string nombre, int legajo, ETurnos turnoDeTrabajo, string especialidad):this(nombre, legajo, turnoDeTrabajo)
        {
            this.especialidad = especialidad;
        }

        public Cocinero(string nombre, int legajo, ETurnos turnoDeTrabajo, string especialidad, string certificacion):this(nombre, legajo, turnoDeTrabajo, especialidad)
        {
            this.certificacion = certificacion;
        }

        public string Especialidad
        {
            get { return this.especialidad; } 
            set { this.especialidad = value; }
        }

        public string Certificacion
        {
            get { return this.certificacion; }
            set { this.certificacion = value; }
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
            sb.AppendLine($"Especialidad: {this.especialidad}");
            sb.AppendLine($"Certificación: {this.certificacion}");

            return sb.ToString();
        }
    }
}
