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


namespace PrimerParcial
{
    public class AdministradorLog : ICargarArchivo<string>, IGuardarArchivo<string>
    {
        public string CargarArchivo(string path)
        {
            string registro = "El archivo de registro no existe o está vacío.";

            try
            {
                if (File.Exists(path))
                {
                    registro = File.ReadAllText(path);
                }                
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"No tiene permiso para acceder al archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show($"La ruta del archivo no es válida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return registro;
        }

        public void GuardarArchivo(string path, string datos)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    string usuarioYHora = datos.ToString();

                    sw.Write(usuarioYHora);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"No tiene permiso para acceder o modificar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show($"La ruta del archivo no es válida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
