using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using Newtonsoft.Json;

namespace PrimerParcial
{
    public class AdministradorArchivos<T> : ICargarArchivo<T>, IGuardarArchivo<T>
    {
        private static int maximosIntentosFallidos;

        static AdministradorArchivos()
        {
            AdministradorArchivos<T>.maximosIntentosFallidos = 3;
        }       

        public T CargarArchivo(string path)
        {
            T registro = default(T);

            try
            {
                if (typeof(T) == typeof(string))
                {
                    registro = (T)(object)File.ReadAllText(path);
                }
                else
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string aux = sr.ReadToEnd();
                        registro = JsonConvert.DeserializeObject<T>(aux);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return registro;
        }

        public void GuardarArchivo(string path, T datos)
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

        public static void IntentosLogin(int numeroIntento, Form formularioLogin)
        {
            if (numeroIntento < AdministradorArchivos<T>.maximosIntentosFallidos)
            {
                MessageBox.Show($"Correo o contraseña incorrecta.\nIntentos restantes: {AdministradorArchivos<T>.maximosIntentosFallidos - numeroIntento}.", "Ingreso inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Acceso inválido, el programa se cerrará.", "Ingreso inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                formularioLogin.Close();
            }
        }
    }
}
