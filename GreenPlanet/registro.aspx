<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="GreenPlanet.registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container container-nav">

        <div class="row">

            <div class="col-12 col-md-7 text-center">
                <h2>Bienvenido al reciclaje Inteligente</h2>
                <p>
                    Ingresa a nuestro sitio para empezar a reciclar de una manera divertida y segura.
                </p>

            </div>

            <div class="col-6 col-md-4">
                <ul class="nav-links nav-tabs nav" id="myTab" role="tablist">
                    <li class="nav-item" role="presentation">
                        <a class="nav-link text-normal normal-link" id="registrarse_tab"
                            runat="server" onserverclick="ver_iniciar">Iniciar Sesion</a>
                     </li>
                    <li class="nav-item text-normal normal-link active" role="presentation">
                        <a class="nav-link active text-normal normal-link">Registro</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="Registro" role="tabpanel" aria-labelledby="Registro-tab">
                        <form id="registro_frm" runat="server">
                            <div class="form-group">
                                <label class="label-bold" for="txt_user_cedula">
                                    Cedula
                                </label>
                                <input class="form-control" placeholder="Cedula" type="text" name="txt_user_cedula" id="txt_user_cedula" />

                            </div>


                            <div class="form-group">
                                <label class="label-bold" for="txt_user_name">
                                    Nombre de usuario
                                </label>
                                <input class="form-control" placeholder="Nombre de usuario" type="text" name="txt_user_name" id="txt_user_name" />

                            </div>

                            <div class="form-group">
                                <label class="label-bold" for="new_user_name">
                                    Nombre
                                </label>
                                <input class="form-control" placeholder="Nombre" type="text" name="new_user_name" id="new_user_name" />

                            </div>
                            <div class="form-group">
                                <label for="txt_p_ape">Apellidos</label>
                                <input class="form-control" placeholder="Apellidos" type="text" name="txt_p_ape" id="txt_p_ape" />

                            </div>

                            <div class="form-group">
                                <label for="exampleInputEmail1">Correo Electronico</label>
                                <input type="email" class="form-control" name="exampleInputEmail2" id="exampleInputEmail2" placeholder="Correo Electronico" required="required" />
                            </div>
                            <div class="form-group">
                                <label for="txt_telefono">Teléfono</label>
                                <input class="form-control" pattern="[0-9]{8}" title="La longitud mínima es de 8 Numeros" placeholder="Teléfono" type="text" name="txt_telefono" id="txt_telefono" />

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
                                <textarea class="form-control" name="exampleFormControlTextarea1" id="exampleFormControlTextarea1" rows="3" required="required"></textarea>
                            </div>

                            <!-- fin seccion direccion  -->

                            <div class="form-group">
                                <label for="exampleInputPassword1">Contraseña</label>
                                <input type="password" class="form-control" name="exampleInputPassword2" id="exampleInputPassword2" placeholder="Contraseña" required="required" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword3">Vuelva a introducir su Contraseña</label>
                                <input type="password" class="form-control" name="exampleInputPassword3" id="exampleInputPassword3" placeholder="Contraseña" required="required" />
                            </div>

                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" />
                                    <a href="recuperacion_de_contraseña.aspx">Terminos y condiciones</a>
                                </label>
                                <p>
                                    Al aceptar los terminos y condiciones de greenPlanet(nose que mas puede ir aqui)
                                </p>
                            </div>
                            <div></div>
                            <button type="submit" class="btn btn-success btn-block" runat="server" onserverclick="reg_cliente" value="reg" id="btn_reg">Registrar</button>
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
