using LavanderiaLeo.BILL;
using LavanderiaLeo.BLL;
using LavanderiaLeo.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LavanderiaLeo.catalogos.Ventas
{
    public partial class AltaVentasLa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilControls.FillDropDownList(DDLCliente, "id", "Nombre", BLLClientesLa.GetLstCliente(),"", "Selecciona un cliente");

                UtilControls.FillDropDownList(DDLEmpleado, "id", "Nombre", BLLEmpleadosLa.GetLstEmpleados(), "", "Selecciona un empleado");
            }
        }

        protected void btnAddCarga_Click(object sender, EventArgs e)//agregar costo
        {
            double Precio = double.Parse(txtPrecio.Text);
            string Descripcion = txtDescripcion.Text;
            if (Session["Cargar"] == null)
            {
                //agrega la cantidad
                DataTable dtCarga = Filldt();
                dtCarga.Rows.Add(Descripcion, Precio);
                GVCarga.DataSource = dtCarga;
                GVCarga.DataBind();
                Session.Add("Cargar", dtCarga);
                txtCargaTotal.Text = Precio.ToString();
                txtDescripcion.Text = "";
                txtPrecio.Text = "";
            }
            else
            {
                UtilControls.SweetBox("Capacidad  es menor a la carga", "Utilice mayor capacidad", "warning",
                       this.Page, this.GetType());
            }
            
        }

        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(DDLCliente.SelectedValue);
            int idEmpleado = int.Parse(DDLEmpleado.SelectedValue);
           
            DateTime fechaEntrada = DateTime.Parse(FELlegada.ToString());
        }

        protected void btnGuardarDir_Click(object sender, EventArgs e)
        {
            try
            {
                string calle = txtCalle.Text;
                string Numero = txtNumero.Text;
                string Colonia = txtColonia.Text;
                string Ciudad = txtCiudad.Text;

                //se consume la WEB SERVICE
                ServicioWeb.WSDireccionesSoapClient referencia = new ServicioWeb.WSDireccionesSoapClient();
                int idDireccion = referencia.insDireccion(calle, Numero, Colonia, Ciudad);
                if (txtEsOD.Text == "1")
                {
                    //es origen
                    Session["IdOrigen"] = idDireccion.ToString();
                    MPOrigen.Hide();
                }
                else
                {
                    //es destino
                    Session["IdDestino"] = idDireccion.ToString();
                    // MPDestino.hide();
                }
                LimpiarDireccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LimpiarDireccion()
        {
            txtEsOD.Text = String.Empty;
            txtCalle.Text = String.Empty;
            txtNumero.Text = String.Empty;
            txtColonia.Text = String.Empty;
            txtCiudad.Text = String.Empty;
            

        }
        private DataTable Filldt()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2]
                {
                    new DataColumn("Descripcion",typeof(string)),
                    new DataColumn("Precio",typeof(double))
                });

            return dt;
        }

        protected void DDLEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}