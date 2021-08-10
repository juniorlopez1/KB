<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="recuperacion_de_contraseña.aspx.cs" Inherits="GreenPlanet.recuperacion_de_contraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container container-nav">
        <div class="row">
            <div class="col-12 col-md-7">
                <h2>Bienvenido al reciclaje Inteligente</h2>
                <p>
                    Ingresa a nuestro sitio para empezar a reciclar de una manera divertida y segura.
                </p>
            </div>
            <form id="form2" runat="server">
                <div class="col-6 col-md-4">
                    <ul class="nav-links nav-tabs nav" role="tablist">
                        <li class="nav-item" role="presentation">
                            <a class="nav-link disabled normal-link text-normal">Restablecer Contraseña</a>
                        </li>
                    </ul>
                    <ul class="nav-links nav-tabs nav" id="myTab" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" id="correo-tab" data-toggle="tab" href="#correo" role="tab" aria-controls="home" aria-selected="true">Correo</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="sms-tab" data-toggle="tab" href="#sms" role="tab" aria-controls="profile" aria-selected="false">SMS</a>
                        </li>
                    </ul>
                    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade active" id="correo" role="tabpanel" aria-labelledby="home-tab">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Correo</label>
                                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Correo" required="required" />
                            </div>
                            <div></div>
                            <button type="submit" class="btn btn-success btn-block" id="reset_pwd_email" runat="server" onserverclick="reset_pwd_email_ServerClick">Restablecer Contraseña</button>
                        </div>
                        <div class="tab-pane fade" id="sms" role="tabpanel" aria-labelledby="profile-tab">

                            <div class="form-group">
                                <label for="exampleInputEmail1">Numero de telefono</label>
                                <input type="tel" class="form-control" id="phoneNumber" placeholder="88888888"
                                    title="Por favor ingrese un numero telefonico valido" pattern="[2-8][0-9]{7}" required="required" />
                            </div>
                            <div></div>
                            <button type="submit" class="btn btn-success btn-block" id="reset_pwd_sms" runat="server">Restablecer Contraseña</button>
                        </div>
                    </div>
                    <div class="tab-content">
                        <div class="tab-pane active" id="Restablecer" role="tabpanel" aria-labelledby="Restablecer-tab">
                        </div>
                    </div>
                    <div>
                        <p>
                            <span>Ya tienes usuario y contraseña?
                      <a href="Registrarse.aspx">Registrarse</a>
                            </span>
                        </p>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
