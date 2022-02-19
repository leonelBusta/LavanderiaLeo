using LavanderiaLeo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LavanderiaLeo.BLL
{
    public class BLLVentaLa
    {
        public static long insVenta (int idEmpleado, int idCliente, int idPrenda, int idServicio, DateTime FechaEntrada, DateTime FechaSalida, int idDireccion)
        {
            return DALVentasLa.InsVenta(idEmpleado, idServicio, idCliente, FechaSalida, FechaEntrada, idDireccion);
        }
    }
}