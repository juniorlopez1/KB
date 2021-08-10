<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="reg_documento.aspx.cs" Inherits="GreenPlanet.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/responsive.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link href="css/style.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/animate.min.css" />
    <script src="scripts/controles.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form_reg_doc" name="form_reg_doc" runat="server" class="form">
        <div class="wel_header" style="margin-top: 3%">
            <h3>Registro de Pagina</h3>
        </div>
        <div class="container container-box-shadow">

            <div class="row">

                <div class="form-group">
                    <label class="label-bold" for="txt_titulo">
                        Titulo
                                   
                    </label>
                    <input class="form-control" runat="server" placeholder="Titulo" type="text" name="txt_titulo" id="txt_titulo" />

                </div>


                <div class="form-group">
                    <label class="label-bold" for="txt_contenido">
                        Contenido         
                    </label>
                    <textarea class="form-control" runat="server" id="txt_contenido" name="txt_contenido" rows="25" cols="50"></textarea>
                </div>


                <div class="col-xs-2">
                    <label for="txt_fecha_creacion">fecha creacion</label>
                    <input class="form-control" runat="server" placeholder="" type="text" name="txt_fecha_creacion" id="txt_fecha_creacion" disabled readonly />

                </div>
                <div class="col-xs-2">
                    <label for="txt_version">version</label>
                    <input class="form-control" runat="server" placeholder="" type="text" name="txt_version" id="txt_version" value="1" disabled readonly />
                    
                </div>

                <div></div>
               
                 <button type="submit" class="btn btn-success btn-block" runat="server" onserverclick="reg_documento" value="reg" id="btn_reg" style="margin-top:8%" >Registrar</button>
            </div>
        </div>

    </form>

</asp:Content>
