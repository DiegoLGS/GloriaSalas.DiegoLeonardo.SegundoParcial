using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class ListaUsuariosNoCargadaException : Exception
    {
        public ListaUsuariosNoCargadaException():base("La lista de usuarios no se ha cargado correctamente. Contáctese con un administrador.") { }

        public ListaUsuariosNoCargadaException(string mensaje):base(mensaje)
        {
        }
    }

}
