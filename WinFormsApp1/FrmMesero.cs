using PrimerParcial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsEmpleados
{
    public partial class FrmMesero : FrmEmpleado
    {
        private Mesero nuevoMesero;

        public FrmMesero()
        {
            InitializeComponent();
        }

        public FrmMesero(Mesero meseroAModificar):this()
        {
            this.txtNombre.Text = meseroAModificar.Nombre;
            this.txtLegajo.Text = meseroAModificar.Legajo.ToString();
            base.EstablecerTurnoTrabajo(meseroAModificar.TurnoDeTrabajo);
            this.EstablecerZonaAtencion(meseroAModificar.ZonaDeAtencion);
            this.txtNumeroDeMesas.Text = meseroAModificar.NumeroDeMesas.ToString();            
        }

        public Mesero NuevoMesero { get { return this.nuevoMesero; } }

        private void btnAceptar_ClickMesero(object sender, EventArgs e)
        {
            if (base.ComprobarCamposFormulario())
            {
                ETurnos turnoElegido = base.ObtenerTurnoTrabajo();
                string zonaDeTrabajo = this.ObtenerZonaTrabajo();

                this.nuevoMesero = new Mesero(base.txtNombre.Text, int.Parse(base.txtLegajo.Text), turnoElegido, zonaDeTrabajo, int.Parse(this.txtNumeroDeMesas.Text));
                this.DialogResult = DialogResult.OK;
            }
        }

        private string ObtenerZonaTrabajo()
        {
            string zonaDeTrabajo;

            if (this.rdoPrincipal.Checked)
            {
                zonaDeTrabajo = "Principal";
            }
            else if (this.rdoPatio.Checked)
            {
                zonaDeTrabajo = "Patio";
            }
            else
            {
                zonaDeTrabajo = "Segundo Piso";
            }

            return zonaDeTrabajo;
        }

        private void EstablecerZonaAtencion(string meseroZonaAtencion)
        {
            if (meseroZonaAtencion == "Principal")
            {
                this.rdoPrincipal.Checked = true;
            }
            else if (meseroZonaAtencion == "Patio")
            {
                this.rdoPatio.Checked = true;
            }
            else
            {
                this.rdoSegundoPiso.Checked = true;
            }
        }
    }
}
