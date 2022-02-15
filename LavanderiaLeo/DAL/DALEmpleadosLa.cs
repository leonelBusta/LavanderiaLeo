using LavanderiaLeo.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LavanderiaLeo.DAL
{
    public class DALEmpleadosLa
    {
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);



        public static List<EmpleadosLaVO> GetLstEmpleado()
        {
            try
            {
                //comando
                SqlCommand cmd = new SqlCommand("Empleados_Listar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsEmpleado = new DataSet();
                //parametros
                adapter.Fill(dsEmpleado);
                List<EmpleadosLaVO> LstEmpleados = new List<EmpleadosLaVO>();
                foreach (DataRow dr in dsEmpleado.Tables[0].Rows)
                {
                    LstEmpleados.Add(new EmpleadosLaVO(dr));
                }
                return LstEmpleados;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // insertar
        public static void insEmpleado(
            string Nombre,
            string Apellido,
            string Puesto,
            string Telefono,
            string UrlFoto)
        {
            try
            {
                string Query = "Empleados_Insertar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Puesto", Puesto);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);

                conn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }
        //actualizar

        public static void UpdEmpleado(
            int id,
            string Nombre,
            string Apellido,
            string Puesto,
            string Telefono,
            string UrlFoto)
        {
            try
            {
                string Query = "Empleados_Actualizar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Puesto", Puesto);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        //eliminar
        public static void DelEmpleado(int id)
        {
            try
            {
                string Query = "Empleados_Eliminar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        //getbyid
        public static EmpleadosLaVO GetEmpleadosLaById(int id)
        {
            try
            {
                string Query = "Empleados_GetByID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                DataSet dsEmpleado = new DataSet();
                adapter.Fill(dsEmpleado);
                if(dsEmpleado.Tables[0].Rows.Count > 0)
                {
                    //encotro un regristro
                    DataRow dr = dsEmpleado.Tables[0].Rows[0];
                    EmpleadosLaVO empleado = new EmpleadosLaVO(dr);
                    return empleado;
                }
                else
                {
                    //la tabla esta vacia
                    EmpleadosLaVO empleado = new EmpleadosLaVO();
                    return empleado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



    }//end class
}