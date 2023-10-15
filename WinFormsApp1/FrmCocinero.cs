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
    public partial class FrmCocinero : FrmEmpleado
    {
        private Cocinero nuevoCocinero;

        public FrmCocinero()
        {
            InitializeComponent();
        }

        public Cocinero NuevoCocinero { get { return this.nuevoCocinero; } }

        private void btnAceptar_ClickMesero(object sender, EventArgs e)
        {
            if (base.ComprobarCamposFormulario())
            {
                ETurnos turnoElegido = base.ObtenerTurnoTrabajo();
                string especialidades = this.ObtenerEspecialidades();

                this.nuevoCocinero = new Cocinero(base.txtNombre.Text, int.Parse(base.txtLegajo.Text), turnoElegido, especialidades, this.txtCertificacion.Text);
                this.DialogResult = DialogResult.OK;
            }
        }

        protected string ObtenerEspecialidades()
        {
            Dictionary<CheckBox, string> checkBoxes = new Dictionary<CheckBox, string>
            {
                { this.cbReposteria, "Reposteria" },
                { this.cbParrilla, "Parrilla" },
                { this.cbGourmet, "Gourmet" },
                { this.cbVegana, "Vegana" },
                { this.cbPastas, "Pastas" },
                { this.cbPescados, "Pescados" }
            };

            string especialidadesSeleccionadas = "";

            foreach (var par in checkBoxes)
            {
                if (par.Key.Checked)
                {
                    especialidadesSeleccionadas += par.Value + "\n";
                }
            }

            return especialidadesSeleccionadas;
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
