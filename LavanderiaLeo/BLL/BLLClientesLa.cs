using LavanderiaLeo.DAL;
using LavanderiaLeo.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LavanderiaLeo.BILL
{
    public class BLLClientesLa
    {

        public static List<ClientesLaVO> GetLstCliente()
        {
            return DALClienteLa.GetLstCliente();
        }


        //insertar

        public static string insCliente
            (string Nombre,
            string Apellido,
            string Telefono
            )
        {
            try
            {
                List<ClientesLaVO> LstClientes= DALClienteLa.GetLstCliente();
                //bool Existe = false;
                DALClienteLa.InsCliente(Nombre, Apellido, Telefono);
                return "Cliente agregado";
            }
            catch (Exception)
            {

                throw;
            }
        }


        //actualizar

        public static string UpdCliente(
            string Nombre,
            string Apellido,
            string Telefono,
            int id)
        {
            try
            {
                List<ClientesLaVO> LstClientes = DALClienteLa.GetLstCliente();
                //bool Existe = false;
                DALClienteLa.UpdCliente(id, Nombre, Apellido, Telefono);
                return "Cliente actualizado";
            }
            catch (Exception)
            {

                throw;
            }
        }


        //eliminar

        public static string DelCliente(int id)
        {
            try
            {
                ClientesLaVO clienteVO = DALClienteLa.GetClientesById(id);

                DALClienteLa.DelCliente(id);
                return "Cliente eliminado";

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //getbyid

        public static ClientesLaVO GetClienteById(int id)
        {
            try
            {
                return DALClienteLa.GetClientesById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }// end class
}


