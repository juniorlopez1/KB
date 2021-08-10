<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="registro_colaboradores.aspx.cs" Inherits="GreenPlanet.registro_colaboradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="css/responsive.css" rel="stylesheet"/>
        <link rel="stylesheet" href="css/font-awesome.min.css"/>
        <link href="css/style.css" rel="stylesheet" />
        <link rel="stylesheet" type="text/css" href="css/animate.min.css"/>
    <script src="scripts/controles.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="wel_header" style="margin-top:3%">
        <h3>Registro Colaboradores</h3>
    </div>
    <div class="container container-box-shadow">

        <div class="row">

            <div class="col-6 col-md-4">

            </div>
            <div class="col-6 col-md-4" style="margin-bottom:2%">
                <div class="input-group">
                    <input type="text" id="txt_bus" name="txt_bus" runat="server" class="form-control" placeholder="Buscar Colaborador..." maxlength="16" onkeypress ="return ValidarNumeros(event)" />
                    <span class="input-group-btn">
        <button class="btn btn-success" runat="server" type="submit" onserverclick="buscar_colaborador">Buscar</button>
      </span>
                </div>
            </div>
        </div>
        <div class="row">

            
            <div class="form-group col-md-6">
                <label for="txt_ced">Cédula</label>
                <input type="text" runat="server" class="form-control" id="txt_ced" name="txt_ced" placeholder="Cédula" required="required" maxlength="16" onkeypress ="return ValidarNumeros(event)" />
            </div>

            <div class="form-group col-md-6">
                <label for="txt_name">Nombre</label>
                <input type="text" class="form-control" runat="server" id="txt_name" name="txt_name" placeholder="Nombre" required="required" onkeypress ="return lettersOnly(event)" />
            </div>

             <div class="form-group col-md-6">
                <label for="txt_name_afi">Apellidos</label>
                <input type="text" class="form-control" id="txt_ape" runat="server" name="txt_ape" placeholder="Apellidos" required="required" onkeypress ="return lettersOnly(event)"/>
            </div>

             <div class="form-group col-md-6">
                <label for="txt_username">Nombre de Usuario</label>
                <input type="text" class="form-control" id="txt_username" runat="server" name="txt_username" placeholder="Nombre de Usuario" required="required" onkeypress ="return lettersOnly(event)"/>
            </div>

            <div class="form-group col-md-6">
                <label for="txt_tel">Telefono</label>
                <input type="text" class="form-control" id="txt_tel" runat="server" name="txt_tel" placeholder="Telefono" required="required" maxlength="8" onkeypress ="return ValidarNumeros(event)" />
            </div>

            <div class="form-group col-md-6">
                <label for="txt_correo">Correo Electronico</label>
                <input type="email" class="form-control" id="txt_correo" runat="server" name="txt_correo" placeholder="Correo Electronico" required="required" />
            </div>

            <div class="form-group col-md-6">
                <label for="txt_password">Contraseña</label>
                <input type="password" class="form-control" id="txt_password" runat="server" name="txt_password" placeholder="Contraseña" />
            </div>
            <div class="form-group col-md-6">

                <label for="listbox1">Rol</label>
                <asp:DropDownList ID="listbox1" runat="server" CssClass="form-control" OnSelectedIndexChanged="listbox1_SelectedIndexChanged" AutoPostBack="True">
                         <asp:ListItem Text="Administrador" Value="1" />
                         <asp:ListItem Text="Secretaria" Value="2" />
                         <asp:ListItem Text="Recolector" Value="5" />
                </asp:DropDownList>

                 <asp:Label ID="lbl_provincia" runat="server" Text="Provincia"></asp:Label>
                   <asp:DropDownList ID="drop_provincia" runat="server" CssClass="form-control" OnSelectedIndexChanged="listbox2_SelectedIndexChanged">
                </asp:DropDownList>

                 <label for="DropDownList2">Estado</label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Activo" Value="true" />
                    <asp:ListItem Text="Inactivo" Value="false" />
                </asp:DropDownList>

            </div>

        </div>

        <input type="submit" class="btn btn-primary" runat="server" onserverclick="guardar_afi" value="Guardar" id="btn_guardar" />
        <input type="submit" class="btn btn-primary" runat="server" onserverclick="act_afi" value="Actualizar" id="btn_act" />
        <input type="submit" class="btn btn-primary" runat="server" onclick="return borrar_campos()" value="Cancelar" id="btn_borrar" />

    </div>

</form>
</asp:Content>
