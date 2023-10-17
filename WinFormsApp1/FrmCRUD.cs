using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
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

        private void ActualizarLista()
        {
            this.lstEmpleados.Items.Clear();

            if (this.empleadosActuales.listaDeEmpleados != null && this.empleadosActuales.listaDeEmpleados.Any())
            {
                foreach (Empleado empleado in this.empleadosActuales.listaDeEmpleados)
                {
                    lstEmpleados.Items.Add(empleado.ToString());
                }
            }
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            FrmEmpleado formEmpleado;

            if (sender == this.btnAgregarMesero)
            {
                formEmpleado = new FrmMesero();
            }
            else if (sender == this.btnAgregarCocinero)
            {
                formEmpleado = new FrmCocinero();
            }
            else
            {
                formEmpleado = new FrmCajero();
            }

            if (formEmpleado != null && formEmpleado.ShowDialog() == DialogResult.OK)
            {
                AgregarEmpleado(formEmpleado.NuevoEmpleado);
            }
        }

        private void AgregarEmpleado(Empleado empleadoAgregado)
        {
            bool respuesta = this.empleadosActuales + empleadoAgregado;

            if(respuesta)
            {
                this.ActualizarLista();
            }
            else
            {
                MessageBox.Show("El empleado que intent� ingresar ya existe en la lista de empleados.", "No se agreg� el empleado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        /// <summary>
        /// btnModificar_Click() toma el item seleccionado (empleado) y crea una instancia de un formulario de creaci�n tomando los datos
        /// del empleado y volcandolos sobre �l. Dependiendo del tipo de empleado crea un formulario diferente seg�n sus especificaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// FrmCRUD_Load() Guarda la informaci�n del usuario logeado a la vez que sube un archivo .json (si existe) y carga su contenido
        /// en una lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            GuardarLogUsuarios(path);
            path += @"\Listado_Empleados.json";

            if (File.Exists(path))
            {               
                string json = File.ReadAllText(path);
                List<object> listaObjetos = JsonConvert.DeserializeObject<List<object>>(json);

                foreach (var empleado in listaObjetos)
                {
                    if (empleado.ToString().Contains("ZonaDeAtencion"))
                    {
                        Mesero nuevoEmpleado = JsonConvert.DeserializeObject<Mesero>(empleado.ToString());
                        this.empleadosActuales.listaDeEmpleados.Add(nuevoEmpleado);
                    }
                    else if (empleado.ToString().Contains("Especialidad"))
                    {
                        Cocinero nuevoEmpleado = JsonConvert.DeserializeObject<Cocinero>(empleado.ToString());
                        this.empleadosActuales.listaDeEmpleados.Add(nuevoEmpleado);
                    }
                    else
                    {
                        Cajero nuevoEmpleado = JsonConvert.DeserializeObject<Cajero>(empleado.ToString());
                        this.empleadosActuales.listaDeEmpleados.Add(nuevoEmpleado);
                    }
                }
                
                this.ActualizarLista();
            }
        }


        /// <summary>
        /// FrmCRUD_FormClosing() guarda la lista de empleados en un .json para mantener su almacenamiento fuera del funcionamiento del programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("�Desea salir de la aplicaci�n?", "Confirmaci�n de cierre", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true; 
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Listado_Empleados.json";

            string json = JsonConvert.SerializeObject(this.empleadosActuales.listaDeEmpleados, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private void GuardarLogUsuarios(string path)
        {
            path += @"\Usuarios_logeados.log";

            using (StreamWriter sw = File.AppendText(path))
            {
                string usuarioYHora = this.usuarioLogeado.ObtenerDatosLog();

                sw.Write(usuarioYHora);
            }
        }

        private void btnInformacionDetallada_Click(object sender, EventArgs e)
        {
            int indice = this.lstEmpleados.SelectedIndex;

            if (indice == -1)
            {
                return;
            }

            Empleado empleadoSeleccionado = this.empleadosActuales.listaDeEmpleados[indice];
            string titulo = $"Informaci�n particular de {empleadoSeleccionado.Nombre}";
            MessageBox.Show(empleadoSeleccionado.MostrarDatos(titulo), "Informacion detallada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOrdenarLista_Click(object sender, EventArgs e)
        {
            if (this.rdoPorNombre.Checked)
            {
                this.empleadosActuales.OrdenarLista("nombre", rdoAscendente.Checked);
            }
            else
            {
                this.empleadosActuales.OrdenarLista("legajo", rdoAscendente.Checked);
            }

            this.ActualizarLista();
        }


        /// <summary>
        /// btnCambiarHorasExtra_Click() alterna el booleano del empleado seleccionado a la vez que genera un texto informativo del estado nuevo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCambiarHorasExtra_Click(object sender, EventArgs e)
        {
            int indice = this.lstEmpleados.SelectedIndex;

            if (indice == -1)
            {
                return;
            }
            string estadoHorasExtras;
            Empleado empleadoSeleccionado = this.empleadosActuales.listaDeEmpleados[indice];
            empleadoSeleccionado.CambiarDisponibilidadHorasExtras();
            estadoHorasExtras = empleadoSeleccionado.DisponibleHorasExtras ? "Disponible para realizar horas extras." : "No disponible para realizar horas extras.";
            MessageBox.Show($"{empleadoSeleccionado.Nombre}: {estadoHorasExtras}", "Cambio de horas extras", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}