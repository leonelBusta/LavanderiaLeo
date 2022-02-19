using Gen2_3capas.Util;
using LavanderiaLeo.BLL;
using LavanderiaLeo.Util;
using LavanderiaLeo.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LavanderiaLeo.catalogos.Empleados
{
    public partial class EdicionEmpleadoLa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListadoEmpledosLa.aspx");
                }
                int Id = int.Parse(Request.QueryString["Id"]);
                EmpleadosLaVO empleado = BLLEmpleadosLa.GetEmpleadosLaById(Id);
                if(empleado.Id == 0)
                {
                    UtilControls.SweetBoxConfirm("Error", "El empleado no se encuentra en la base de datos", "Warning", "ListadoEmpledosLa.aspx", this.Page, this.GetType());
                }
                txtNombre.Text = empleado.Nombre;
                txtApellido.Text = empleado.Apellido;
                txtPuesto.Text = empleado.Puesto;
                txtTelefono.Text = empleado.Telefono;
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            //validar que el usuario haya salecionado un archivo 
            if (SubeImagen.Value != "")
            {
                //asignar a una variable el nombre del archivo seleccionado 
                string FileName =
                    Path.GetFileName(SubeImagen.PostedFile.FileName);
                //validar que el archivo sea .jpg .png
                string FileExt =
                    Path.GetExtension(FileName).ToLower();

                if ((FileExt != ".jpg") && (FileExt != ".png"))
                {
                    //mensaje de error
                    UtilControls.SweetBox("Error!", "Seleccione un archivo valido", "error", this.Page, this.GetType());
                }
                else
                {
                    //verificar que el directorio donde vamos 
                    string pahDir =
                        Server.MapPath("~/Imagenes/Empleados/");
                    if (!Directory.Exists(pahDir))
                    {
                        //crea el arbol coplre
                        Directory.CreateDirectory(pahDir);
                    }
                    //guarda la imagen en el direccitorioo
                    SubeImagen.PostedFile.SaveAs(pahDir + FileName);
                    string urlfoto = "/Imagenes/Empleados/" + FileName;
                    urlFoto.InnerText = urlfoto;
                    imgFotoEmpleado.ImageUrl = urlfoto;
                    btnGuardar.Visible = true;
                }
            }
            else
            {
                //enviar mensaje de que no puede ser vacio
                //mensaje de error
                UtilControls.SweetBox("Error!", "Seleccione un archivo valido", "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = txtNombre.Text;
                string Apellido = txtApellido.Text;
                string Puesto = txtPuesto.Text;
                string Telefono = txtTelefono.Text;
                string UrlFoto = imgFotoEmpleado.ImageUrl;

                int id = int.Parse(Request.QueryString["Id"].ToString());

                BLLEmpleadosLa.UpdEmpleado(Nombre, Apellido, Puesto , Telefono, UrlFoto, id);

                UtilControls.SweetBoxConfirm("Exito", "Empleado actualizado", "success", "ListadoEmpledosLa.aspx", this.Page, this.GetType());
            }
            catch (Exception ex)
            {

                UtilControls.SweetBox("Error", ex.Message, "Error", this.Page, this.GetType());
            }
        }
    }
}