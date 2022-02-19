﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen2_3capas.Util
{
    public class DBConnection
    {
        private String _StringDeConexion;

        public string StringDeConcexion { get => _StringDeConexion; set => _StringDeConexion = value; }

        public DBConnection(String cnxnString)
        {
            this._StringDeConexion = cnxnString;
        }
        public static string connectionString = ConfigurationManager.ConnectionStrings["Conn"] != null ? ConfigurationManager.ConnectionStrings["Conn"].ConnectionString : "";
        public static DataSet ExecuteQuery(SqlConnection conn, SqlTransaction tran, string spName, out int retValue, params object[] parametros)
        {
            if (parametros != null && parametros.Length % 2 != 0)
                throw new Exception("Los parametros deben de venir en pares");

            SqlCommand comm = DBConnection.fillSqlCommand_Parameters(spName, parametros);
            comm.Connection = conn;
            if (tran != null)
                comm.Transaction = tran;
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            adapter.Fill(ds); //aca exactamente ejecutas la consulta
            retValue = comm.Parameters["RetVal"].Value != null ? (int)comm.Parameters["RetVal"].Value : 0;
            return ds;
        }

        public static long ExecuteNonQueryGetIdentity(SqlConnection conn, SqlTransaction tran, string spName, params object[] parametros)
        {
            if (parametros != null && parametros.Length % 2 != 0)
                throw new Exception("Los parametros deben de venir en pares");
            SqlCommand comm = DBConnection.fillSqlCommand_Parameters(spName, parametros);
            comm.Connection = conn;
            if (tran != null)
                comm.Transaction = tran;
            object objReturn = comm.ExecuteScalar();
            comm = conn.CreateCommand();
            comm.Transaction = tran;
            comm.CommandText = "SELECT @@IDENTITY";
            object val = comm.ExecuteScalar();
            long identity = long.Parse(val.ToString());
            comm.Dispose();
            return identity;
        }
        public static long ExecuteNonQueryGetIdentity(string spName, params object[] parametros)
        {
            return ExecuteGetIdentityWithStrCon(DBConnection.connectionString, spName, parametros);
        }
        public static long ExecuteGetIdentityWithStrCon(string stringDeConexion, string spName, params object[] parametros)
        {
            SqlConnection conn = new SqlConnection(stringDeConexion);
            conn.Open();
            long identity = ExecuteNonQueryGetIdentity(conn, null, spName, parametros);
            conn.Close();
            return identity;
        }
        public static DataSet ExecuteGetIdentityWithStrCon(string stringDeConexion, string spName, out int retValue, params object[] parametros)
        {
            SqlConnection conn = new SqlConnection(stringDeConexion);
            conn.Open();
            DataSet ds = ExecuteQuery(conn, null, spName, out retValue, parametros);
            conn.Close();
            return ds;
        }
        public static DataSet ExecuteDataset(string spName, out int retValue, params object[] parametros)
        {
            return ExecuteGetIdentityWithStrCon(DBConnection.connectionString, spName, out retValue, parametros);
        }
        public static DataSet ExecuteDataset(string spName, params object[] parametros)
        {
            int retValue;
            SqlConnection conn = new SqlConnection(DBConnection.connectionString);
            conn.Open();
            DataSet ds = ExecuteQuery(conn, null, spName, out retValue, parametros);
            conn.Close();
            return ds;
        }
        public static int ExecuteNonQuery(string spName, out int retValue, params object[] parametros)
        {
            return ExecuteNonQueryWithStrCon(DBConnection.connectionString, spName, out retValue, parametros);
        }
        public static int ExecuteNonQueryWithStrCon(string stringDeConexion, string spName, out int retValue, params object[] parametros)
        {
            SqlConnection conn = new SqlConnection(stringDeConexion);
            conn.Open();
            int numRowAffected = 0;
            numRowAffected = ExecuteNonQuery(conn, null, spName, out retValue, parametros);
            conn.Close();
            return numRowAffected;
        }
        public static int ExecuteNonQuery(string spName, params object[] parametros)
        {
            int retVal;
            return ExecuteNonQuery(spName, out retVal, parametros);
        }
        public static int ExecuteNonQuery(SqlConnection conexion, SqlTransaction tran, string spName, out int retValue, params object[] parametros)
        {
            if (parametros != null && parametros.Length % 2 != 0)
                throw new Exception("Los parametros deben de venir en paras");

            SqlCommand comm = DBConnection.fillSqlCommand_Parameters(spName, parametros);
            comm.Connection = conexion;
            if (tran != null)
                comm.Transaction = tran;

            int numRowsAffected = comm.ExecuteNonQuery();
            retValue = comm.Parameters["RetVal"].Value != null ? (int)comm.Parameters["RetVal"].Value : 0;
            return numRowsAffected;

        }

        public static object ExecuteScalar(string spName, out int retValue, params object[] parametros)
        {
            if (parametros != null && parametros.Length % 2 != 0)
                throw new Exception("Los parametros deben de venir en pares");
            SqlConnection conn = new SqlConnection(DBConnection.connectionString);
            SqlCommand comm = DBConnection.fillSqlCommand_Parameters(spName, parametros);

            conn.Open();
            comm.Connection = conn;
            object objReturn = comm.ExecuteScalar();
            conn.Close();

            retValue = comm.Parameters["RetVal"].Value != null ? (int)comm.Parameters["RetVal"].Value : 0;
            return objReturn;
        }
        public static object ExecuteScalar(String StrConnectionString, string strStoredProcedure, out int intRetValue, params object[] objParametros)
        {
            if (objParametros != null && objParametros.Length % 2 != 0) { throw new Exception("Los parametros deben de vebir en pares"); }
            SqlConnection miSqlConnection = new SqlConnection(StrConnectionString);
            SqlCommand miSqlCommand = DBConnection.fillSqlCommand_Parameters(strStoredProcedure, objParametros);

            miSqlConnection.Open();

            miSqlCommand.Connection = miSqlConnection;

            Object objReturn = miSqlCommand.ExecuteScalar();

            miSqlConnection.Close();

            intRetValue = miSqlCommand.Parameters["RetVal"].Value != null ? (int)miSqlCommand.Parameters["RetVal"].Value : 0;

            return objReturn;
        }
        private static SqlCommand fillSqlCommand_Parameters(String spName, params object[] parametros)
        {
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = spName;

            if (parametros != null)
            {
                for (int i = 0; i < parametros.Length; i = i + 2)
                {
                    comm.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }
            }
            SqlParameter retValue = new SqlParameter("RetVal", SqlDbType.Int);
            retValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(retValue);

            return comm;
        }
    }
}