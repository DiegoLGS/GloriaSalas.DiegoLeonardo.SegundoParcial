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
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Legajo: {this.legajo}");
            sb.AppendLine($"Turno de trabajo: {this.turnoDeTrabajo}");            
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

            return nombrePrimerEmpleado == nombreSegundoEmpleado && legajoPrimerEmpleado == legajoSegundoEmpleado;
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
    }
}
