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
            GVEmpleadosLa.DataSource = BLLChoferes.GetLstChoferes(null);
            //actual el contenid
            GVEmpleadosLa.DataBind();
        }


    }
}