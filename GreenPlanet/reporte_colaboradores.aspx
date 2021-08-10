<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="reporte_colaboradores.aspx.cs" Inherits="GreenPlanet.reporte_colaboradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/controles.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- grid view css = table table-striped-->
    
       <form id="form1" runat="server">
<div class="wel_header" style="margin-top:3%">
    <h3>Colaboradores</h3>
</div>
<div class="container container-box-shadow">
    <div class="row">
             <p>En esta seccion se puede ver el registro de todos los colaboradores.
              </p>
            <p>
                   Para hacer una busqueda ingrese la cedula de un colaborador en el campo de abajo.
            </p>
        <div class="col-6 col-md-4">

        </div>
        <div class="col-6 col-md-4" style="margin-bottom:2%">
       
            <div class="input-group">
                <input type="text" id="txt_busqueda" runat="server" class="form-control" placeholder="Buscar Colaborador por Cédula..." maxlength="16" onkeypress ="return ValidarNumeros(event)" />
                <span class="input-group-btn">
        <button class="btn btn-success" runat="server" onserverclick="buscar_col" type="submit">Buscar</button>
      </span>
            </div>
        </div>
    </div>
     <div class="row">

         <div class=" table-responsive">

         <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover">
         
         </asp:GridView>
             </div>

         </div>
    </div>
           </form>



</asp:Content>
