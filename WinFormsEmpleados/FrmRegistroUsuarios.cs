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
    public partial class FrmRegistroUsuarios : Form
    {
        private AdministradorLog adminLog;

        public FrmRegistroUsuarios()
        {
            InitializeComponent();
            adminLog = new AdministradorLog();
        }

        private void FrmRegistroUsuarios_Load(object sender, EventArgs e)
        {
            this.txtRegistroUsuarios.Text = adminLog.CargarArchivo(@"..\..\..\Usuarios_logeados.log");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
