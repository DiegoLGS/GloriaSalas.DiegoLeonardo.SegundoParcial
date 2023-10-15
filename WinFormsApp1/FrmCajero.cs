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
        private Cajero nuevoCajero;

        public FrmCajero()
        {
            InitializeComponent();
        }

        public Cajero NuevoCajero { get { return this.nuevoCajero; } }

        private void btnAceptar_ClickMesero(object sender, EventArgs e)
        {
            if (base.ComprobarCamposFormulario())
            {
                ETurnos turnoElegido = base.ObtenerTurnoTrabajo();
                int cajaAsignada = this.ObtenerCaja();

                this.nuevoCajero = new Cajero(base.txtNombre.Text, int.Parse(base.txtLegajo.Text), turnoElegido, int.Parse(this.txtPropina.Text), cajaAsignada);
                this.DialogResult = DialogResult.OK;
            }
        }

        private int ObtenerCaja()
        {
            int numeroCaja = this.rdoCajaUno.Checked ? numeroCaja = 1 : numeroCaja = 2;

            return numeroCaja;
        }
    }
}
