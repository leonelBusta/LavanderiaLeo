<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaEmpleadosLa.aspx.cs" Inherits="LavanderiaLeo.catalogos.Empleados.AltaEmpleadosLa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Registro de Empleados</h3>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=txtNombre.ClientID %>">Nombre</label>
                    <asp:TextBox ID="txtNombre" placeholder="Nombre" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiedFieldValidator1" ControlToValidate="txtNombre" CssClass="text-danger" runat="server" ErrorMessage="Nombre de empleado"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=txtApellido.ClientID %>">Apellido</label>
                    <asp:TextBox ID="txtApellido" placeholder="Apellido" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtApellido" CssClass="text-danger" runat="server" ErrorMessage="Apellido"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=txtPuesto.ClientID %>">Puesto</label>
                    <asp:TextBox ID="txtPuesto" placeholder="Apellido" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPuesto" CssClass="text-danger" runat="server" ErrorMessage="Puesto"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-grup">
                    <label for="<%=txtTelefono.ClientID%>">Telefono</label>
                    <asp:TextBox ID="txtTelefono" CssClass="form-cotrol" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtTelefono" CssClass="text-danger" runat="server" ErrorMessage="Telefono del chofer"></asp:RequiredFieldValidator>
                    <!--  --aca vamos a colocar una mascara---  --->
                    <ajaxToolkit:MaskedEditExtender
                        ID="MEEtxtTelefono"
                        TargetControlID="txtTelefono"
                        Mask="(999) 999-9999"
                        ClearMaskOnLostFocus="false"
                        runat="server"></ajaxToolkit:MaskedEditExtender>

                </div>
            </div>

            
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=SubeImagen.ClientID%>">Selecciona Foto</label>
                    <div class="row">
                        <div class="col-md-3">
                            <input type="file" id="SubeImagen"
                                class="btn btn-file" runat="server" />
                        </div>
                        <div class="col-md-9">
                            <asp:Button ID="btnSubeImagen" CssClass="btn btn-primary"
                                runat="server" Text="Subir" OnClick="btnSubeImagen_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <label>Foto</label>
                    <asp:Image ID ="imgFotoEmpleado" width="150" Height="100" runat="server"></asp:Image>
                    <label id="urlFoto" runat="server"></label>
                </div>
            </div>

            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                </div>

            </div>

        </div>

    </div>

</asp:Content>
