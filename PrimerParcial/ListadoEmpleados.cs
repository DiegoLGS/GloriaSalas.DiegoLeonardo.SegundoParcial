using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class ListadoEmpleados
    {
        public List<Empleado> listaDeEmpleados = new List<Empleado>();

        public List<Empleado> ListaDeEmpleados 
        {
            get { return listaDeEmpleados; } 
            set { listaDeEmpleados = value;}
        }

        public void OrdenarLista(string parametroOrdenamiento, bool ascendente)
        {
            if(parametroOrdenamiento == "nombre")
            {
                this.listaDeEmpleados.Sort((x, y) => ascendente ? x.Nombre.CompareTo(y.Nombre) : y.Nombre.CompareTo(x.Nombre));
            }
            else
            {
                this.listaDeEmpleados.Sort((x, y) => ascendente ? x.Legajo.CompareTo(y.Legajo) : y.Legajo.CompareTo(x.Legajo));

            }
        } 

        public static bool operator +(ListadoEmpleados lista, Empleado empleado)
        {
            bool respuesta = false;

            if(lista != empleado)
            {
                lista.listaDeEmpleados.Add(empleado);
                respuesta = true;
            }
            return respuesta;
        }

        public static bool operator -(ListadoEmpleados lista, Empleado empleado)
        {
            bool respuesta = false;

            if(lista == empleado)
            {
                lista.listaDeEmpleados.Remove(empleado);
                respuesta = true;
            }
            return respuesta;
        }

        public static bool operator ==(ListadoEmpleados lista, Empleado empleado)
        {
            bool respuesta = false;

            if (lista.listaDeEmpleados.Contains(empleado))
            {
                respuesta = true;
            }

            return respuesta;
        }

        public static bool operator !=(ListadoEmpleados lista, Empleado empleado)
        {
            return !(lista == empleado);
        }
    }
}
