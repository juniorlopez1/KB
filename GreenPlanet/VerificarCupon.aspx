<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VerificarCupon.aspx.cs" Inherits="GreenPlanet.VerificarCupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>

        <section class="container">
            <h2 class="h2" style="text-align: center;">Comercio Afiliado</h2>
            <div class="row">
                <div class="form-group">
                    <label for="exampleFormControlTextarea1">Codigo cupon</label>
                    <input type="text" class="form-control" name="buscar_codigo" />
                </div>
                <div class="col-md-4 col-md-offset-8">
                    <button type="button" class="btn btn-primary" id="display_btn">
                        Buscar
                    </button>
                </div>
            </div>

            <asp:gridview id="Cupones_Grid" runat="server"
                datasourceid="Cupones_Linq" autogeneratecolumns="False"
                cssclass="table table-bordered table-responsive-md table-striped text-center"
                showheaderwhenempty="true"
                onrowcommand="Cupones_Grid_RowCommand">
                <HeaderStyle CssClass="text-center" />
                <RowStyle CssClass="pt-3-half" />
                <Columns>
                    <asp:BoundField DataField="idCupones" HeaderText="ID Cupon" ReadOnly="True" />
                    <asp:BoundField DataField="codigoCupon" HeaderText="Codigo" ReadOnly="True" />
                    <asp:BoundField DataField="DescCupon" HeaderText="Descripcion" ReadOnly="True" />
                    <asp:BoundField DataField="fechaIngreso" HeaderText="Fecha Ingreso" ReadOnly="True" />
                    <asp:BoundField DataField="fechaVencimiento" HeaderText="Fecha Vencimiento" ReadOnly="True" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Estado" ReadOnly="True" />
                    <asp:BoundField DataField="idCliente" HeaderText="ID Cliente" ReadOnly="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <input type="button" runat="server" visible='<%# Eval("Descripcion").ToString() == "Inventario" %>'
                                value="Detalles" onserverclick="Details_ServerClick" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:gridview>
            <asp:linqdatasource id="Cupones_Linq" runat="server"
                contexttypename="GreenPlanet.GreenClassesDataContext" entitytypename=""
                onselecting="Cupones_Linq_Selecting">
            </asp:linqdatasource>
            <!-- Modal -->
            <div class="modal show" id="detalle_cupon" tabindex="-1"
                role="dialog" aria-labelledby="registro_cobrarModalLabel"
                aria-hidden="true" runat="server" >
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Detalle cupon</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body modal-body-responsive">
                            <div class="form-group">
                                <label for="exampleFormControlTextarea1">Descripcion</label>
                                <textarea class="form-control" id="desc_cupon" rows="3"
                                    runat="server" disabled="disabled"></textarea>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Fecha de adquirido</label>
                                <input type="date" class="form-control" id="adquir_cupon"
                                    runat="server" disabled="disabled" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Fecha de vencimiento</label>
                                <input type="date" class="form-control" id="venc_cupon"
                                    runat="server" disabled="disabled" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Estado</label>
                                <input type="text" class="form-control"
                                    id="estado_cupon" runat="server"
                                    disabled="disabled" />
                            </div>
                            <img src="#" id="imagen_cupon" runat="server" />
                            <div class="form-group">
                                <label for="exampleInputEmail1">Cedula del cliente</label>
                                <input type="text" class="form-control"
                                    id="cedula" runat="server"
                                    disabled="disabled" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Nombre del cliente</label>
                                <input type="text" class="form-control"
                                    id="nombre" runat="server"
                                    disabled="disabled" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            <button type="button" class="btn btn-primary">Canjearlo</button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
