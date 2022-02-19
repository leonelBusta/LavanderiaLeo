using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gen2_3capas.Util;
using LavanderiaLeo.Util;


namespace LavanderiaLeo.DAL
{
    public class DALVentasLa
    {

        //insertar

        public static long InsVenta(int idEmpleado, int idServicio, int idCliente, DateTime? fechaSalida, DateTime? fechaEntrada, int idDireccion)
        {
            try
            {
                return DBConnection.ExecuteNonQueryGetIdentity
                        ("Ventas_Insertar", "@id", idEmpleado,
                                    "@idServicio", idServicio,
                                    "@idCliente", idCliente,
                                    "@FechaSalida", fechaSalida,
                                    "@FechaEntrada", fechaEntrada,
                                    "@idDireccion", idDireccion);


            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }///end class
}