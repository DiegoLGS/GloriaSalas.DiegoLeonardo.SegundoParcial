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

        public FrmCocinero(Cocinero cocineroAModificar):this()
        {            
            base.EstablecerCamposComunes(cocineroAModificar);
            this.EstablecerEspecialidades(cocineroAModificar.Especialidad);
            this.txtCertificacion.Text = cocineroAModificar.Certificacion;
        }

        public Cocinero NuevoCocinero { get { return this.nuevoEmpleado; } }

        private void btnAceptar_ClickCocinero(object sender, EventArgs e)
        {
            if (base.ComprobarCamposFormulario())
            {
                ETurnos turnoElegido = base.ObtenerTurnoTrabajo();
                string especialidades = this.ObtenerEspecialidades();

                this.nuevoEmpleado = new Cocinero(base.txtNombre.Text, int.Parse(base.txtLegajo.Text), turnoElegido, especialidades, this.txtCertificacion.Text);
                this.DialogResult = DialogResult.OK;
            }
        }

        protected string ObtenerEspecialidades()
        {
            string especialidadesSeleccionadas = "";

            foreach (var par in this.especialidadesCheckBoxs)
            {
                if (par.Value.Checked)
                {
                    especialidadesSeleccionadas += par.Key + "\n";
                }
            }

            return especialidadesSeleccionadas;
        }


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
