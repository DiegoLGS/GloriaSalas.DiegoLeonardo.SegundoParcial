using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    /// <summary>
    /// ListadoEmpleados es una lista genérica que almacena a los derivados de Empleado, además los puede ordenar y comparar.
    /// </summary>
    public class ListadoEmpleados<T> where T : Empleado
    {
        public List<T> listaDeEmpleados = new List<T>();

        public List<T> ListaDeEmpleados 
        {
            get { return listaDeEmpleados; } 
            set { listaDeEmpleados = value;}
        }

        public void OrdenarLista(string parametroOrdenamiento, bool ascendente)
        {
            if (parametroOrdenamiento == "nombre")
            {
                this.listaDeEmpleados.Sort((x, y) => ascendente ? x.Nombre.CompareTo(y.Nombre) : y.Nombre.CompareTo(x.Nombre));
            }
            else
            {
                this.listaDeEmpleados.Sort((x, y) => ascendente ? x.Legajo.CompareTo(y.Legajo) : y.Legajo.CompareTo(x.Legajo));

            }
        }

        /// <summary>
        /// ComprobarCoindicencia() busca en la lista indicada a un empleado para verificar si existe en ella, con la salvedad
        /// de tratarse del propio empleado.
        /// </summary>
        /// <param name="lista">Lista a ser verificada.</param>
        /// <param name="empleadoAComprobar">Empleado que se buscará en la lista.</param>
        /// <param name="indice">Indice del empleado para evitar compararlo consigo mismo.</param>
        /// <returns></returns>
        public static bool ComprobarCoindicencia(ListadoEmpleados<T> lista, T empleadoAComprobar, int indice)
        {
            bool coincidencia = false;

            foreach (T empleado in lista.listaDeEmpleados)
            {
                if (empleado == empleadoAComprobar && indice != lista.listaDeEmpleados.IndexOf(empleado))
                {
                    coincidencia = true;
                    break;
                }
            }

            return coincidencia;
        }

        public static bool operator +(ListadoEmpleados<T> lista, T empleado)
        {
            bool respuesta = false;

            if (lista != empleado)
            {
                lista.listaDeEmpleados.Add(empleado);
                respuesta = true;
            }
            return respuesta;
        }

        public static bool operator -(ListadoEmpleados<T> lista, T empleado)
        {
            bool respuesta = false;

            if (lista == empleado)
            {
                lista.listaDeEmpleados.Remove(empleado);
                respuesta = true;
            }
            return respuesta;
        }

        public static bool operator ==(ListadoEmpleados<T> lista, T empleado)
        {
            bool respuesta = false;

            if (lista.listaDeEmpleados.Contains(empleado))
            {
                respuesta = true;
            }

            return respuesta;
        }

        public static bool operator !=(ListadoEmpleados<T> lista, T empleado)
        {
            return !(lista == empleado);
        }
    }
}
