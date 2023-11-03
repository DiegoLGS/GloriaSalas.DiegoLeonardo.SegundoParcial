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
    public partial class FrmRegistroUsuarios : Form
    {
        public FrmRegistroUsuarios()
        {
            InitializeComponent();
        }

        private void FrmRegistroUsuarios_Load(object sender, EventArgs e)
        {
            string path = @"..\..\..\Usuarios_logeados.log";

            try
            {
                if (File.Exists(path))
                {
                    string registro = File.ReadAllText(path);
                    this.txtRegistroUsuarios.Text = registro;
                }
                else
                {
                    this.txtRegistroUsuarios.Text = "El archivo de registro no existe o está vacío.";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"No tiene permiso para acceder al archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ruta no válida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
