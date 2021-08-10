<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="cambiocontrasenna.aspx.cs" Inherits="GreenPlanet.cambiocontrasenna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css/responsive.css" rel="stylesheet"/>
        <link rel="stylesheet" href="css/font-awesome.min.css"/>
        <link href="css/style.css" rel="stylesheet" />
        <link rel="stylesheet" type="text/css" href="css/animate.min.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <form id="form1" runat="server">
  <div class="wel_header" style="margin-top:3%">
    <h3>Cambio de contraseña</h3>
</div>

    <div class="container container-nav">

        <div class="row">

            <div class="col-xs-6">
                <h2>Menu cliente</h2>
                <div class="float-left">
                    <a href="informacionPersonal.aspx">Informacion Personal</a>
                </div>

            </div>

            <div class="col-xs-6">

                <div class=" form-horizontal">

                 <div class="form-group">
                        <label for="exampleInputPassword1">Contraseña Actual</label>
                        <input type="password" class="form-control" name="exampleInputPassword1" id="exampleInputPassword1" pattern="[A-Za-z0-9]{8,16}" title="La longitud mínima es de 8 caracteres y como maximo 16." placeholder="Contraseña" required="required" />
                        
                   
                      </div>
                     <div class="form-group">
                        <label for="exampleInputPassword1">Nueva Contraseña</label>
                        <input type="password" class="form-control" name="exampleInputPassword2" id="exampleInputPassword2" pattern="[A-Za-z0-9]{8,16}" title="La longitud mínima es de 8 caracteres y como maximo 16." placeholder="Contraseña" required="required" />
                        
                   
                      </div>
                    
                      <div></div>
           <button type="submit" class="btn btn-success btn-block" runat="server" onserverclick="act_cliente" value="Actualizar" id="btn_act">Restablecer Contraseña</button>
                      
   

                </div>

            </div>

        </div>
    </div>

         </form>
</asp:Content>
