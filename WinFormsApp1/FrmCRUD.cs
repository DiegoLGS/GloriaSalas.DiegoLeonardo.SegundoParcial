using PrimerParcial;
using System.Text.Json;
using WinFormsEmpleados;

namespace WinFormsApp1
{
    public partial class FrmCRUD : Form
    {
        private ListadoEmpleados empleadosActuales;
        private Usuario usuarioLogeado;

        public FrmCRUD(Usuario usuarioLogeado)
        {
            InitializeComponent();
            this.empleadosActuales = new ListadoEmpleados();
            this.usuarioLogeado = usuarioLogeado;
            this.lblUsuario.Text = this.usuarioLogeado.ToString();

        }

        public List<Empleado> EmpleadosActuales
        {
            get { return this.empleadosActuales.listaDeEmpleados; }
            set { empleadosActuales.listaDeEmpleados = value; }
        }

        private void ActualizarLista()
        {
            this.lstEmpleados.Items.Clear();

            foreach (Empleado empleado in this.empleadosActuales.listaDeEmpleados)
            {
                lstEmpleados.Items.Add(empleado.ToString());
            }
        }

        private void btnAgregarMesero_Click(object sender, EventArgs e)
        {
            FrmMesero formMesero = new FrmMesero();

            if (formMesero.ShowDialog() == DialogResult.OK)
            {
                AgregarEmpleado(formMesero.NuevoEmpleado);
            }
        }

        private void btnAgregarCocinero_Click(object sender, EventArgs e)
        {
            FrmCocinero formCocinero = new FrmCocinero();

            if (formCocinero.ShowDialog() == DialogResult.OK)
            {
                AgregarEmpleado(formCocinero.NuevoEmpleado);
            }
        }

        private void btnAgregarCajero_Click(object sender, EventArgs e)
        {
            FrmCajero formCajero = new FrmCajero();

            if (formCajero.ShowDialog() == DialogResult.OK)
            {
                AgregarEmpleado(formCajero.NuevoEmpleado);
            }
        }

        private void AgregarEmpleado(Empleado empleadoAgregado)
        {
            _ = this.empleadosActuales + empleadoAgregado;
            this.ActualizarLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = this.lstEmpleados.SelectedIndex;

            if (indice == -1)
            {
                return;
            }

            this.empleadosActuales.listaDeEmpleados.RemoveAt(indice);
            this.ActualizarLista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = this.lstEmpleados.SelectedIndex;

            if (indice == -1)
            {
                return;
            }

            Empleado empleadoSeleccionado = this.empleadosActuales.listaDeEmpleados[indice];
            FrmEmpleado frmEmpleadoSeleccionado;

            if (empleadoSeleccionado is Mesero)
            {
                frmEmpleadoSeleccionado = new FrmMesero((Mesero)empleadoSeleccionado);
            }
            else if (empleadoSeleccionado is Cocinero)
            {
                frmEmpleadoSeleccionado = new FrmCocinero((Cocinero)empleadoSeleccionado);
            }
            else
            {
                frmEmpleadoSeleccionado = new FrmCajero((Cajero)empleadoSeleccionado);
            }

            frmEmpleadoSeleccionado.ShowDialog();

            if (frmEmpleadoSeleccionado.DialogResult == DialogResult.OK)
            {
                this.empleadosActuales.listaDeEmpleados[indice] = frmEmpleadoSeleccionado.NuevoEmpleado;
                this.ActualizarLista();
            }
        }

        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            List<Empleado> listaEmpleadosJson;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Listado_Empleados.json";

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json_str = sr.ReadToEnd();

                    listaEmpleadosJson = (List<Empleado>)JsonSerializer.Deserialize(json_str, typeof(List<Empleado>));
                }

                foreach (Empleado empleado in listaEmpleadosJson)
                {
                    this.empleadosActuales.listaDeEmpleados.Add(empleado);
                }

                this.ActualizarLista();
            }
        }

        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Listado_Empleados.json";

            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;

            string objJson = JsonSerializer.Serialize(this.empleadosActuales.listaDeEmpleados, opciones);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }

        private void btnInformacionDetallada_Click(object sender, EventArgs e)
        {
            int indice = this.lstEmpleados.SelectedIndex;

            if (indice == -1)
            {
                return;
            }

            string titulo = "Información detallada:";
            Empleado empleadoSeleccionado = this.empleadosActuales.listaDeEmpleados[indice];
            MessageBox.Show(empleadoSeleccionado.MostrarDatos(titulo), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOrdenarLista_Click(object sender, EventArgs e)
        {
            if(this.rdoPorNombre.Checked)
            {
                this.empleadosActuales.OrdenarLista("nombre", rdoAscendente.Checked);
            }
            else
            {
                this.empleadosActuales.OrdenarLista("legajo", rdoAscendente.Checked);
            }

            this.ActualizarLista();
        }
    }
}