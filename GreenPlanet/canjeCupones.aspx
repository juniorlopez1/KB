<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="canjeCupones.aspx.cs" Inherits="GreenPlanet.canjeCupones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            margin-right: 42;
        }
    </style>

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

        <h2 class="h2" style="text-align: center">Lista de cupones disponibles</h2>
        <div class="container container-box-shadow2" runat="server" id="container">
           
                <div class="col-xs-3">
                    <label>Hojas Disponibles</label>
                    <input class="form-control" id="lbl_hojas" style="text-align:center" type="text" runat="server" readonly="true" name="lbl_hojas" />
             
              </div>
            </div>
        
           <div class="container container-box-shadow2">
            
              <asp:DataList ID="DataList1" runat="server" BorderColor="Aqua" DataKeyField="idCupones" DataSourceID="SqlDataSource2" Height="332px" RepeatDirection="Horizontal" Width="1230px" RepeatColumns="3" CellSpacing="5" CssClass="auto-style1" OnItemCommand="DataList1_ItemCommand">
                    <EditItemStyle BorderColor="#FFCCCC" BorderWidth="4px" />
                    <ItemTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td class="text-center">
                                    <asp:Image ID="Image1" runat="server" CssClass="auto-style2" ImageUrl='<%# Eval("imagen") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Comercio:
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombreComercio") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Valor en hojas:
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("CantidadHojas") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("DescCupon") %>'></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("idCupones") %>' Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="text-center">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-success btn-lg btnCanjeCupon" Text="Canjear Cupón" />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                
               <br />
                <br />
               </div>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DB_Green_PlanetConnectionString %>" SelectCommand="SELECT CU.idCupones, CO.nombreComercio, DC.imagen, DC.DescCupon, DC.CantidadHojas FROM Cupones AS CU INNER JOIN DetalleCupon AS DC ON CU.idCupones = CU.idCupones AND CU.idDetalleCupon = DC.idDetalleCupon INNER JOIN ComercioAfiliado AS CO ON DC.idComercioAfiliado = CO.idComercioAfiliado WHERE (CU.idEstadosCupon = 1)"></asp:SqlDataSource>
            
      <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" style="margin-top: 5%">
            <div class="modal-dialog modal-dialog-centered" role="document">

                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Cupones - Green Planet</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group row" style="margin-left: 20%">
                            <div class="col-xs-8">
                                <label>Código Numérico: </label>
                                <asp:TextBox ID="inputCupon" class="form-control" runat="server" name="inputCupon" readonly="true"></asp:TextBox>
                            </div>
                             <div class="col-xs-8" style="margin-top: 5%">
                                <label>Fecha Vencimiento: </label>
                                <asp:TextBox ID="inputVencimiento" class="form-control" runat="server" name="inputVencimiento" readonly="true"></asp:TextBox>
                            </div>
                        </div>
                        
                            <div class="form-group row" style="margin-left: 20%; margin-bottom: 5%; " >
                                <div class="col-xs-8">
                                    <label>Código QR: </label>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                         </div>
                 
                    <div class="modal-footer">

                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>

                    </div>
                </div>
            </div>
        </div>
   

    </form>
</asp:Content>
