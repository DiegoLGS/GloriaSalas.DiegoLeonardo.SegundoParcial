using PrimerParcial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsEmpleados
{
    public delegate void LoginFalladoEventHandler(int intentos, Form formulario);

    public partial class FrmLogin : Form
    {
        private List<Usuario> listaUsuarios;
        private Usuario usuarioLogeado;
        public event LoginFalladoEventHandler LoginFallado;
        private int numeroIntento;

        public Usuario UsuarioLogeado
        {
            get { return this.usuarioLogeado; }
            set { this.usuarioLogeado = value; }
        }

        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.numeroIntento = 0;
            this.listaUsuarios = AdministradorJson.CargarUsuarios(@"..\..\..\MOCK_DATA.json");
            this.LoginFallado += AdministradorJson.IntentosLogin;
        }        

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listaUsuarios == null)
                {
                    throw new ListaUsuariosNoCargadaException("\nLa lista de usuarios no se ha cargado correctamente. Contáctese con un administrador.");
                }

                Usuario usuarioNuevo = null;

                foreach (Usuario usuario in this.listaUsuarios)
                {
                    if (this.txtCorreo.Text == usuario.correo && this.txtPassword.Text == usuario.clave)
                    {
                        usuarioNuevo = usuario;
                        break;
                    }
                }

                if (usuarioNuevo != null)
                {
                    this.UsuarioLogeado = usuarioNuevo;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.numeroIntento++;
                    this.LoginFallado.Invoke(this.numeroIntento, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }            
        }

        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
