using LavanderiaLeo.DAL;
using LavanderiaLeo.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LavanderiaLeo.BLL
{
    public class BLLEmpleadosLa
    {
        
        public static List<EmpleadosLaVO> GetLstEmpleados()
        {
            return DALEmpleadosLa.GetLstEmpleado();
        }


        //insertar 

        public static string insEmpleado
            (string Nombre,
            string Apellido,
            string Puesto,
            string Telefono,
            string UrlFoto)
        {
            try
            {
                List<EmpleadosLaVO> LstEmpleado = DALEmpleadosLa.GetLstEmpleado();
                DALEmpleadosLa.insEmpleado(Nombre, Apellido, Puesto, Telefono, UrlFoto);
                return "Empleado agregado";
            }
            catch (Exception)
            {

                throw;
            }
        }

        //actualizar

        public static string UpdEmpleado(
            string Nombre,
            string Apellido,
            string Puesto,
            string Telefono,
            string UrlFoto,
            int id)
        {
            try
            {
                List<EmpleadosLaVO> LstEmpleados = DALEmpleadosLa.GetLstEmpleado();
                DALEmpleadosLa.UpdEmpleado(id, Nombre, Apellido, Puesto, Telefono, UrlFoto);
                return "Empleado actualizado";
            }
            catch (Exception)
            {

                throw;
            }
        }

        //eliminar

        public static string DelEmpleado(int id)
        {
            try
            {
                EmpleadosLaVO empleadoVO = DALEmpleadosLa.GetEmpleadosLaById(id);

                DALEmpleadosLa.DelEmpleado(id);
                return "Empleado Eliminado";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //getbyid
        public static EmpleadosLaVO GetEmpleadosLaById(int id)
        {
            try
            {
                return DALEmpleadosLa.GetEmpleadosLaById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }//end class
}