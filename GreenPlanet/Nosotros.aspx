<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="GreenPlanet.Nosotros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!--Start of testimonial-->
        <section id="testimonial">
            <div class="testimonial_overlay">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="testimonial_header text-center">
                                <h2>Nosotros</h2>
                            </div>
                        </div>
                    </div>
                    <!--End of row-->
                    
                    <section id="carousel">
                        <div class="container">
                            <div class="row">
                                 <div class="container container-nav" >
                                <div class="col-md-12 text-center">
                                 <%--   <div class="carousel slide" id="fade-quote-carousel" data-ride="carousel" data-interval="3000">--%>
                                     <!-- Carousel indicators -->
                            <%--            <ol class="carousel-indicators">
                                            <li data-target="#fade-quote-carousel" data-slide-to="0" class="active"></li>
                                            <li data-target="#fade-quote-carousel" data-slide-to="1"></li>
                                        </ol>--%>
                                        <!-- Carousel items -->
                                        <div class="carousel-inner">
                                            <div class="active item">
                                                <div class="row">
                                                    <div class="col-md-6">
    
                                                        <div class="profile-circle">
                                                            <img src="img/SIMBOLO.jpg" alt="">
                                                        </div>
                                                        <div class="testimonial_content">
                                                           
                                                            <p>Concientizar y educar a  todas las personas sobre la importancia del resguardo del medio ambiente, bajo su colaboración activa en la realización y ejecución de acciones que provoquen un cambio ecológico y con esto obtener un planeta más sustentable, brindando consejos y sugiriendo respuestas inmediatas a situaciones sobre los medios actuales para el reciclaje.</p>
                                                        </div>
     
                                                    </div>

                                                    <div class="col-md-6">
                                                        <div class="profile-circle">
                                                            <img src="img/Visión.jpg" alt="">
                                                        </div>
                                                        <div class="testimonial_content">
                                                         
                                                            <p>Ser la primera organización que establece un servicio que brinde un cambio en la cultura ecológica emergida desde la base de la sociedad. Provocando en ella una conciencia sobre el ambiente que reconozca la importancia de la acción del ser humano en el resguardo del planeta.</p>
                                                        </div>
                                                      
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    <%--</div>--%>
                                </div>
                            </div>
                            <!--End of row-->
                        </div>
                        <!--End of container-->
                            </div>
                    </section>
                         </div>
                    <!--End of carousel-->
                
            </div>
            <!--End of container-->
        </section>
        <!--end of testimonial-->

</asp:Content>
