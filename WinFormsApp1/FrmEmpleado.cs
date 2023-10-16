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
        protected Dictionary<ETurnos, RadioButton> radioButtons;

        public FrmEmpleado()
        {
            InitializeComponent();
            radioButtons = new Dictionary<ETurnos, RadioButton>
            {
                { ETurnos.MañanaPartTime, this.rdoMañanaPartTime },
                { ETurnos.MañanaFullTime, this.rdoMañanaFullTime },
                { ETurnos.TardePartTime, this.rdoTardePartTime },
                { ETurnos.TardeFullTime, this.rdoTardeFullTime },
                { ETurnos.NochePartTime, this.rdoNochePartTime }
            };
        }

        public virtual Empleado NuevoEmpleado { get; }

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

            foreach (var par in this.radioButtons)
            {
                if (par.Value.Checked)
                {
                    turnoElegido = par.Key;
                    break;
                }
            }

            return turnoElegido;
        }

        protected void EstablecerCamposComunes(Empleado empleado)
        {
            this.txtNombre.Text = empleado.Nombre;
            this.txtLegajo.Text = empleado.Legajo.ToString();            

            foreach (var par in this.radioButtons)
            {
                if (par.Key == empleado.TurnoDeTrabajo)
                {
                    par.Value.Checked = true;
                    break;
                }
            }
        }
    }
}
