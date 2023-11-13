using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{    
    /// <summary>
    /// Empleado es una clase que sirve como base para sus tres derivados, reuniendo atributos y métodos comunes entre ellos.
    /// </summary>
    public abstract class Empleado : IMostrarDatos
    {
        protected string nombre;
        protected int legajo;
        protected ETurnos turnoDeTrabajo;
        protected bool disponibleHorasExtras;
        
        private Empleado(string nombre)
        {
            this.nombre = nombre;
            this.disponibleHorasExtras = true;
        }

        private Empleado(string nombre, int legajo):this(nombre)
        {
            this.legajo = legajo;
        }

        protected Empleado(string nombre, int legajo, ETurnos turnoDeTrabajo):this(nombre, legajo)
        {
            this.turnoDeTrabajo = turnoDeTrabajo;
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }

        public ETurnos TurnoDeTrabajo
        {
            get { return this.turnoDeTrabajo; }
            set { this.turnoDeTrabajo = value; }
        }

        public bool DisponibleHorasExtras
        {
            get { return this.disponibleHorasExtras; }
            set { this.disponibleHorasExtras = value; }
        }

        public abstract void CambiarDisponibilidadHorasExtras();

        public virtual string MostrarDatos(string titulo)
        {
            StringBuilder sb = new StringBuilder();
            string haceHorasExtra = this.disponibleHorasExtras ? "Si" : "No";

            sb.AppendLine(titulo);
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Legajo: {this.Legajo}");
            sb.AppendLine($"Turno de trabajo: {this.TurnoDeTrabajo}");            
            sb.AppendLine($"Disponible para horas extras: {haceHorasExtra}");

            return sb.ToString();
        }

        public virtual string MostrarDatos()
        {
            return $"{this.Nombre} - {this.Legajo} - {this.TurnoDeTrabajo}";
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        } 

        public override bool Equals(object obj)
        {
            return this == (Empleado)obj;
        }

        public static bool operator ==(Empleado primerEmpleado, Empleado segundoEmpleado)
        {
            string nombrePrimerEmpleado = primerEmpleado;
            string nombreSegundoEmpleado = segundoEmpleado;
            int legajoPrimerEmpleado = primerEmpleado;
            int legajoSegundoEmpleado = segundoEmpleado;
            ETurnos turnoPrimerEmpleado = primerEmpleado;
            ETurnos turnoSegundoEmpleado = segundoEmpleado;
            
            return (nombrePrimerEmpleado == nombreSegundoEmpleado && turnoPrimerEmpleado == turnoSegundoEmpleado) || legajoPrimerEmpleado == legajoSegundoEmpleado;
        }

        public static bool operator !=(Empleado primerEmpleado, Empleado segundoEmpleado)
        {
            return !(primerEmpleado == segundoEmpleado);
        }

        public static implicit operator string(Empleado empleado)
        {
            return empleado.nombre;
        }

        public static implicit operator int(Empleado empleado)
        {
            return empleado.legajo;
        }

        public static implicit operator ETurnos(Empleado empleado)
        {
            return empleado.turnoDeTrabajo;
        }
    }
}
