<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="agendaRecolector.aspx.cs" Inherits="GreenPlanet.agendaRecolector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" name="myform" runat="server" class="form">
        
            <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <!-- <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.2/jquery.min.js'></script>-->
        <script src="js/jquery-1.12.3.min.js"></script>

        <!--Counter UP Waypoint-->
        <script src="js/waypoints.min.js"></script>
        <!--Counter UP-->
        <script src="js/jquery.counterup.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.9/dist/js/bootstrap-select.min.js"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.9/dist/css/bootstrap-select.min.css" />
        <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.9/dist/js/i18n/defaults-*.min.js"></script>
        <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
        <link rel="stylesheet" href="/resources/demos/style.css" />
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script src="javascripts/jquery.datetimepicker.js"></script>

        <script src="javascripts/jquery.datetimepicker.full.js"></script>
        <script src="jquery.datetimepicker.full.min.js"></script>
        <link rel="stylesheet" type="text/css" href="javascripts/jquery.datetimepicker.css"/>
        <script src="javascripts/JavaScript.js"></script>
        
        


        <!--Isotope-->
        <script src="js/isotope/min/scripts-min.js"></script>
        <script src="js/isotope/cells-by-row.js"></script>
        <script src="js/isotope/isotope.pkgd.min.js"></script>
        <script src="js/isotope/packery-mode.pkgd.min.js"></script>
        <script src="js/isotope/scripts.js"></script>


        <!--Back To Top-->
        <script src="js/backtotop.js"></script>


        <!--JQuery Click to Scroll down with Menu-->
        <script src="js/jquery.localScroll.min.js"></script>
        <script src="js/jquery.scrollTo.min.js"></script>
        <!--WOW With Animation-->
        <script src="js/wow.min.js"></script>
        <!--WOW Activated-->
        <script>
            new WOW().init();
        </script>


        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="js/bootstrap.min.js"></script>
        <!-- Custom JavaScript-->
        <script src="js/main.js"></script>


     
        

        <!-- Rutas pendientes -->
        <h2 class="h2">Mis Pedidos</h2>
        <asp:GridView ID="GridViewMisPedidos" runat="server" name="GridViewMisPedidos" class="table table-bordered table-responsive-md table-striped text-center" OnRowCommand="GridViewMisPedidos_RowCommand">
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="button" >
                    <ControlStyle CssClass="btn btn-success btn-rounded btn-sm my-0" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
      
        <!-- Mis Rutas -->

        <!-- Rutas pendientes -->
        <h2 class="h2" id="Labsael1">Pedidos sin asignar</h2>
        <asp:GridView ID="GridViewSinAsignar" name="GridViewSinAsignar" runat="server" class="table table-bordered table-responsive-md table-striped text-center" OnRowCommand="GridViewSinAsignar_RowCommand">

            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="button" AccessibleHeaderText="mybtn">
                    <ControlStyle CssClass="btn btn-primary btn-rounded btn-sm my-0"  />
                </asp:CommandField>
            </Columns>
        </asp:GridView>


        <!-- Rutas Pendientes -->


        <!-- Modal -->
        <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">

                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Información pedidos - Gren Planet</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <!--Detalles cliente-->

                        <div class="form-group row" style="margin-left: 1%">

                            <div class="col-xs-3">
                                <label>Número pedido</label>
                                <input class="form-control" id="inputNumeroPedido" type="text" value="121" readonly="true" />
                            </div>
                            <div class="col-xs-3">
                                <label>Nombre Cliente</label>
                                <input class="form-control" id="inputNombreCliente" type="text" value="Kevin" readonly="true" />
                            </div>
                            <div class="col-xs-3">
                                <label>Fecha</label>
                                <input class="form-control" id="inputFechaPedido" type="text" value="05 Agosto, 2019" readonly="true" />
                            </div>
                        </div>

                        <div class="form-group row" style="margin-left: 1%">

                            <div class="col-xs-3">
                                <label>Provincia</label>
                                <input class="form-control" id="inputProvinciaPedido" type="text" value="San José" readonly="true" />
                            </div>
                            <div class="col-xs-3">
                                <label>Cantón</label>
                                <input class="form-control" id="inputCantonCliente" type="text" value="Central" readonly="true" />
                            </div>
                            <div class="col-xs-3">
                                <label>Distrito</label>
                                <input class="form-control" id="inputDistritoPedido" type="text" value="Pavas" readonly="true" />
                            </div>
                        </div>

                        <div class="form-group row" style="margin-left: 1%; margin-bottom: 5%">

                            <div class="col-xs-9">
                                <label>Dirección</label>
                                <input class="form-control" id="inputDireccionPedido" type="text" value="Clinica Óscar Arias, 200m sur y 50m este (Casa marrón)" readonly="true" />
                            </div>

                        </div>

                        <!-- Rutas pendientes -->
                        <h2 class="h2" style="text-align: center">Acreditar Hojas</h2>
                        <table class="table table-bordered table-responsive-md table-striped text-center" id="tableHojas">
                            <thead>
                                <tr class="table2">
                                    <th class="text-center">Tipo Material</th>
                                    <th class="text-center">Cantidad Kg</th>
                                    <th class="text-center">Total en hojas</th>

                                </tr>
                            </thead>

                            <tfoot>
                                <tr>
                                    <td>
                                        <span>
                                            <button type="button" class="btn btn-success btn-rounded btn-sm my-0" id="btnCalcular">
                                                Calcular total</button></span>
                                    </td>
                                    <td>Total de Hojas </td>
                                    <td></td>
                                </tr>
                            </tfoot>

                            <!--Columnas-->
                            <tbody>
                                <tr>
                                    <td class="pt-3-half">Tetrabrick</td>
                                    <td class="pt-3-half" contenteditable="true">2</td>
                                    <td class="pt-3-half"></td>
                                </tr>

                                <tr>
                                    <td class="pt-3-half">Aluminio</td>
                                    <td class="pt-3-half" contenteditable="true">4</td>
                                    <td class="pt-3-half"></td>
                                </tr>


                                <tr>
                                    <td class="pt-3-half">Plástico</td>
                                    <td class="pt-3-half" contenteditable="true">3</td>
                                    <td class="pt-3-half"></td>
                                </tr>
                                <tr>
                                    <td class="pt-3-half">Cartón</td>
                                    <td class="pt-3-half" contenteditable="true">2</td>
                                    <td class="pt-3-half"></td>
                                </tr>
                                <tr>
                                    <td class="pt-3-half">Papel</td>
                                    <td class="pt-3-half" contenteditable="true">3</td>
                                    <td class="pt-3-half"></td>
                                </tr>

                            </tbody>
                        </table>

                        <!-- Rutas Pendientes -->
                        <div class="form-group row" style="margin-left: 1%; margin-bottom: 2%">

                            <div class="col-xs-4">
                                <label>Estado de recolección</label>
                                <select class="selectpicker" data-style="btn-primary" id="inputEstadoRecoleccion">
                                    <option>Pendiente</option>
                                    <option>Procesando</option>
                                    <option>Rechazada</option>
                                    <option>Gestionada</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group row" style="margin-left: 1%; margin-bottom: 5%">
                            <div class="col-xs-9">
                                <label>Mensaje recolección</label>
                                <textarea class="form-control rounded-0" id="inputMensajeRecoleccion" rows="3"></textarea>
                            </div>
                        </div>


                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-danger" id="btnQuitarPedido">Quitar Pedido</button>
                        <button type="button" class="btn btn-success" id="btnFinalizarPedido">Finalizar Pedido</button>
                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>
