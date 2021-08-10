<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="GreenPlanet.Inventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="Inventario_Form" runat="server">
        <ul class="nav nav-tabs" id="myTab" role="tablist">
            <li class="nav-item active">
                <a class="nav-link active" id="inv-tab" data-toggle="tab" href="#cont_inv" role="tab" aria-controls="home" aria-selected="true">Inventario</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="cuentas-tab" data-toggle="tab" href="#cont_cuentas" role="tab" aria-controls="profile" aria-selected="false">Cuentas por cobrar</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="cupones-tab" data-toggle="tab" href="#cont_cupones" role="tab" aria-controls="profile" aria-selected="false">Cupones</a>
            </li>
        </ul>
        <div class="tab-content" id="myTabContent">
            <div class="tab-pane active" id="cont_inv" role="tabpanel" aria-labelledby="home-tab">
                <section class="container">
                    <h2 class="h2" style="text-align: center;">Inventario materiales</h2>
                    <div class="row">
                        <div class="col-md-4 col-md-offset-8">
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#registro_cuentaXcobrar">
                                Registrar Cuenta por cobrar
                            </button>
                        </div>
                    </div>

                    <!-- Modal -->
                    <div class="modal fade" id="registro_cuentaXcobrar" tabindex="-1" role="dialog" aria-labelledby="registro_cobrarModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <form id="cuentas_form">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Registro cuenta por cobrar</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body modal-body-responsive">
                                        <div class="form-group">
                                            <label for="exampleFormControlSelect1">Seleccione un material</label>
                                            <select class="form-control" name="salida_material" id="salida_material" required>
                                                <option value="1">Latas de alumunio</option>
                                                <option value="2">Carton</option>
                                                <option value="3">Papel</option>
                                                <option value="4">Botellas plasticas</option>
                                                <option value="5">Botellas de polietileno</option>
                                                <option value="6">Botellas de vidrio</option>
                                                <option value="7">Tetra brik</option>
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <label for="salida_cantidad">Cantidad de materiales</label>
                                            <input type="number" class="form-control" min="1" step="1"
                                                title="Ingrese solo numeros enteros mayores a 0"
                                                name="salida_cantidad" id="salida_cantidad"
                                                placeholder="Ingrese la cantidad a retirar" required="required" />
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group mb-3">
                                                <span class="input-group-addon" id="basic-addon1">₡</span>
                                                <input type="number" class="form-control" step="1"
                                                    placeholder="Ingrese el dinero recibido" aria-label="Username"
                                                    min="0" title="Ingrese solo valores mayor o igual a 0" aria-describedby="basic-addon1"
                                                    required="required"
                                                    name="salida_monto" id="salida_monto" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="salida_cantidad">Fecha de salida</label>
                                            <input type="date" class="form-control"
                                                name="salida_fecha" id="salida_fecha"
                                                required="required" />
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        <button type="button" class="btn btn-primary" id="crear_cuentas" runat="server"
                                            onclick="if(!$('#salida_material')[0].reportValidity()
                                                            || !$('#salida_cantidad')[0].reportValidity()
                                                            || !$('#salida_monto')[0].reportValidity()
                                                            || !$('#salida_fecha')[0].reportValidity()) { return false;}"
                                            onserverclick="crear_cuentas_ServerClick">
                                            Guardar</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                    <asp:GridView ID="Materiales_Grid" runat="server"
                        DataSourceID="Materiales_Linq" AutoGenerateColumns="False" DataKeyNames="idMaterial"
                        CssClass="table table-bordered table-responsive-md table-striped text-center"
                        ShowHeaderWhenEmpty="true">
                        <HeaderStyle CssClass="text-center" />
                        <RowStyle CssClass="pt-3-half" />
                        <Columns>
                            <asp:BoundField DataField="idMaterial" HeaderText="ID Material" ReadOnly="True" SortExpression="idMaterial" />
                            <asp:BoundField DataField="descripcionMaterial" HeaderText="Descripción Material" SortExpression="descripcionMaterial" />
                            <asp:BoundField DataField="peso" HeaderText="Peso" SortExpression="peso" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="Materiales_Linq" runat="server"
                        ContextTypeName="GreenPlanet.GreenClassesDataContext" EntityTypeName=""
                        OnSelecting="Materiales_Linq_Selecting">
                    </asp:LinqDataSource>
                </section>
            </div>
            <div class="tab-pane" id="cont_cuentas" role="tabpanel" aria-labelledby="profile-tab">
                <section class="container">
                    <h2 class="h2" style="text-align: center;">Cuentas por cobrar</h2>

                    <asp:GridView ID="Cuentas_Grid" runat="server"
                        DataSourceID="Cuentas_Linq" AutoGenerateColumns="False" DataKeyNames="idCuentasXcobrar"
                        CssClass="table table-bordered table-responsive-md table-striped text-center"
                        ShowHeaderWhenEmpty="true">
                        <HeaderStyle CssClass="text-center" />
                        <RowStyle CssClass="pt-3-half" />
                        <Columns>
                            <asp:BoundField DataField="idCuentasXcobrar" HeaderText="ID Cuenta por Cobrar" ReadOnly="True" SortExpression="idMaterial" />
                            <asp:BoundField DataField="descripcionMaterial" HeaderText="Descripción Material" SortExpression="descripcionMaterial" />
                            <asp:BoundField DataField="pesoEntregado" HeaderText="Peso Entregado" SortExpression="peso" />
                            <asp:BoundField DataField="monto" HeaderText="Monto recibido" SortExpression="monto" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="Cuentas_Linq" runat="server"
                        ContextTypeName="GreenPlanet.GreenClassesDataContext" EntityTypeName=""
                        OnSelecting="Cuentas_Linq_Selecting">
                    </asp:LinqDataSource>
                </section>
            </div>
            <div class="tab-pane" id="cont_cupones" role="tabpanel" aria-labelledby="profile-tab">
                <section class="container">
                    <h2 class="h2" style="text-align: center;">Cupones</h2>
                    <div class="row">
                        <div class="col-md-4 col-md-offset-8">
                            <div class="col">
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#registro_cupones">
                                    Crear Cupon
                                </button>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="registro_cupones" tabindex="-1" role="dialog" aria-labelledby="registro_cuponesModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Registro de cupon</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body modal-body-responsive">
                                    <div class="form-group">
                                        <label for="desc_cupon">ID Comercio afiliado</label>
                                        <input type="text" class="form-control"
                                            id="comerc_cupon" name="comerc_cupon"
                                            placeholder="Ingrese el ID del comercio"
                                            maxlength="10"
                                            required="required" />
                                    </div>
                                    <div class="form-group">
                                        <label for="desc_cupon">Descripcion del cupon</label>
                                        <input type="text" class="form-control"
                                            id="desc_cupon" name="desc_cupon"
                                            placeholder="Ingrese la descripcion del cupon"
                                            maxlength="100"
                                            required="required" />
                                    </div>
                                    <div class="form-group">
                                        <label for="desc_cupon">Valor en hojas</label>
                                        <input type="number" step="1" class="form-control"
                                            id="cant_hojas" name="cant_hojas"
                                            placeholder="Ingrese solamente enteros positivos para el valor del cupon"
                                            min="150" max="4000"
                                            required="required" />
                                    </div>
                                    <div class="form-group">
                                        <label for="desc_cupon">Cantidad de cupones a generar</label>
                                        <input type="number" step="1" class="form-control"
                                            id="cant_cupones" name="cant_cupones"
                                            placeholder="Ingrese la cantidad de cupones a generar"
                                            min="1" max="100"
                                            required="required" />
                                    </div>
                                    <div class="form-group">
                                        <label for="desc_cupon">Cantidad de cupones a generar</label>
                                        <asp:FileUpload ID="img_cupon_asp" accept=".jpg" CssClass="form-control"
                                            required="required" runat="server" />
                                        <p class="help-block">Example block-level help text here.</p>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                    <button type="button" class="btn btn-primary" id="crear_cupon" runat="server"
                                        onclick="if(!$('#comerc_cupon')[0].reportValidity()
                                                            || !$('#desc_cupon')[0].reportValidity()
                                                            || !$('#cant_hojas')[0].reportValidity()
                                                            || !$('#cant_cupones')[0].reportValidity()
                                                            || !$('#ContentPlaceHolder1_img_cupon_asp')[0].reportValidity()) { return false;}"
                                        onserverclick="crear_cupones_ServerClick">
                                        Guardar</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:GridView ID="Cupones_Grid" runat="server"
                        DataSourceID="Cupones_Linq" AutoGenerateColumns="False"
                        CssClass="table table-bordered table-responsive-md table-striped text-center"
                        DataKeyNames="idCupones"
                        ShowHeaderWhenEmpty="true">
                        <HeaderStyle CssClass="text-center" />
                        <RowStyle CssClass="pt-3-half" />
                        <Columns>
                            <asp:BoundField DataField="idCupones" HeaderText="ID Cupon" />
                            <asp:BoundField DataField="idDetalleCupon" HeaderText="ID Detalle Cupon" ReadOnly="True" />
                            <asp:BoundField DataField="nombreComercio" HeaderText="Nombre Comercio" />
                            <asp:BoundField DataField="DescCupon" HeaderText="Descripcion" />
                            <asp:BoundField DataField="CantidadHojas" HeaderText="Cantidad de hojas" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Estado" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="Cupones_Linq" runat="server"
                        ContextTypeName="GreenPlanet.GreenClassesDataContext" EntityTypeName=""
                        OnSelecting="Cupones_Linq_Selecting">
                    </asp:LinqDataSource>
                </section>
            </div>
        </div>
    </form>


</asp:Content>
