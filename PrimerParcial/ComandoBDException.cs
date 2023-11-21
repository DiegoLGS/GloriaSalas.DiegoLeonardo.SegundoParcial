using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class ComandoBDException : Exception
    {
        public ComandoBDException() : base("La ejecución del comando no afectó el número esperado de filas en la base de datos.") { }

        public ComandoBDException(string mensaje):base(mensaje)
        {
        }
    }
}
