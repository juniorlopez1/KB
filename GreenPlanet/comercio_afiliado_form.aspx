<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="comercio_afiliado_form.aspx.cs" Inherits="GreenPlanet.comercio_afiliado_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="css/responsive.css" rel="stylesheet"/>
        <link rel="stylesheet" href="css/font-awesome.min.css"/>
        <link href="css/style.css" rel="stylesheet" />
        <link rel="stylesheet" type="text/css" href="css/animate.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <form id="form1" runat="server">
<div class="wel_header" style="margin-top:3%">
    <h3>Comercio Afiliado</h3>
</div>
<div class="container container-box-shadow">

    <div class="row">

        <div class="col-6 col-md-4">

        </div>
        <div class="col-6 col-md-4" style="margin-bottom:2%">
            <div class="input-group">
                <input type="text" class="form-control" runat="server" id="txt_buscar" placeholder="Buscar Afiliado..." />
                <span class="input-group-btn">
        <button class="btn btn-success" type="submit" runat="server" onserverclick="buscar_afiliado">Buscar</button>
      </span>
            </div>
        </div>
    </div>
    <div class="row">

        <div class="form-group col-md-6">
            <label for="txt_username_afi">Nombre de Usuario</label>
            <input type="text" class="form-control" id="txt_username_afi" runat="server" placeholder="Nombre de Usuario" required="required"  />
        </div>

        <div class="form-group col-md-6">
            <label for="txt_name_afi">Nombre del comercio afiliado</label>
            <input type="text" class="form-control" id="txt_name_afi" runat="server" placeholder="Nombre del comercio afiliado" required="required"  />
        </div>

        <div class="form-group col-md-6">
            <label for="inputelefono">Telefono</label>
            <input type="text" class="form-control" id="txt_tel_afi" runat="server" placeholder="Telefono" required="required" maxlength="8" onkeypress ="return ValidarNumeros(event)" />
        </div>

        <div class="form-group col-md-6">
            <label for="txt_correo">Correo Electronico</label>
            <input type="email" class="form-control" id="txt_correo" runat="server" placeholder="Correo Electronico" required="required" />
        </div>     
        
        
        <div class="form-group col-md-6">
             <label for="txt_password">Contraseña</label>
             <input type="password" class="form-control" id="txt_password" runat="server" placeholder="Contraseña" required="required" />
        </div>       
     

      <div class="form-group col-md-6">
     
      <label for="DropDownList2">Estado</label>
      <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" >
      <asp:ListItem Text="Activo" Value="true" />
          <asp:ListItem Text="Inactivo" Value="false" />
      </asp:DropDownList>

            </div>

    </div>

    <input type="submit" class="btn btn-primary" runat="server" onserverclick="guardar_afi" value="Guardar" id="btn_guardar" />
    <input type="submit" class="btn btn-primary" runat="server" onserverclick="act_afi" value="Actualizar" id="btn_act" />
     <input type="submit" class="btn btn-primary" runat="server" onserverclick="cancelar" value="Cancelar" id="btn_borrar" />
   
</div>

          </form>
</asp:Content>
