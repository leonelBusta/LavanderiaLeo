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
    public class DALClienteLa
    {

        //ADO>NET
        //propiedad

        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        //listar

        public static List<ClientesLaVO>GetLstCliente()
        {
            try
            {
                //comando
                SqlCommand cmd = new SqlCommand("Clientes_Listar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsClientes = new DataSet();
                //parametros
                adapter.Fill(dsClientes);
                List<ClientesLaVO> LstClientes = new List<ClientesLaVO>();
                foreach(DataRow dr in dsClientes.Tables[0].Rows)
                {
                    LstClientes.Add(new ClientesLaVO(dr));
                }
                return LstClientes;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //insert
        public static void InsCliente
            (string Nombre,
            string Apellido,
            string Telefono)
        {
            try
            {
                string Query = "Clientes_Insertar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                conn.Open();
                cmd.ExecuteNonQuery();
                //ejecuta son requerir valores de entorno

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }

        }
        //Actualizar
        public static void UpdCliente
            (int id, 
            string Nombre,
            string Apellido,
            string Telefono
            )
        {
            try
            {
                string Query = "Clientes_Actualizar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Apellido);
                cmd.Parameters.AddWithValue("@Telefono", Telefono);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        //eliminar

        public static void DelCliente(int id)
        {
            try
            {
                string Query = "Clientes_Eliminar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { conn.Close(); }
        }

        public static ClientesLaVO GetClientesById(int id)
        {
            try
            {
                string Query = "Clientes_GetByID";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                DataSet dsCliente = new DataSet();
                adapter.Fill(dsCliente);
                if (dsCliente.Tables[0].Rows.Count > 0)
                {
                    //encontro un registro
                    DataRow dr = dsCliente.Tables[0].Rows[0];
                    ClientesLaVO cliente = new ClientesLaVO(dr);
                    return cliente;
                }
                else
                {
                    //la tabal esta vacia
                    ClientesLaVO cliente = new ClientesLaVO();
                    return cliente;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }//end ByID


    }//end class
}