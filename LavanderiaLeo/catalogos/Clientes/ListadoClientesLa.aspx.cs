using Gen2_3capas.Util;
using LavanderiaLeo.BILL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LavanderiaLeo.catalogos.Clientes
{
    public partial class ListadoClientesLa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //
                    RefrescaGrid();
                }
                catch (Exception ex)
                {
                    //poner mensaje
                    throw;
                }
            }
        }

        public void RefrescaGrid()
        {
            GVClientesLA.DataSource = BLLClientesLa.GetLstCliente();
            GVClientesLA.DataBind();
        }

        protected void GVClientesLA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GVClientesLA_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());

                string id = GVClientesLA.DataKeys[index].Values["Id"].ToString();

                Response.Redirect("EdicionClienteLa.aspx?Id=" + id);
            }
        }

        protected void GVClientesLA_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVClientesLA.EditIndex = e.NewEditIndex;
            // GVChoferes.EditIndex = e.NewEditIndex;
            RefrescaGrid();
        }

        protected void GVClientesLA_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
               
            try
            {
                string id = GVClientesLA.DataKeys[e.RowIndex].Values["Id"].ToString();
                string Nombre = e.NewValues["Nombre"].ToString();
                string Apellido = e.NewValues["Apellido"].ToString();
                BLLClientesLa.UpdCliente(Nombre,Apellido,null,int.Parse(id));

                GVClientesLA.EditIndex = -1;
                UtilControls.SweetBox("cliente se acrualizo con exito", "", "success", this.Page, this.GetType());
                RefrescaGrid();
                
            }
            catch (Exception ex)
            {

                throw;
            }
                        
        }

        protected void GVClientesLA_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = GVClientesLA.DataKeys[e.RowIndex].Values["Id"].ToString();
            string Resultado = BLLClientesLa.DelCliente(int.Parse(Id));
            if (Resultado == "Cliente eliminado")
            {
                UtilControls.SweetBox("cliente eliminado con exito", "", "success", this.Page, this.GetType());
                RefrescaGrid();

            }
            else if (Resultado == "2")
            {
                UtilControls.SweetBox("cliente no pudo ser eliminado ", "los cliente no estas " +
                    "No Disponible no pueden ser eliminadordos", "error", this.Page, this.GetType());

            }
            else if (Resultado == "0")
            {
                UtilControls.SweetBox("cliente no pudo ser eliminado ", "los cliente no estas " +
                    "No Disponible no pueden ser eliminadordos", "error", this.Page, this.GetType());

            }
        }

        protected void GVClientesLA_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVClientesLA.EditIndex = -1;
            RefrescaGrid();
        }
    }
}