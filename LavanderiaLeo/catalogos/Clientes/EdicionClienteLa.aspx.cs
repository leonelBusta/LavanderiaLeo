using Gen2_3capas.Util;
using LavanderiaLeo.BILL;
using LavanderiaLeo.Util;
using LavanderiaLeo.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LavanderiaLeo.catalogos.Clientes
{
    public partial class EdicionClienteLa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListadoClientesLa.aspx");
                }
                int Id = int.Parse(Request.QueryString["Id"]);
                ClientesLaVO cliente = BLLClientesLa.GetClienteById(Id);
                if (cliente.Id == 0)
                {
                    UtilControls.SweetBoxConfirm("Error", "el cliente no se encuentra en la base de datos", "warning ", "ListadoClientesLa.aspx", this.Page, this.GetType());
                }
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtTelefono.Text = cliente.Telefono;
                
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = txtNombre.Text;
                string Apellido = txtApellido.Text;
                string Telefono = txtTelefono.Text;

                int id = int.Parse(Request.QueryString["Id"].ToString());

                BLLClientesLa.UpdCliente(Nombre, Apellido, Telefono, id);

                UtilControls.SweetBoxConfirm("Exito", "Cliente actualizado", "success", "ListadoClientesLa.aspx", this.Page, this.GetType());
            }
            catch (Exception ex)
            {

                UtilControls.SweetBox("Error", ex.Message, "Error", this.Page, this.GetType());
            }
        }

     
    }
}