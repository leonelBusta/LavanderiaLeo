<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaClienteLa.aspx.cs" Inherits="LavanderiaLeo.catalogos.Clientes.AltaClienteLa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Registro de clientes 
                </h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=txtNombre.ClientID%>">Nombre</label>
                    <asp:TextBox ID="txtNombre" placeholder="Nombre completo" CssClass="form-cotrol" runat="server" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiedFieldValidator1" ControlToValidate="txtNombre" CssClass="text-danger" runat="server" ErrorMessage="Nombre de cliente"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=txtApPaterno.ClientID%>">Apellido Parterno</label>
                    <asp:TextBox ID="txtApPaterno" placeholder="Apellido Paterno" CssClass="form-cotrol" runat="server" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtApPaterno" CssClass="text-danger" runat="server" ErrorMessage="Apellido Paterno"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="col-md-12">
                <div class="form-grup">
                    <label for="<%=txtTelefono.ClientID%>">Telefono</label>
                    <asp:TextBox ID="txtTelefono" CssClass="form-cotrol" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtTelefono" CssClass="text-danger" runat="server" ErrorMessage="Telefono del chofer"></asp:RequiredFieldValidator>
                        <!--  --aca vamos a colocar una mascara---  --->
                    <AjaxToolkit:MaskedEditExtender
                        ID="MEEtxtTelefono"
                        TargetControlID="txtTelefono"
                        Mask="(999) 999-9999"
                        ClearMaskOnLostFocus="false"
                        runat="server"
                        >
                    </AjaxToolkit:MaskedEditExtender>

                </div>
            </div>
           

            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button ID="btnGuardar"
                        CssClass="btn btn-primary"
                        runat="server" Text="Guardar" onClick="btnGuardar_Click1"/>
                </div>

            </div>
        </div>
    </div>
 
</asp:Content>
