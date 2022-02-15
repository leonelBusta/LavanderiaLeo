<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoEmpledosLa.aspx.cs" Inherits="LavanderiaLeo.catalogos.Empleados.ListadoEmpledosLa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
     <div class="row">
          <div class="col-md-10 col-md-offset-1" style="scroll-margin-left: 40px;">
             <h3>Listado de Empleados</h3>

             
             <asp:GridView ID="GVEmpleadosLa" runat="server" CssClass="table table-bordered table-striped table-condensed" DataKeyNames="Id" AutoGenerateColumns="False" OnSelectedIndexChanged="GVEmpleadosLa_SelectedIndexChanged"
                 OnRowCommand="GVEmpleadosLa_RowCommand" OnRowEditing="GVEmpleadosLa_RowEditing" OnRowUpdating="GVEmpleadosLa_RowUpdating" OnRowDeleting="GVEmpleadosLa_RowDeleting"     OnRowCancelingEdit="GVEmpleadosLa_RowCancelingEdit">
                 <Columns>

                     <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seleccionar">
                     <ControlStyle CssClass="btn btn-success btn-xs" />
                     <ItemStyle Width="100px" />
                     </asp:ButtonField>
                     <asp:CommandField ButtonType="Button" ShowEditButton="True">
                     <ControlStyle CssClass="btn btn-primary btn-xs" Width="100%" />
                     <ItemStyle Width="100px" />
                     </asp:CommandField>
                     <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                     <ControlStyle CssClass="btn btn-danger btn-xs" />
                     <ItemStyle Width="100px" />
                     </asp:CommandField>
                     <asp:BoundField DataField="Id" HeaderText="Id "  ReadOnly="true">
                     <ItemStyle Width="50px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                     <ItemStyle Width="100px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Apellido" DataField="Apellido">
                     <ItemStyle Width="100px" />
                     </asp:BoundField>
                      <asp:BoundField HeaderText="Puesto" DataField="Puesto">
                     <ItemStyle Width="100px" />
                      </asp:BoundField>
                     <asp:BoundField HeaderText="Telefono" DataField="Telefono" ReadOnly="true">
                     <ItemStyle Width="100px" />
                     </asp:BoundField>
                  
                     <asp:ImageField DataImageUrlField="UrlFoto" HeaderText="Foto" ReadOnly="True">
                         <ControlStyle Height="90px" Width="120px" />
                         <ItemStyle Width="120px" />
                     </asp:ImageField>
                  
                 </Columns>
             </asp:GridView>


             
         </div>
     </div>
  </div>

               
</asp:Content>
