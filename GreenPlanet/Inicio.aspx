<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="GreenPlanet.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <!--Start of welcome section-->
        <section id="welcome">
            <div class="container-nav">
                <div class="row">
                    <div class="col-md-12">
                        <div class="wel_header">
                            <h2>Nuestras metas</h2>
                            <p>Somos una empresa altamente comprometida con el medio ambiente, entre nuestras metas estan:</p>
                        </div>
                    </div>
                </div>
                <!--End of row-->
                <div class="row">
                    <div class="col-md-3">
                        <div class="item">
                            <div class="single_item">
                                <div class="item_list">
                                    <div class="welcome_icon">
                                        <i class="fa fa-leaf"></i>
                                    </div>
                                    <h4>Reducir</h4>
                                    <p>Disminuir considerablemente el volumen de residuos generados.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--End of col-md-3-->
                    <div class="col-md-3">
                        <div class="item">
                            <div class="single_item">
                                <div class="item_list">
                                    <div class="welcome_icon">
                                        <i class="fa fa-refresh"></i>
                                    </div>
                                    <h4>Reciclar</h4>
                                    <p>Utilizar como materia prima un material de desecho, con el fin de generar un producto nuevo.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--End of col-md-3-->
                    <div class="col-md-3">
                        <div class="item">
                            <div class="single_item">
                                <div class="item_list">
                                    <div class="welcome_icon">
                                        <i class="fa fa-cog"></i>
                                    </div>
                                    <h4>Reutilizar</h4>
                                    <p>Darle un segundo uso a los productos de desecho.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="item">
                            <div class="single_item">
                                <div class="item_list">
                                    <div class="welcome_icon">
                                        <i class="fa fa-recycle"></i>
                                    </div>
                                    <h4>Recuperar</h4>
                                    <p>Usar un residuo para producir otro nuevo, intentando que el tratamiento sea lo menos dañino posible con el medio ambiente.</p>
                                </div>
                            </div>
                        </div>
                    </div>
     
                </div>
                <!--End of row-->
            </div>
            <!--End of container-->
        </section>
        <!--end of welcome section-->
</asp:Content>
