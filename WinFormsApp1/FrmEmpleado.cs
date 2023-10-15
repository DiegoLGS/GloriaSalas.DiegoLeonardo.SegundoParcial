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
    public partial class FrmEmpleado : Form
    {

        public FrmEmpleado()
        {
            InitializeComponent();
        }

        protected bool ComprobarCamposFormulario()
        {
            bool datosCargados = true;

            foreach (Control item in this.Controls)
            {
                if (item is TextBox & item.Text == String.Empty)
                {
                    datosCargados = false;
                    break;
                }
            }
            return datosCargados;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ComprobarCamposFormulario())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected ETurnos ObtenerTurnoTrabajo()
        {
            ETurnos turnoElegido = ETurnos.MañanaPartTime;
            Dictionary<RadioButton, ETurnos> radioButtons = new Dictionary<RadioButton, ETurnos>
            {
                { this.rdoMañanaPartTime, ETurnos.MañanaPartTime },
                { this.rdoMañanaFullTime, ETurnos.MañanaFullTime },
                { this.rdoTardePartTime, ETurnos.TardePartTime },
                { this.rdoTardeFullTime, ETurnos.TardeFullTime },
                { this.rdoNochePartTime, ETurnos.NochePartTime }
            };

            foreach (var par in radioButtons)
            {
                if (par.Key.Checked)
                {
                    turnoElegido = par.Value;
                    break;
                }
            }

            return turnoElegido;
        }

        protected void EstablecerTurnoTrabajo(ETurnos turno)
        {
            Dictionary<ETurnos, RadioButton> radioButtons = new Dictionary<ETurnos, RadioButton>
            {
                { ETurnos.MañanaPartTime, this.rdoMañanaPartTime },
                { ETurnos.MañanaFullTime, this.rdoMañanaFullTime },
                { ETurnos.TardePartTime, this.rdoTardePartTime },
                { ETurnos.TardeFullTime, this.rdoTardeFullTime },
                { ETurnos.NochePartTime, this.rdoNochePartTime }
            };

            foreach (var par in radioButtons)
            {
                if (par.Key == turno)
                {
                    par.Value.Checked = true;
                }
            }
        }
    }
}
