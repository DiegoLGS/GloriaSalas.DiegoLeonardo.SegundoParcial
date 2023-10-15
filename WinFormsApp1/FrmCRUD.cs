using PrimerParcial;
using WinFormsEmpleados;

namespace WinFormsApp1
{
    public partial class FrmCRUD : Form
    {
        private ListadoEmpleados empleadosActuales;

        public FrmCRUD()
        {
            InitializeComponent();
            this.empleadosActuales = new ListadoEmpleados();
        }

        private void ActualizarLista()
        {
            this.lstEmpleados.Items.Clear();

            foreach (Empleado empleado in this.empleadosActuales.listaDeEmpleados)
            {
                lstEmpleados.Items.Add($"{empleado.Nombre} - {empleado.Legajo} - {empleado.TurnoDeTrabajo}");
            }
        }

        private void btnAgregarMesero_Click(object sender, EventArgs e)
        {
            FrmMesero formMesero = new FrmMesero();

            if (formMesero.ShowDialog() == DialogResult.OK)
            {
                AgregarEmpleado(formMesero.NuevoMesero);
            }
        }

        private void btnAgregarCocinero_Click(object sender, EventArgs e)
        {
            FrmCocinero formCocinero = new FrmCocinero();

            if (formCocinero.ShowDialog() == DialogResult.OK)
            {
                AgregarEmpleado(formCocinero.NuevoCocinero);
            }
        }

        private void btnAgregarCajero_Click(object sender, EventArgs e)
        {
            FrmCajero formCajero = new FrmCajero();

            if (formCajero.ShowDialog() == DialogResult.OK)
            {
                AgregarEmpleado(formCajero.NuevoCajero);
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

            if(empleadoSeleccionado is Mesero)
            {
                FrmMesero frmEmpleadoSeleccionado = new FrmMesero((Mesero)empleadoSeleccionado);
                frmEmpleadoSeleccionado.ShowDialog();
                if (frmEmpleadoSeleccionado.DialogResult == DialogResult.OK)
                {
                    this.empleadosActuales.listaDeEmpleados[indice] = frmEmpleadoSeleccionado.NuevoMesero;
                    this.ActualizarLista();
                }
            }


        }
    }
}