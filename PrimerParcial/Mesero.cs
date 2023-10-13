using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
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

        public override void CambiarDisponibilidadHorasExtras()
        {
            this.disponibleHorasExtras = !this.disponibleHorasExtras;
            Console.WriteLine("Disponibilidad para hacer horas extras cambiada");
        }

        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine($"Zona de atención: {this.zonaDeAtencion}");
            sb.AppendLine($"Número de mesas: {this.numeroDeMesas}");

            return sb.ToString();
        }
    }
}
