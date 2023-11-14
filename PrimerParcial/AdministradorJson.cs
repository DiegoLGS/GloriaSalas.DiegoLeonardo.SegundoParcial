using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace PrimerParcial
{
    public static class AdministradorJson
    {
        private static int maximosIntentosFallidos;

        static AdministradorJson()
        {
            AdministradorJson.maximosIntentosFallidos = 3;
        }

        public static List<Usuario> CargarUsuarios(string path)
        {
            List<Usuario> listaCargada = null;

            try
            {

                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string json_str = sr.ReadToEnd();

                        listaCargada = (List<Usuario>)JsonSerializer.Deserialize(json_str, typeof(List<Usuario>));
                    }

                }

            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error en el formato del archivo JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listaCargada;
        }

        public static void IntentosLogin(int numeroIntento, Form formularioLogin)
        {
            if (numeroIntento < AdministradorJson.maximosIntentosFallidos)
            {
                MessageBox.Show($"Correo o contraseña incorrecta.\nIntentos restantes: {AdministradorJson.maximosIntentosFallidos - numeroIntento}.", "Ingreso inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Acceso inválido, el programa se cerrará.", "Ingreso inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                formularioLogin.Close();
            }
        }
    }
}
