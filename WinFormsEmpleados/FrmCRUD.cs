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
        private ListadoEmpleados<Empleado> empleadosActuales;
        private AdministradorBD miAdminBD = new AdministradorBD();
        private Func<string> delegadoObtenerNombreYFecha;
        private Func<string> delegadoObtenerDatosLog;        

        public FrmCRUD(Func<string> delegadoObtenerNombreYFecha, Func<string> obtenerDatosLog, string perfilUsuario)
        {
            InitializeComponent();
            this.empleadosActuales = new ListadoEmpleados<Empleado>();
            this.delegadoObtenerNombreYFecha = delegadoObtenerNombreYFecha;
            this.delegadoObtenerDatosLog = obtenerDatosLog;
            this.lblUsuario.Text = this.delegadoObtenerNombreYFecha.Invoke();
            this.AdministrarPermisosUsuario(perfilUsuario);
        }

        private void AdministrarPermisosUsuario(string perfilUsuario)
        {
            if (perfilUsuario != "administrador")
            {
                this.btnEliminar.Enabled = false;

                if (perfilUsuario != "supervisor")
                {
                    this.btnGuardarEmpleados.Enabled = false;
                    this.btnCargarEmpleados.Enabled = false;
                    this.rdoPorNombre.Enabled = false;
                    this.rdoPorLegajo.Enabled = false;
                    this.rdoAscendente.Enabled = false;
                    this.rdoDescendente.Enabled = false;

                    foreach (Control control in this.Controls)
                    {
                        if (control is Button)
                        {
                            Button boton = (Button)control;

                            if (boton != this.btnVerRegistrosUsuarios && boton != this.btnInformacionDetallada)
                            {
                                boton.Enabled = false;
                            }
                        }
                    }
                }
            }
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
                    if (this.AgregarEmpleado(formEmpleado.NuevoEmpleado, formEmpleado))
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
        private bool AgregarEmpleado(Empleado empleadoParaAgregar, FrmEmpleado formEmpleado)
        {
            bool respuesta = this.empleadosActuales + empleadoParaAgregar;

            if (respuesta)
            {
                this.ActualizarLista();
                if (formEmpleado is FrmMesero)
                {
                    miAdminBD.AgregarEmpleadoBD((Mesero)empleadoParaAgregar);
                }
                else if (formEmpleado is FrmCocinero)
                {
                    miAdminBD.AgregarEmpleadoBD((Cocinero)empleadoParaAgregar);
                }
                else
                {
                    miAdminBD.AgregarEmpleadoBD((Cajero)empleadoParaAgregar);
                }
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

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar a este empleado?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool eliminado = this.empleadosActuales - empleadoAEliminar;
                string tabla = (empleadoAEliminar is Mesero) ? "meseros" : (empleadoAEliminar is Cocinero) ? "cocineros" : "cajeros";
                _ = miAdminBD.EliminarEmpleadoPorLegajo(empleadoAEliminar.Legajo, tabla);

                if (eliminado)
                {
                    this.ActualizarLista();
                }
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
                    bool coincidencia;

                    coincidencia = ListadoEmpleados<Empleado>.ComprobarCoindicencia(this.empleadosActuales, frmEmpleadoSeleccionado.NuevoEmpleado, indice);

                    if (coincidencia)
                    {
                        MessageBox.Show("Los datos ingresados coinciden con los que ya tiene un empleado, vuelvalo a intentar.", "Error al modificar al empleado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int legajoOriginal = this.empleadosActuales.listaDeEmpleados[indice].Legajo;
                        this.empleadosActuales.listaDeEmpleados[indice] = frmEmpleadoSeleccionado.NuevoEmpleado;
                        miAdminBD.ModificarEmpleadoPorLegajo(frmEmpleadoSeleccionado.NuevoEmpleado, legajoOriginal);
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
        /// FrmCRUD_Load() Guarda la información del usuario logeado a la vez que carga los empleados guardados en la base de datos.
        /// en una lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            string path = @"..\..\..\";
            this.GuardarLogUsuarios(path);

            this.empleadosActuales.listaDeEmpleados = miAdminBD.ObtenerListaEmpleados();
            this.ActualizarLista();
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
        
        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Confirmación de cierre", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
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
                string usuarioYHora = this.delegadoObtenerDatosLog.Invoke();

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
            miAdminBD.ModificarEmpleadoPorLegajo(empleadoSeleccionado, empleadoSeleccionado.Legajo);
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