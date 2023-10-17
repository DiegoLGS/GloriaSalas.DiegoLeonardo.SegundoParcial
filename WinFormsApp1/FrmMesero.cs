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
        private Mesero nuevoEmpleado;

        public FrmMesero()
        {
            InitializeComponent();
        }

        public FrmMesero(Mesero meseroAModificar) : this()
        {
            base.EstablecerCamposComunes(meseroAModificar);
            this.EstablecerZonaAtencion(meseroAModificar.ZonaDeAtencion);
            this.txtNumeroDeMesas.Text = meseroAModificar.NumeroDeMesas.ToString();
        }

        public override Mesero NuevoEmpleado { get { return this.nuevoEmpleado; } }

        private void btnAceptar_ClickMesero(object sender, EventArgs e)
        {
            if (base.ComprobarCamposFormulario() && base.ComprobarValoresNumericos(this.txtNumeroDeMesas.Text))
            {
                ETurnos turnoElegido = base.ObtenerTurnoTrabajo();
                string zonaDeTrabajo = this.ObtenerZonaAtencion();

                this.nuevoEmpleado = new Mesero(base.txtNombre.Text, int.Parse(base.txtLegajo.Text), turnoElegido, zonaDeTrabajo, int.Parse(this.txtNumeroDeMesas.Text));
                this.DialogResult = DialogResult.OK;                
            }
            else
            {
                MessageBox.Show("Verifique que los campos no esten vacíos y los datos ingresados sean los correctos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ObtenerZonaAtencion()
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
