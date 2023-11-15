using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public interface IGuardarArchivo<T>
    {
        void GuardarArchivo(string path, T datos);
    }
}
