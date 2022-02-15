using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LavanderiaLeo.VO
{
    public class EmpleadosLaVO
    {
        private int _id;
        private string _Nombre;
        private string _Apellido;
        private string _Puesto;
        private string _Telefono;
        private string _UrlFoto;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Puesto { get => _Puesto; set => _Puesto = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto = value; }


        public EmpleadosLaVO()
        {
            Id = 0;
            Nombre = String.Empty;
            Apellido = String.Empty;
            Puesto = String.Empty;
            Telefono = String.Empty;
            UrlFoto = String.Empty;
        }
        public EmpleadosLaVO(DataRow dr)
        {
            Id = int.Parse(dr["Id"].ToString());
            Nombre = dr["Nombre"].ToString();
            Apellido = dr["Apellido"].ToString();
            Puesto = dr["Puesto"].ToString();
            Telefono = dr["Telefono"].ToString();
            UrlFoto = dr["UrlFoto"].ToString();
        }
    }
}