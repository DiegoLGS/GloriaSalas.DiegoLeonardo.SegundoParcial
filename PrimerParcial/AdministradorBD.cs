using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    public class AdministradorBD
    {
        private SqlConnection conexion;
        private static string cadena_conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static AdministradorBD()
        {
            AdministradorBD.cadena_conexion = Properties.Resources.conexionEmpleadosBD;
        }

        public AdministradorBD()
        {
            this.conexion = new SqlConnection(AdministradorBD.cadena_conexion);
        }

        public bool AgregarEmpleadoBD(Mesero mesero)
        {
            this.comando = this.ConfigurarParametrosComunes(mesero);

            this.comando.Parameters.AddWithValue("@zona_atencion", mesero.ZonaDeAtencion);
            this.comando.Parameters.AddWithValue("@mesas_asignadas", mesero.NumeroDeMesas);
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "INSERT INTO meseros (nombre, legajo, turno, horas_extra, zona_atencion, mesas_asignadas) VALUES (@nombre, @legajo, @turno, @horas_extra, @zona_atencion, @mesas_asignadas)";

            return EjecutarComando(this.comando);
        }

        public bool AgregarEmpleadoBD(Cocinero cocinero)
        {
            this.comando = this.ConfigurarParametrosComunes(cocinero);

            this.comando.Parameters.AddWithValue("@especialidad", cocinero.Especialidad);
            this.comando.Parameters.AddWithValue("@certificacion", cocinero.Certificacion);
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "INSERT INTO cocineros (nombre, legajo, turno, horas_extra, especialidad, certificacion) VALUES (@nombre, @legajo, @turno, @horas_extra, @especialidad, @certificacion)";

            return EjecutarComando(this.comando);
        }

        public bool AgregarEmpleadoBD(Cajero cajero)
        {
            this.comando = this.ConfigurarParametrosComunes(cajero);

            this.comando.Parameters.AddWithValue("@propina", cajero.PropinaActual);
            this.comando.Parameters.AddWithValue("@caja_asignada", cajero.CajaAsignada);
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "INSERT INTO cajeros (nombre, legajo, turno, horas_extra, propina, caja_asignada) VALUES (@nombre, @legajo, @turno, @horas_extra, @propina, @caja_asignada)";

            return EjecutarComando(this.comando);
        }

        private SqlCommand ConfigurarParametrosComunes(Empleado empleado)
        {
            comando = new SqlCommand();
            comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
            comando.Parameters.AddWithValue("@legajo", empleado.Legajo);
            comando.Parameters.AddWithValue("@turno", (int)empleado.TurnoDeTrabajo);
            comando.Parameters.AddWithValue("@horas_extra", empleado.DisponibleHorasExtras);

            return comando;
        }

        private bool EjecutarComando(SqlCommand comando)
        {
            bool respuesta = false;

            try
            {
                comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return respuesta;
        }
    }
}
