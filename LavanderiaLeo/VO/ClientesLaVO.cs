using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LavanderiaLeo.VO
{
    public class ClientesLaVO
    {
        private int _id;
        private string _Nombre;
        private string _Apellido;
        private string _Telefono;

   
        public ClientesLaVO()
        {
            Id = 0;
            Nombre = String.Empty;
            Apellido = String.Empty;
            Telefono = String.Empty;
        }
        public ClientesLaVO(DataRow dr)
        {
            Id = int.Parse(dr["Id"].ToString());
            Nombre = dr["Nombre"].ToString();
            Apellido = dr["Apellido"].ToString();
            Telefono = dr["Telefono"].ToString();
        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
    }
}