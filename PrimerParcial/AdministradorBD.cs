using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.comando = this.ConfigurarParametrosEspeciales(mesero); 
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "INSERT INTO meseros (nombre, legajo, turno, horas_extra, zona_atencion, mesas_asignadas) VALUES (@nombre, @legajo, @turno, @horas_extra, @zona_atencion, @mesas_asignadas)";

            return EjecutarComando(this.comando);
        }

        public bool AgregarEmpleadoBD(Cocinero cocinero)
        {
            this.comando = this.ConfigurarParametrosComunes(cocinero);
            this.comando = this.ConfigurarParametrosEspeciales(cocinero);            
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "INSERT INTO cocineros (nombre, legajo, turno, horas_extra, especialidad, certificacion) VALUES (@nombre, @legajo, @turno, @horas_extra, @especialidad, @certificacion)";

            return EjecutarComando(this.comando);
        }

        public bool AgregarEmpleadoBD(Cajero cajero)
        {
            this.comando = this.ConfigurarParametrosComunes(cajero);
            this.comando = this.ConfigurarParametrosEspeciales(cajero);
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

        private SqlCommand ConfigurarParametrosEspeciales(Mesero mesero)
        {
            comando.Parameters.AddWithValue("@zona_atencion", mesero.ZonaDeAtencion);
            comando.Parameters.AddWithValue("@mesas_asignadas", mesero.NumeroDeMesas);

            return comando;
        }

        private SqlCommand ConfigurarParametrosEspeciales(Cocinero cocinero)
        {
            comando.Parameters.AddWithValue("@especialidad", cocinero.Especialidad);
            comando.Parameters.AddWithValue("@certificacion", cocinero.Certificacion);

            return comando;
        }

        private SqlCommand ConfigurarParametrosEspeciales(Cajero cajero)
        {
            this.comando.Parameters.AddWithValue("@propina", cajero.PropinaActual);
            this.comando.Parameters.AddWithValue("@caja_asignada", cajero.CajaAsignada);

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

        public List<Empleado> ObtenerListaEmpleados()
        {
            ListadoEmpleados<Empleado> listaCargada = new ListadoEmpleados<Empleado>();

            try
            {
                listaCargada.listaDeEmpleados.AddRange(ObtenerEmpleadosDesdeTabla("meseros", "zona_atencion", "mesas_asignadas"));
                listaCargada.listaDeEmpleados.AddRange(ObtenerEmpleadosDesdeTabla("cocineros", "especialidad", "certificacion"));
                listaCargada.listaDeEmpleados.AddRange(ObtenerEmpleadosDesdeTabla("cajeros", "propina", "caja_asignada"));
            }
            catch (Exception ex)
            {
            }

            return listaCargada.listaDeEmpleados;
        }

        private List<Empleado> ObtenerEmpleadosDesdeTabla(string tabla, string columnaEspecialUno, string columnaEspecialDos)
        {
            ListadoEmpleados<Empleado> listaTablaEspecifica = new ListadoEmpleados<Empleado>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT nombre, legajo, turno, horas_extra, {columnaEspecialUno}, {columnaEspecialDos} FROM {tabla}";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    Empleado empleado = null;

                    switch (tabla)
                    {
                        case "meseros":
                            empleado = new Mesero(this.lector["nombre"].ToString(), (int)this.lector["legajo"], (ETurnos)(byte)this.lector["turno"], this.lector["zona_atencion"].ToString(), (byte)this.lector["mesas_asignadas"]);
                            break;

                        case "cocineros":
                            empleado = new Cocinero(this.lector["nombre"].ToString(), (int)this.lector["legajo"], (ETurnos)(byte)this.lector["turno"], this.lector["especialidad"].ToString(), this.lector["certificacion"].ToString());
                            break;

                        case "cajeros":
                            empleado = new Cajero(this.lector["nombre"].ToString(), (int)this.lector["legajo"], (ETurnos)(byte)this.lector["turno"], (int)this.lector["propina"], (byte)this.lector["caja_asignada"]);
                            break;                        
                    }

                    if (!(empleado is null))
                    {
                        empleado.DisponibleHorasExtras = (bool)this.lector["horas_extra"];
                        _ = listaTablaEspecifica + empleado;
                    }

                }

                this.lector.Close();

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

            return listaTablaEspecifica.listaDeEmpleados;
        }

        public bool EliminarEmpleadoPorLegajo(int legajo, string tabla)
        {
            this.comando = new SqlCommand();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.Connection = this.conexion;
            this.comando.Parameters.AddWithValue("@legajo", legajo);
            this.comando.CommandText = $"DELETE FROM {tabla} WHERE legajo = @legajo";

            return EjecutarComando(this.comando);                
        }

        public bool ModificarEmpleadoPorLegajo(Empleado empleado, int legajoOriginal)
        {
            this.comando = this.ConfigurarParametrosComunes(empleado);

            if (empleado is Mesero)
            {
                this.comando = this.ConfigurarParametrosEspeciales((Mesero)empleado);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"UPDATE meseros SET nombre = @nombre, legajo = @legajo, turno = @turno, horas_extra = @horas_extra, zona_atencion = @zona_atencion, mesas_asignadas = @mesas_asignadas WHERE legajo = {legajoOriginal}";
            }
            else if (empleado is Cocinero)
            {
                this.comando = this.ConfigurarParametrosEspeciales((Cocinero)empleado);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"UPDATE cocineros SET nombre = @nombre, legajo = @legajo, turno = @turno, horas_extra = @horas_extra, especialidad = @especialidad, certificacion = @certificacion WHERE legajo = {legajoOriginal}";
            }
            else
            {
                this.comando = this.ConfigurarParametrosEspeciales((Cajero)empleado);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"UPDATE cajeros SET nombre = @nombre, legajo = @legajo, turno = @turno, horas_extra = @horas_extra, propina = @propina, caja_asignada = @caja_asignada WHERE legajo = {legajoOriginal}";
            }
            
            return EjecutarComando(this.comando);
        }
    }
}
