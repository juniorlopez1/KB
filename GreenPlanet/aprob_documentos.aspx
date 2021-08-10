<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="aprob_documentos.aspx.cs" Inherits="GreenPlanet.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/responsive.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link href="css/style.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/animate.min.css" />
    <script src="scripts/controles.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form_aprob_doc" name="form_aprob_doc" runat="server" class="form">
         <div class="wel_header" style="margin-top: 3%">
            <h3>Aprobacion de documentos</h3>
        </div>
     <div class="container container-box-shadow">

          <!-- Rutas pendientes -->
        <h2 class="h2">Documentos sin aprobar</h2>
        <asp:GridView ID="GridViewDocs" runat="server" name="GridViewDocs" class="table table-bordered table-responsive-md table-striped text-center" OnRowCommand="GridViewDoc_sin_aprobar_RowCommand">
            <Columns>
                <asp:CommandField ShowSelectButton="true" ButtonType="button" SelectText="Aprobar" >
                    <ControlStyle CssClass="btn btn-success btn-rounded btn-sm my-0" />
                </asp:CommandField>
               
              
            </Columns>
        </asp:GridView>
        <!--    <asp:ButtonField ButtonType="Button" CommandName="ver" Text="Ver" >
                   <ControlStyle CssClass="btn btn-success btn-rounded btn-sm my-0" />
                </asp:ButtonField>-->

         </div>
        </form>

</asp:Content>
