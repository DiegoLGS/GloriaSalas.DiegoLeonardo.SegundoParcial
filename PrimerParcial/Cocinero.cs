﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    /// <summary>
    /// Cocinero obtiene características de la clase abstracta Empleado, agrega especialidad(string) y certificacion(string)
    /// que corresponde a sus características exclusivas.
    /// </summary>
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
        }

        public override string MostrarDatos(string titulo)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos(titulo));
            sb.AppendLine($"Especialidad: {this.especialidad}");
            sb.AppendLine($"Certificación: {this.certificacion}");

            return sb.ToString();
        }

        public override string MostrarDatos()
        {
            return "Cocinero: " + base.MostrarDatos();
        }
    }
}
