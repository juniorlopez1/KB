<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="solicitudRecoleccion.aspx.cs" Inherits="GreenPlanet.solicitudRecoleccion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="h2" style="text-align:center">Solicitud de recolección hogar</h2>
      
    <form id="form1" name="myform" runat="server" class="form">
        <div class="form-group row" style="margin-left: 20%; margin-top: 3%">
            <div class="col-xs-3">
                <label>Id Cliente</label>
                <input class="form-control" id="inputIdCliente" type="text" value="" runat="server" readonly="true" name="inputIdCliente"/>
            </div>

            <div class="col-xs-3">
                <label>Nombre Cliente</label>
                <input class="form-control" id="inputNombreCliente" type="text" value="" runat="server" readonly="true" name="inputNombreCliente"/>
            </div>
            <div class="col-xs-3">
                <label>Teléfono</label>
                <input class="form-control" id="inputTelefonoCliente" type="text" value="" runat="server" readonly="true" name="inputTelefonoCliente"/>
            </div>
   
        </div>



        <div class="form-group row" style="margin-left: 20%">

            <div class="col-xs-3">
                <label>Provincia</label>
                <input class="form-control" id="inputProvinciaPedido" type="text" value="" runat="server" readonly="true" name="inputProvinciaPedido"  />
            </div>
            <div class="col-xs-3">
                <label>Cantón</label>
                <input class="form-control" id="inputCantonCliente" type="text" value="" runat="server" readonly="true" name="inputCantonCliente"  />
            </div>
            <div class="col-xs-3">
                <label>Distrito</label>
                <input class="form-control" id="inputDistritoPedido" type="text" value="" runat="server" readonly="true" name="inputDistritoPedido" />
            </div>
        </div>

        <div class="form-group row" style="margin-left: 20%; margin-bottom: 5%">

            <div class="col-xs-6">
                <label>Dirección</label>
                <input class="form-control" id="inputDireccionPedido" type="text" value="" runat="server" readonly="true" name="inputDireccionPedido" />
            </div>
            <div class="col-xs-2">
                <label>Fecha</label>
                <input class="form-control" type="text" id="datepicker" name="datepicker"  readonly="true" style=" font-size: 12px;" onblur="javascript: validar()"/>
            </div>
            <div class="col-xs-1">
                 <label>Hora</label>
                <input type="text" id="datetimepicker5" name="datetimepicker5" class="form-control datetime" readonly="true" style=" font-size: 12px;" onblur="javascript: validar()"/>
	

            </div>
        </div>
        
        <div class="container container-nav" style="margin-top:-2%">
            <h3 class="h3" style="text-align: center">Detalles de material a recolectar</h3>
        <table class="table table-bordered table-responsive-md table-striped text-center" id="tableHojas">
            <thead>
                <tr class="table2">
                    <th class="table2"></th>
                    <th class="text-center">Tipo Material</th>
                    <th class="text-center">Cantidad Kg</th>
                    <th class="text-center">Total en hojas</th>

                </tr>
            </thead>

            <tfoot>
                <tr>
                    <td></td>
                    <td>
                        
                    </td>
                    <td>Total de Hojas </td>
                    <td><label id="inputTotalHojas" for="inputTotalHojas" >0</label></td>
                </tr>
            </tfoot>

            <!--Columnas-->
            <tbody>
                <tr> 
                    <td><input type="checkbox" id="checkBoxAluminio" value="1" name="checkBoxAluminio" /></td>
                    <td class="pt-3-half">Latas de aluminio </td>
                    <td class="pt-3-half" >
                        <select id="listaCantidadAluminio" class="dropDownList" name="listaCantidadAluminio" onchange="calcularCliente()"; >
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>                            
                        </select>

                    </td>
                    <td class="pt-3-half">      
                        <label id="inputTotalAluminio" for="inputTotalAluminio" >0</label>                      
                    </td>
                </tr>
                  <tr>
                       <td>
                           <input type="checkbox" id="checkBoxPlastico" value="4"  name="checkBoxPlastico"/>
                       </td>
                    <td class="pt-3-half">Botellas plásticas</td>
                    <td class="pt-3-half">
                         <select id="listaCantidadPlastico" class="dropDownList" name="listaCantidadPlastico" onchange="calcularCliente()";>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>                            
                        </select>
                    </td>
                    <td class="pt-3-half">
                        <label id="inputTotalPlastico">0</label>
                    </td>
                </tr>

                  <tr>
                       <td>
                           <input type="checkbox" id="checkBoxPolietileno" value="5"/>
                       </td>
                    <td class="pt-3-half">Botellas de polietileno</td>
                    <td class="pt-3-half" >
                         <select id="listaCantidadPolietileno" class="dropDownList" name="listaCantidadPolietileno" onchange="calcularCliente()";>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>                            
                        </select>
                    </td>
                    <td class="pt-3-half">
                        <label id="inputTotalPolietileno">0</label>
                    </td>
                </tr>

                 <tr>
                      <td>
                          <input type="checkbox" id="checkBoxVidrio" value="6"/>
                      </td>
                    <td class="pt-3-half">Botellas de vídrio</td>
                    <td class="pt-3-half">
                         <select id="listaCantidadVidrio" class="dropDownList" name="listaCantidadVidrio" onchange="calcularCliente()";>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>                            
                        </select>
                    </td>
                    <td class="pt-3-half">
                        <label id="inputTotalVidrio">0</label>
                    </td>
                </tr>

                <tr>
                     <td>
                         <input type="checkbox" id="checkBoxCarton" value="2"/>

                     </td>
                    <td class="pt-3-half">Cartón</td>
                    <td class="pt-3-half">
                         <select id="listaCantidadCarton" class="dropDownList"  name="listaCantidadCarton" onchange="calcularCliente()";>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>                            
                        </select>
                    </td>
                    <td class="pt-3-half">
                        <label id="inputTotalCarton">0</label>
                    </td>
                </tr>
        
                <tr>
                    <td>
                        <input type="checkbox" id="checkBoxPapel" value="3"/>
                    </td>
                    <td class="pt-3-half">Papel</td>
                    <td class="pt-3-half">
                         <select id="listaCantidadPapel" class="dropDownList"  name="listaCantidadPapel" onchange="calcularCliente()";>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>                            
                        </select>
                    </td>
                    <td class="pt-3-half">
                        <label id="inputTotalPapel">0</label>
                    </td>
                </tr>
               
                 <tr>
                    <td>
                   
                        <input type="checkbox" id="checkBoxTetrabrik" value="7"/>
                    </td>
                    <td class="pt-3-half">Tetrabrik</td>
                    <td class="pt-3-half" >
                         <select id="listaCantidadTetrabrik" class="dropDownList"  name="listaCantidadTetrabrik" onchange="calcularCliente()";>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>                            
                        </select>
                    </td>
                    <td class="pt-3-half">
                        <label id="inputTotalTetrabrik">0</label>
                    </td>
                </tr>

            </tbody>
        </table>

       <button type="button" class="btn btn-primary btn-lg btnEnviarPedido" id="btnEnviarPedido"  onserverclick="reg_cliente" name="btnEnviarPedido" runat="server" ClientIDMode="Static">Enviar Pedido</button>
    
    
   
    </form>
        

</asp:Content>
