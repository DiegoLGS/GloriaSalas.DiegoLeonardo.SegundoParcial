using PrimerParcial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// ComprobarCamposFormulario() revisa que los TextBox no estén vacíos y llama a la función ComprobarValoresNumericos
        /// para revisar los datos que deben ser únicamente números.
        /// </summary>
        /// <returns></returns>
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

            datosCargados = ComprobarValoresNumericos(this.txtLegajo.Text);

            return datosCargados;
        }

        protected bool ComprobarValoresNumericos(string texto)
        {
            return Regex.IsMatch(texto, @"^[0-9]+$");
        }       

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        /// <summary>
        /// EstablecerCamposComunes() recibe un parametro del tipo Empleado para tomar y plasmar los datos que se tiene con común
        /// con todos los tipos de empleados en el formulario.
        /// </summary>
        /// <param name="empleado">variable a la que se tomará sus datos.</param>
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
