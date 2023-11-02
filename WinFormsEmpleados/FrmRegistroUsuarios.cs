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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
