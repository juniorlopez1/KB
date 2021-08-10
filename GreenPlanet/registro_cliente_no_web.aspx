<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="registro_cliente_no_web.aspx.cs" Inherits="GreenPlanet.registro_cliente_no_web" %>
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
    <h3>Cliente Centro de acopio</h3>
</div>
<div class="container container-box-shadow">

    <div class="row">


         <div class="form-group">
                                    <label class="label-bold" for="txt_user_cedula">
                                        Cedula
                                    </label>
                                    <input class="form-control" runat="server" placeholder="Cedula" type="text" name="txt_user_cedula" id="txt_user_cedula" maxlength="16" onkeypress ="return ValidarNumeros(event)" />

                                </div>


                                <div class="form-group">
                                    <label class="label-bold" for="txt_user_name">
                                        Nombre de usuario
                                    </label>
                                    <input class="form-control" runat="server" placeholder="Nombre de usuario" type="text" name="txt_user_name" id="txt_user_name" onkeypress ="return lettersOnly(event)"/>

                                </div>

                                <div class="form-group">
                                    <label class="label-bold" for="new_name">
                                        Nombre
                                    </label>
                                    <input class="form-control" runat="server" placeholder="Nombre" type="text" name="new_name" id="new_name" onkeypress ="return lettersOnly(event)" />

                                </div>
                                <div class="form-group">
                                    <label for="txt_p_ape">Apellidos</label>
                                    <input class="form-control" runat="server" placeholder="Apellidos" type="text" name="txt_p_ape" id="txt_p_ape" onkeypress ="return lettersOnly(event)" />

                                </div>


                                <!--  inicio direccion -->

                                <div class="form-group">
                                    <label for="listbox1">Provincia</label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="changed" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label for="listbox1">Canton</label>
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="changed_distri">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label for="listbox1">Distrito</label>
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                    </asp:DropDownList>

                                </div>

                                <div class="form-group">
                                    <label for="exampleFormControlTextarea1">Dirección</label>
                                    <textarea class="form-control" runat="server" name="exampleFormControlTextarea1" id="exampleFormControlTextarea1" rows="3" required="required"></textarea>
                                </div>

                                <!-- fin seccion direccion  -->

                                <div class="form-group">
                                    <label for="exampleInputPassword2">Contraseña</label>
                                    <input type="password" runat="server" class="form-control" name="exampleInputPassword2" id="exampleInputPassword2" placeholder="Contraseña" required="required" />
                                </div>
                             

                                <div></div>
                                <button type="submit" class="btn btn-success btn-block" runat="server" onserverclick="reg_cliente" value="reg" id="btn_reg">Registrar</button>
                           

    
</div>
    </div>
          </form>
</asp:Content>
