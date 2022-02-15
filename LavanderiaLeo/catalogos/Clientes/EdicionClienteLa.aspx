<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EdicionClienteLa.aspx.cs" Inherits="LavanderiaLeo.catalogos.Clientes.EdicionClienteLa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Edicion de chofer 
                </h3>
            </div>
        </div>
        <div class="row">
            
           

            <div class="col-md-12">
                <div class="form-grup">
                    <label for="<%=txtNombre.ClientID%>">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-cotrol" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtNombre" CssClass="text-danger" runat="server" ErrorMessage="Nombre de cliente"></asp:RequiredFieldValidator>
                        <!--  --aca vamos a colocar una mascara---  --->
                  
                </div>
            </div>
             <div class="col-md-12">
                <div class="form-grup">
                    <label for="<%=txtApellido.ClientID%>">Apellido</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-cotrol" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtApellido" CssClass="text-danger" runat="server" ErrorMessage="Apellido de cliente"></asp:RequiredFieldValidator>
                        <!--  --aca vamos a colocar una mascara---  --->
                  
                </div>
            </div>
             <div class="col-md-12">
                <div class="form-grup">
                    <label for="<%=txtTelefono.ClientID%>">Telefono</label>
                    <asp:TextBox ID="txtTelefono" CssClass="form-cotrol" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTelefono" CssClass="text-danger" runat="server" ErrorMessage="Telefono de cliente"></asp:RequiredFieldValidator>
                        <!--  --aca vamos a colocar una mascara---  --->
                  <AjaxToolkit:MaskedEditExtender
                        ID="MEEtxtTelefono"
                        TargetControlID="txtTelefono"
                        Mask="(999) 999-9999"
                        ClearMaskOnLostFocus="false"
                        >
                        runat="server"
                    </AjaxToolkit:MaskedEditExtender>
                </div>
            </div>


            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button ID="btnGuardar"
                        CssClass="btn btn-primary"
                        runat="server" Text="Guardar" onClick="btnGuardar_Click"/>
                </div>

            </div>
        </div>
    </div>

   <!-- <script>
        $(document).ready(function () {
            //declarar al time picker en el eeanol con memnete
            $.datetimepicker.setLocale('es');
            //asigamos el calendro a los inpit
            $("#<% // =fechaNacimiento.ClientID %>").datetimepicker({
                format: 'd/m/Y'
            });
        });
    </script>  --->
</asp:Content>
