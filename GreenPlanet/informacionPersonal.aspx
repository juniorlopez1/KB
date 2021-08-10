<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="informacionPersonal.aspx.cs" Inherits="GreenPlanet.informacionPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css/responsive.css" rel="stylesheet"/>
        <link rel="stylesheet" href="css/font-awesome.min.css"/>
        <link href="css/style.css" rel="stylesheet" />
        <link rel="stylesheet" type="text/css" href="css/animate.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

    <div class="wel_header" style="margin-top:3%">
        <h3>Informacion Personal</h3>
    </div>

    <div class="container container-nav">

        <div class="row">

            <div class="col-xs-6">
                <h2>Menu cliente</h2>
                <div class="float-left">
                    <a href="cambiocontrasenna.aspx">Cambio de contraseña</a>
                </div>

            </div>

            <div class="col-xs-6">

                <div class=" form-horizontal">
                    <div class="form-group">
                        <label for="lbl_ced" class="control-label">Cedula:</label>
                        <asp:Label ID="lbl_ced" runat="server" Text="Label" CssClass="control-label"></asp:Label>
                    </div>

                    <div class="form-group">
                        <label for="lbl_nombre" class="control-label">Nombre:</label>
                        <asp:Label ID="lbl_nombre" runat="server" Text="Label" CssClass="control-label"></asp:Label>
                    </div>

                    <div class="form-group">
                        <label for="lbl_ape" class="control-label">Apellidos:</label>
                        <asp:Label ID="lbl_ape" runat="server" Text="Label" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label for="lbl_correo" class="control-label">Correo:</label>
                        <asp:Label ID="lbl_correo" runat="server" Text="Label" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label for="lbl_tel" class="control-label">Telefono:</label>

                        <asp:Label ID="lbl_tel" runat="server" Text="Label" CssClass="control-label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label for="lbl_dir" class="control-label">Direccion:</label>
                        <asp:Label ID="lbl_dir" runat="server" Text="Label" CssClass="control-label"></asp:Label>
                    </div>
                </div>

            </div>

        </div>
    </div>

</form>

</asp:Content>
