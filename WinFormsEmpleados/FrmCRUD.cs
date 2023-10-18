using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrimerParcial;
using System;
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

            while (true)
            {
                formEmpleado.ShowDialog();

                if (formEmpleado.DialogResult == DialogResult.OK)
                {
                    if (this.AgregarEmpleado(formEmpleado.NuevoEmpleado))
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// AgregarEmpleado() Comprueba que el empleado no exista ya en la lista, y de ser así, lo agrega, caso contrario muestra
        /// un cartel informando que se encontró una coincidencia.
        /// </summary>
        /// <param name="empleadoParaAgregar">Empleado que se desea agregar a al lista</param>
        private bool AgregarEmpleado(Empleado empleadoParaAgregar)
        {
            bool respuesta = this.empleadosActuales + empleadoParaAgregar;

            if (respuesta)
            {
                this.ActualizarLista();
            }
            else
            {
                MessageBox.Show("El empleado que intentó ingresar ya existe en la lista de empleados.", "No se agregó el empleado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return respuesta;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = this.lstEmpleados.SelectedIndex;

            if (indice == -1)
            {
                return;
            }

            Empleado empleadoAEliminar = this.empleadosActuales.listaDeEmpleados[indice];
            bool eliminado = this.empleadosActuales - empleadoAEliminar;

            if (eliminado)
            {
                this.ActualizarLista();
            }

        }

        /// <summary>
        /// btnModificar_Click() toma el item seleccionado y crea una instancia de un formulario de creación tomando los datos
        /// del empleado y volcandolos sobre él. Dependiendo del tipo de empleado crea un formulario diferente según sus especificaciones
        /// .
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

            while (true)
            {
                frmEmpleadoSeleccionado.ShowDialog();

                if (frmEmpleadoSeleccionado.DialogResult == DialogResult.OK)
                {
                    bool coincidencia = false;

                    coincidencia = ListadoEmpleados.ComprobarCoindicencia(this.empleadosActuales, frmEmpleadoSeleccionado.NuevoEmpleado, indice);

                    if (coincidencia)
                    {
                        MessageBox.Show("Los datos ingresados coinciden con los que ya tiene un empleado, vuelvalo a intentar.", "Error al modificar al empleado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.empleadosActuales.listaDeEmpleados[indice] = frmEmpleadoSeleccionado.NuevoEmpleado;
                        this.ActualizarLista();
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// FrmCRUD_Load() Guarda la información del usuario logeado a la vez que sube un archivo .json (si existe) y carga su contenido
        /// en una lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            string path = @"..\..\..\";
            this.GuardarLogUsuarios(path);
            path += @"\Listado_Empleados.json";

            this.DeserializarJson(path);
        }

        private void DeserializarJson(string path)
        {
            if (File.Exists(path))
            {
                this.empleadosActuales.listaDeEmpleados.Clear();
                string json = File.ReadAllText(path);
                List<JObject> listaObjetos = JsonConvert.DeserializeObject<List<JObject>>(json);

                foreach (var empleado in listaObjetos)
                {
                    if (empleado["ZonaDeAtencion"] != null)
                    {
                        Mesero mesero = empleado.ToObject<Mesero>();
                        this.empleadosActuales.listaDeEmpleados.Add(mesero);
                    }
                    else if (empleado["Especialidad"] != null)
                    {
                        Cocinero cocinero = empleado.ToObject<Cocinero>();
                        this.empleadosActuales.listaDeEmpleados.Add(cocinero);
                    }
                    else if (empleado["CajaAsignada"] != null)
                    {
                        Cajero cajero = empleado.ToObject<Cajero>();
                        this.empleadosActuales.listaDeEmpleados.Add(cajero);
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
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Confirmación de cierre", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }

            string path = @"..\..\..\Listado_Empleados.json";
            this.SerializarJson(path);
        }

        private void SerializarJson(string path)
        {
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
            string titulo = $"Información particular de {empleadoSeleccionado.Nombre}";
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

        private void btnVerRegistrosUsuarios_Click(object sender, EventArgs e)
        {
            FrmRegistroUsuarios formHistorialUsuarios = new FrmRegistroUsuarios();
            formHistorialUsuarios.ShowDialog();
        }

        private void btnGuardarEmpleados_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardarEmpleadosDialog = new SaveFileDialog();
            guardarEmpleadosDialog.Filter = "Json files(*.json)|*.json";

            if (guardarEmpleadosDialog.ShowDialog() == DialogResult.OK)
            {
                string path = guardarEmpleadosDialog.FileName;
                this.SerializarJson(path);
            }
        }

        private void btnCargarEmpleados_Click(object sender, EventArgs e)
        {
            OpenFileDialog cargarEmpleadosDialog = new OpenFileDialog();
            cargarEmpleadosDialog.Filter = "Json files(*.json)|*.json";

            if (cargarEmpleadosDialog.ShowDialog() == DialogResult.OK)
            {
                string path = cargarEmpleadosDialog.FileName;
                this.DeserializarJson(path);
            }
        }
    }
}