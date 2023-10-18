using PrimerParcial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsEmpleados
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> listaUsuarios;
        private Usuario usuarioLogeado;

        public Usuario UsuarioLogeado
        {
            get { return this.usuarioLogeado; }
            set { this.usuarioLogeado = value; }
        }

        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            string path = @"..\..\..\MOCK_DATA.json";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json_str = sr.ReadToEnd();

                    this.listaUsuarios = (List<Usuario>)JsonSerializer.Deserialize(json_str, typeof(List<Usuario>));
                }
            }

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Correo o contraseña incorrecta.", "Ingreso inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
