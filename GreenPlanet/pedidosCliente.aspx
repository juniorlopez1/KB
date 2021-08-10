<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="pedidosCliente.aspx.cs" Inherits="GreenPlanet.pedidosCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" name="myform" runat="server" class="form">

        <h2 class="h2" style="text-align: center">Mis Pedidos</h2>
        <asp:GridView ID="GridView1" name="GridView1" runat="server" class="table table-bordered table-responsive-md table-striped text-center" >
        </asp:GridView>
        <!-- Rutas Pendientes -->
        <div class="form-group row" style="margin-left: 30%; margin-bottom: 5%">
            <div class="col-xs-5">
                <h3 class="labelM" style="text-align: center">* Pide una recolección siempre y cuando no tengas pedidos pendientes ni en proceso *</h3>
            </div>

            <div class="col-xs-3">
                <asp:Button ID="btnSolicitarPedido" name="btnSolicitarPedido" class="btn btn-success btn-lg btnSolicitarPedido" runat="server" Text="Solicitar Pedido" OnClick="btnSolicitarPedido_Click" />
            </div>
        </div>
    </form>

</asp:Content>
