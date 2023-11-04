using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class ListaUsuariosNoCargadaException : Exception
    {        
        public ListaUsuariosNoCargadaException(string mensaje)
        : base(mensaje) { }
    }

}
