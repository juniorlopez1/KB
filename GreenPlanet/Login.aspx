<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="GreenPlanet.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/animate.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-nav">

        <div class="row">

            <div class="col-12 col-md-7 text-center">
                <h2>Bienvenido al KM</h2>
                <p>
                    Ingresa a nuestro sitio para empezar a compartir y guardar informacion.
               
                </p>

            </div>

            <div class="col-6 col-md-4">
                <ul class="nav-links nav-tabs nav" id="myTab">
                    <li class="nav-item text-normal normal-link active" role="presentation">
                        <a class="nav-link text-normal normal-link active">Iniciar Sesion</a>
                    </li>

                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="Registrarse" role="tabpanel" aria-labelledby="registrarse_tab">
                        <form id="inicio_frm" runat="server">

                            <div class="form-group">
                                <label for="txt_username">Usuario</label>
                                <input type="text" class="form-control" name="txt_username" id="txt_username" placeholder="Nombre de usuario" required="required" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword1">Contraseña</label>
                                <input type="password" class="form-control" id="txt_contrasenna" placeholder="Contraseña" required="required" runat="server" />
                            </div>
                            <!--  <div class="form-group">
                                <label for="exampleFormControlSelect1">Seleccione su tipo de cuenta</label>
                                <select class="form-control" name="tipo_cuenta">
                                    <option>Cliente</option>
                                    <option>Comercio Afiliado</option>
                                    <option>Colaborador</option>
                                </select>
                            </div> -->
                            <div class="float-right">
                                <a href="">Olvidaste tu contraseña?</a>
                            </div>
                            <div></div>
                            <button type="submit" class="btn btn-success btn-block" runat="server" onserverclick="ing_cliente" value="ing" id="btn_ing">Ingresar</button>
                        </form>
                    </div>
                </div>
            </div>

        </div>

    </div>
    <script>
        $(function () {
            $('#myTab li:last-child a').tab('show')
        })
    </script>
</asp:Content>
