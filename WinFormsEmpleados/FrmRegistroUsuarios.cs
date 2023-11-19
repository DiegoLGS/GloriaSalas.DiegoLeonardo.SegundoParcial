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
        private AdministradorArchivos<string> administradorLog;
        private delegate void DelegadoCargarLista();
        private Task cargarListaTask;

        public FrmRegistroUsuarios()
        {
            InitializeComponent();
            administradorLog = new AdministradorArchivos<string>();
        }

        private void FrmRegistroUsuarios_Load(object sender, EventArgs e)
        {
            cargarListaTask = Task.Run(() => CargarRegistroUsuarios());
        }

        private async void CargarRegistroUsuarios()
        {
            if (this.InvokeRequired)
            {
                DelegadoCargarLista delegadoCargar = new DelegadoCargarLista(CargarRegistroUsuarios);
                this.Invoke(delegadoCargar);
            }
            else
            {
                this.txtRegistroUsuarios.Text = "Cargando historial de usuarios logeados...";
                await Task.Delay(2000);
                this.txtRegistroUsuarios.Text = administradorLog.CargarArchivo(@"..\..\..\Usuarios_logeados.log");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
