using Gen2_3capas.Util;
using LavanderiaLeo.BILL;
using LavanderiaLeo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LavanderiaLeo.catalogos.Clientes
{
    public partial class AltaClienteLa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     
        protected void btnGuardar_Click1(object sender, EventArgs e)
        {

            try
            {
                string nombre = txtNombre.Text;
                string apPaterno = txtApPaterno.Text;
                string Telefono = txtTelefono.Text;

                BLLClientesLa.insCliente(nombre, apPaterno, Telefono);

                UtilControls.SweetBoxConfirm("Exito!", "Cliente agregado exitosamente", "success", "ListadoClientesLa.aspx", this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), "error", this.Page, this.GetType());
            }
        }
    }
}