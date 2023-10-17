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
        private Cocinero nuevoEmpleado;
        private Dictionary<string, CheckBox> especialidadesCheckBoxs;

        public FrmCocinero()
        {
            InitializeComponent();
            especialidadesCheckBoxs = new Dictionary<string, CheckBox>
            {
                { "Reposteria", this.cbReposteria },
                { "Parrilla", this.cbParrilla },
                { "Gourmet", this.cbGourmet },
                { "Vegana", this.cbVegana },
                { "Pastas", this.cbPastas },
                { "Pescados", this.cbPescados }
            };
        }

        public override Cocinero NuevoEmpleado { get { return this.nuevoEmpleado; } }

        public FrmCocinero(Cocinero cocineroAModificar) : this()
        {
            base.EstablecerCamposComunes(cocineroAModificar);
            this.EstablecerEspecialidades(cocineroAModificar.Especialidad);
            this.txtCertificacion.Text = cocineroAModificar.Certificacion;
        }

        private void btnAceptar_ClickCocinero(object sender, EventArgs e)
        {
            if (base.ComprobarCamposFormulario())
            {
                ETurnos turnoElegido = base.ObtenerTurnoTrabajo();
                string especialidades = this.ObtenerEspecialidades();

                this.nuevoEmpleado = new Cocinero(base.txtNombre.Text, int.Parse(base.txtLegajo.Text), turnoElegido, especialidades, this.txtCertificacion.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Verifique que los campos no esten vacíos y los datos ingresados sean los correctos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ObtenerEspecialidades() itera sobre el diccionario que relaciona las especialidades del cocinero con los Checkboxs correspondientes
        /// </summary>
        /// <returns>Regresa un string con todas las especialidades marcadas</returns>
        protected string ObtenerEspecialidades()
        {
            string especialidadesSeleccionadas = "";

            foreach (var par in this.especialidadesCheckBoxs)
            {
                if (par.Value.Checked)
                {
                    especialidadesSeleccionadas += "\n" + par.Key;
                }
            }

            return especialidadesSeleccionadas;
        }

        /// <summary>
        /// EstablecerEspecialidades() itera sobre el diccionario que relaciona las especialidades del cocinero con los Checkboxs correspondientes
        /// y marca los que han sido asignados al Cocinero.
        /// </summary>
        /// <param name="especialidades">Recibe la cadena completa de especialidades</param>
        private void EstablecerEspecialidades(string especialidades)
        {
            string[] lineas = especialidades.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string linea in lineas)
            {
                if (this.especialidadesCheckBoxs.ContainsKey(linea))
                {
                    this.especialidadesCheckBoxs[linea].Checked = true;
                }
            }
        }

    }
}
