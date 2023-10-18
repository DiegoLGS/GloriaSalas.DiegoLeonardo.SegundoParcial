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
    public partial class FrmCajero : FrmEmpleado
    {
        private Cajero nuevoEmpleado;

        public FrmCajero()
        {
            InitializeComponent();
        }

        public FrmCajero(Cajero cajeroAModificar) : this()
        {
            base.EstablecerCamposComunes(cajeroAModificar);
            this.txtPropina.Text = cajeroAModificar.PropinaActual.ToString();
            this.EstablecerCaja(cajeroAModificar.CajaAsignada);
        }

        public override Cajero NuevoEmpleado { get { return this.nuevoEmpleado; } }

        private void btnAceptar_ClickCajero(object sender, EventArgs e)
        {
            if (base.ComprobarCamposFormulario() && base.ComprobarValoresNumericos(this.txtPropina.Text, 6))
            {
                ETurnos turnoElegido = base.ObtenerTurnoTrabajo();
                int cajaAsignada = this.ObtenerCaja();

                this.nuevoEmpleado = new Cajero(base.txtNombre.Text, int.Parse(base.txtLegajo.Text), turnoElegido, int.Parse(this.txtPropina.Text), cajaAsignada);
                this.DialogResult = DialogResult.OK;
            }
        }

        private int ObtenerCaja()
        {
            int numeroCaja = this.rdoCajaUno.Checked ? numeroCaja = 1 : numeroCaja = 2;

            return numeroCaja;
        }

        private void EstablecerCaja(int cajaAsignada)
        {
            _ = cajaAsignada == 1 ? this.rdoCajaUno.Checked = true : this.rdoCajaDos.Checked = true;
        }

    }
}
