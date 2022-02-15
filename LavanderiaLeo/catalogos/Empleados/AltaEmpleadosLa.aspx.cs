using Gen2_3capas.Util;
using LavanderiaLeo.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LavanderiaLeo.catalogos.Empleados
{
    public partial class AltaEmpleadosLa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                        Server.MapPath("~/Imagenes/Empleado/");
                    if (!Directory.Exists(pahDir))
                    {
                        //crea el arbol coplre
                        Directory.CreateDirectory(pahDir);
                    }
                    //guarda la imagen en el direccitorioo
                    SubeImagen.PostedFile.SaveAs(pahDir + FileName);
                    string UrlFoto = "/Imagenes/Empleado/" + FileName;
                    urlFoto.InnerText = UrlFoto;
                    imgFotoEmpleado.ImageUrl = UrlFoto;
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

                BLLEmpleadosLa.insEmpleado(Nombre, Apellido, Puesto, Telefono, UrlFoto);

                UtilControls.SweetBoxConfirm("Exito!", "Empleado Agregado", "success", "ListadoEmpledosLa.aspx", this.Page, this.GetType());

            }
            catch(Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), "error", this.Page, this.GetType());
            }
        }
    }
}