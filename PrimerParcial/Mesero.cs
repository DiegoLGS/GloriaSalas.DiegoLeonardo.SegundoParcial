using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class Mesero : Empleado
    {
        public Mesero(string nombre, int legajo, int antiguedad):base(nombre, legajo, antiguedad)
        {
        }
        protected override void CambiarHorasExtras()
        {
            this.disponibleHorasExtras = !this.disponibleHorasExtras;
            Console.WriteLine("Disponibilidad para hacer horas extras cambiada");
        }
    }
}
