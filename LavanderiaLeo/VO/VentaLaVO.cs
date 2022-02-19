using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LavanderiaLeo.VO
{
    public class VentaLaVO
    {

        private int _idPrende;
        private int _idServicio;
        private int _idEmpleado;
        private int _idCliente;
        private DateTime _FechaEntrada;
        private DateTime _FechaSalida;
        private bool _pagado;
        private int _idDireccion;

      

        
        public int IdPrende { get => _idPrende; set => _idPrende = value; }
        public int IdServicio { get => _idServicio; set => _idServicio = value; }
        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public DateTime FechaEntrada { get => _FechaEntrada; set => _FechaEntrada = value; }
        public DateTime FechaSalida { get => _FechaSalida; set => _FechaSalida = value; }
        public bool Pagado { get => _pagado; set => _pagado = value; }
        public int idDireccion { get => _idDireccion; set => _idDireccion = value; }

        public VentaLaVO(DataRow dr)
        {
           
            IdPrende = int.Parse(dr["idPrende"].ToString()); 
            IdServicio = int.Parse(dr["idServicio"].ToString()); 
            IdEmpleado = int.Parse(dr["idEmpleado"].ToString());
            IdCliente = int.Parse(dr["idCliente"].ToString());
            FechaEntrada = DateTime.Parse(dr["idServicio"].ToString());
            FechaSalida = DateTime.Parse(dr["fechaSalida"].ToString());
            Pagado = bool.Parse(dr["pagado"].ToString());
            idDireccion = int.Parse(dr["idDireccion"].ToString());
        }

        public VentaLaVO()
        {
          
            IdPrende = 0;
            IdServicio = 0;
            IdEmpleado = 0;
            IdCliente = 0;
            FechaEntrada = DateTime.Parse("1994-08-24"); 
            FechaSalida = DateTime.Parse("1994-08-24");
            Pagado = false;
            idDireccion = 0;
        }
    }
}