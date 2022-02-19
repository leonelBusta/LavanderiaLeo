using Gen2_3capas.Util;
using LavanderiaLeo.BLL;
using LavanderiaLeo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LavanderiaLeo.catalogos.Empleados
{
    public partial class ListadoEmpledosLa : System.Web.UI.Page
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

                }
            }

        }
        public void RefrescaGrid()
        {
            //LLenar el CVchoferes en la ,ista de choferesVO
            GVEmpleadosLa.DataSource = BLLEmpleadosLa.GetLstEmpleados();
            //actual el contenid
            GVEmpleadosLa.DataBind();
        }

        protected void GVEmpleadosLa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());

                string id = GVEmpleadosLa.DataKeys[index].Values["Id"].ToString();

                Response.Redirect("EdicionEmpleadoLa.aspx?Id=" + id);
            }
        }

        protected void GVEmpleadosLa_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVEmpleadosLa.EditIndex = e.NewEditIndex;
            RefrescaGrid();
        }

        protected void GVEmpleadosLa_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string id = GVEmpleadosLa.DataKeys[e.RowIndex].Values["Id"].ToString();
                string Nombre = e.NewValues["Nombre"].ToString();
                string Apellido = e.NewValues["Apellido"].ToString();
                BLLEmpleadosLa.UpdEmpleado(
                    Nombre, Apellido, null, null, null, int.Parse(id));
                GVEmpleadosLa.EditIndex = -1;
                UtilControls.SweetBox("empleado se actualizo con exito", "", "success", this.Page, this.GetType());
                RefrescaGrid();
                    
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void GVEmpleadosLa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = GVEmpleadosLa.DataKeys[e.RowIndex].Values["Id"].ToString();
            string resultado = BLLEmpleadosLa.DelEmpleado(int.Parse(Id));

            if (resultado == "Empleado Eliminado")
            {
                UtilControls.SweetBox("Empleado eliminado con exito", "", "success", this.Page, this.GetType());
                RefrescaGrid();
            }
            else if(resultado == "2")
            {
                UtilControls.SweetBox("Empleado no pudo ser eliminado ", "los empleados no estan " + "No disponible no pueden ser eliminados ", "error ", this.Page, this.GetType());
            }
            else if (resultado == "0")
            {
                UtilControls.SweetBox("Empleado no pudo ser eliminado ", "los empleados no estan " + "No disponible no pueden ser eliminados ", "error ", this.Page, this.GetType());
            }
        }

        protected void GVEmpleadosLa_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVEmpleadosLa.EditIndex = -1;
            RefrescaGrid();
        }

        protected void GVEmpleadosLa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}