using WinFormsEmpleados;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();  
            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmCRUD(frmLogin.UsuarioLogeado.ToString, frmLogin.UsuarioLogeado.ObtenerDatosLog, frmLogin.UsuarioLogeado.perfil));
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
        }
    }
}