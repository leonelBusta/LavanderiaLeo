<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaVentasLa.aspx.cs" Inherits="LavanderiaLeo.catalogos.Ventas.AltaVentasLa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="//maps.googleapis.com/maps/api/js?key=AIzaSyCWeeateTaYGqsHhNcmoDfT7Us-vLDZVPs&amp;sensor=false&amp;language=en"></script>


    <style>
        .modalPanel {
            background-color: #fff;
        }

        .bgpanel {
            background-color: #0d0d0d;
            opacity: 0.70;
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>Venta</h3>
            </div>
            <!--  <div style="display: block">
                <asp:TextBox ID="txtEsOD" Text="Aca vendra ua bandera" runat="server"></asp:TextBox>

            </div> -->
        </div>

        <div class="row">
            <%--izquierdo--%>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="<%=DDLCliente.ClientID%>">Cliente</label>
                    <asp:DropDownList ID="DDLCliente" CssClass="form-control" runat="server"></asp:DropDownList>

                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">
                            <label for="<%=txtOrigen.ClientID%>">Direccion</label>
                            <asp:TextBox ID="txtOrigen" CssClass="form-control" runat="server"></asp:TextBox>

                            <%-- Aca vamos a meter la  funcion del autocppleta --%>

                            <ajaxToolkit:AutoCompleteExtender ID="ACtxtOrigen" TargetControlID="txtOrigen" MinimumPrefixLength="2" ServicePath="~/autocompletar.asmx" ServiceMethod="GetDirecciones" runat="server">
                            </ajaxToolkit:AutoCompleteExtender>
                        </div>

                        <div class="col-md-5">
                            <asp:Button ID="btnAddOrigen" CssClass="btn btn-primary btn-xs" runat="server" Text="Obtener Datos" Style="margin-top: 30px" OnClientClick="getDireccion(1)" />
                            <%-- cuando se presion el boton mostrat el modal con la onfromacion que me reciuperar la api de google  --%>
                            <%--  ava vamos a llamar al modal --%>

                            <ajaxToolkit:ModalPopupExtender ID="MPOrigen" TargetControlID="btnAddOrigen" PopupControlID="PnlorigenDestino" CancelControlID="btnCancelar" BackgroundCssClass="bgpanel" runat="server"></ajaxToolkit:ModalPopupExtender>
                        </div>
                    </div>
                </div>
            </div>


            <%-- Derecho --%>

            <%--aca vamos a copiar y pegar el izquierdo--%>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="<%=DDLEmpleado.ClientID%>">Empleado</label>
                    <asp:DropDownList ID="DDLEmpleado" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLEmpleado_SelectedIndexChanged"></asp:DropDownList>

                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">



                            <%-- Aca vamos a meter la  funcion del autocppleta --%>
                        </div>


                    </div>

                </div>

                <div class="form-group">
                    <label for="<%=FELlegada.ClientID %>">Fecha estimada de salida</label>
                    <input type="text" id="FELlegada" name="FELlegada" class="form-control" runat="server" />
                </div>

            </div>

            <div class="row">
                <div class="col-md-12">
                    <h4>Cargamento</h4>

                </div>

            </div>

            <div class="row" id="FormaCarga">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="<%=txtDescripcion.ClientID%>">Descripcion</label>
                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="<%=txtPrecio.ClientID%>">Precio</label>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">

                        <asp:Button ID="btnAddCarga" CssClass="btn btn-success" runat="server" Text="Agregar Carga" Style="margin-top: 25px" OnClick="btnAddCarga_Click"></asp:Button>

                    </div>
                </div>
            </div>

            <hr />
            <div class="row">

                <div class="col-md-4 col-md-offset-4">
                    <div class="form-group">
                        <label for="<%=txtCargaTotal.ClientID%>">precio Total</label>
                        <asp:TextBox ID="txtCargaTotal" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>

            </div>

            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <asp:GridView ID="GVCarga" CssClass="table table-striped" runat="server"></asp:GridView>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group pull-right">
                        <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Iniciar venta" OnClick="btnGuardar_Click" />
                    </div>
                </div>
            </div>

            <%--aca vamos a copiar el script 1--%>

            <script>
                $(document).ready(function () {
                    //Declarar al time picker en español con momentjs
                    $.datetimepicker.setLocale('es');
                    //Asignamos el calendario a los input de fecha

                    $("#<%=FELlegada.ClientID%>").
                        datetimepicker({
                            format: 'd/m/Y H:i',
                            minDate: '0'
                        });


                    if ($("#<%=DDLEmpleado.ClientID%>").val() != "") {
                        $("#FormaCarga").show();
                    }
                    else {
                        //$("#FormaCarga").hide();
                    }
                });
            </script>


            <script>
                function getDireccion(fuente) {
                    var direccion = "";
                    //guardar del lado del servidor si el usuario
                    //dio click en origen o en destino
                    if (fuente == 1) //La dirección es un Origen
                    {

                        direccion = $("#<%=txtOrigen.ClientID%>").val();
                        //11 sur 305
                    } $("#<%=txtEsOD.ClientID%>").val(fuente);

                    $("#<%=txtEsOD.ClientID%>").val(fuente);

                    if (direccion != "") {
                        //Llamamos a la api de google maps
                        //para obtener los datos completos de la dirección
                        var geocoder = new google.maps.Geocoder();

                        geocoder.geocode({ 'address': direccion }, function (results, status) {
                            if (status == google.maps.GeocoderStatus.OK) {
                                //Traemos los datos completos de la dirección
                                console.log(results);
                                console.log("El conteinente es: ");
                                console.log(results[0].address_components[0].long_name);
                                $("#origen").val(results[0].address_components[0].long_name);
                                console.log(status);
                                var numresults = results[0].address_components.length;
                                //Recorremos cada una de las propiedades de address_components
                                for (var indice = 0; indice < numresults; indice++) {
                                    var numresultstypes =
                                        results[0].address_components[indice].types.length;
                                    //Recorremos los tipos de cada componente de la dirección
                                    for (var propiedad = 0; propiedad < numresultstypes; propiedad++) {
                                        //Declarar una variable que nos permita saber ell tipo
                                        // de propiedad que estamos recorriendo
                                        var Tipo = results[0].address_components[indice].types[propiedad]; // ""route""
                                        //Descripcion va a contener el valor de la propiedad // street_number
                                        var Descripcion =
                                            results[0].address_components[indice].long_name; // "Avenida 10 Oriente"
                                        //Validamos cada propiedad para escribirla en el textbox
                                        //que corresponda

                                        switch (Tipo) {

                                            case "route": //Calle
                                                $("#<%=txtCalle.ClientID%>").val(Descripcion);
                                                break;
                                            case "street_number": //Número
                                                $("#<%=txtNumero.ClientID%>").val(Descripcion);
                                                break;
                                            case "sublocality_level_1": //Colonia
                                                $("#<%=txtColonia.ClientID%>").val(Descripcion);
                                                break;
                                            case "locality": //Ciudad
                                                $("#<%=txtCiudad.ClientID%>").val(Descripcion);
                                                break;

                                        }

                                    }
                                }

                                //Asignamos a txtorigen o destino la dirección formateada



                            }
                            else {
                                swal("Error de Google", "Google no obtuvo datos", "warning");
                            }
                        });
                    }
                    else {
                        //Avisamos al usuario que tendrá que capturar
                        //todos los datos
                        swal({
                            title: "¿Estás seguro?",
                            text: "No podemos obtener datos sino proporciona una dirección",
                            type: "warning",
                            showCancelButton: true,
                            confirmButtonClass: "btn-warning",
                            confirmButtonText: "Si, quiero capturar la información",
                            cancelButtonText: "Cancelar",
                            closeOnConfirm: true,
                            closeOnCancel: true
                        }, function (isConfirm) {
                            if (!isConfirm) {
                                $(".modalPanel").hide();
                                $(".bgpanel").hide();

                            }

                        });

                    }
                }

                function prueba() {
                    var calle = $("#<%=txtCalle.ClientID%>").val();
                    var numero = $("#<%=txtNumero.ClientID%>").val();
                    var colonia = $("#<%=txtColonia.ClientID%>").val();
                    var ciudad = $("#<%=txtCiudad.ClientID%>").val();


                    var dirCompleta = calle + " " + numero + " " + colonia + " " + ciudad;

                    var band = $("#<%=txtEsOD.ClientID%>").val();
                    if (band == 1) {
                        $("#<%=txtOrigen.ClientID%>").val(dirCompleta);
                    }


                }

                function LimpiarDatos() {
                    $(".mpanel").val("");
                }


        </script>

            <%--aca vamos a pintar el modal--%>

            <asp:Panel ID="PnlOrigenDestino" Width="500" CssClass="modalPanel" runat="server">
                <div style="width: 90%; margin: 0 auto; margin-top: 20px;">
                    <asp:UpdatePanel ID="UPOrigenDestino" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <div class="container">
                                <div class="col-md-12">
                                    <h4>Guardar direccion</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="<%=txtCalle.ClientID%>">Calle</label>
                                        <asp:TextBox ID="txtCalle" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVtxtCalle" CssClass="text-danger" ControlToValidate="txtCalle" runat="server" ErrorMessage="calle requerida" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="<%=txtNumero.ClientID%>">Numero</label>
                                        <asp:TextBox ID="txtNumero" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" ControlToValidate="txtNumero" runat="server" ErrorMessage="Numero requerido" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="<%=txtColonia.ClientID%>">Colonia</label>
                                        <asp:TextBox ID="txtColonia" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" ControlToValidate="txtColonia" runat="server" ErrorMessage="Colonia requerida" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="<%=txtCiudad.ClientID%>">Calle</label>
                                        <asp:TextBox ID="txtCiudad" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" ControlToValidate="txtCiudad" runat="server" ErrorMessage="Ciudad requerida" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnGuardarDir" CssClass="btn btn-success" runat="server" Text="Guardar" ValidationGroup="POD" formnovalidate="" OnClick="btnGuardarDir_Click" OnClientClick="prueba();" />
                                    </div>
                                </div>

                                <asp:Button ID="btnCancelar" CssClass="btn btn-danger" formnovalidate="" runat="server" Text="Cancelar" OnClientClick="LimpiarDatos();" />

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>


        </div>
    </div>

</asp:Content>
