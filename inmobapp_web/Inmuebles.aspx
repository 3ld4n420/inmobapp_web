<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inmuebles.aspx.cs" Inherits="inmobapp_web.Inmuebles" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <br />
    <br />
    <div runat="server" id="formulario">
        <div class="card border-primary mb-12">
          <div class="card-header">DATOS BASICOS DEL INMUEBLE</div>
          <div class="card-body">
            <table style="margin: auto; width: 90%; padding: 10px;">
            <tr>
                <td hidden>
                    <label>Codigo inmueble:</label><br />
                    <asp:TextBox ID="txtINM_ID" runat="server" CssClass="col-form-label border-primary col-lg-10" ForeColor="Black"/>
                </td>
                <td>
                    <label>Propietario Inmueble:</label><br />
                    <asp:DropDownList ID="ddlPropietario" runat="server" CssClass="list-group-item border-primary col-lg-10 text-dark bg-white"></asp:DropDownList>
                </td>
                <td>
                    <label>Matricula:</label><br />
                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="col-form-label border-primary col-lg-10" ForeColor="Black"/>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Modalidad:</label><br />
                    <asp:DropDownList ID="ddlModalidad" runat="server" CssClass="col-form-label border-primary col-lg-10"  ForeColor="Black"></asp:DropDownList>
                </td>
                <td>
                    <label>Tipo:</label><br />
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="list-group-item border-primary col-lg-10 text-dark bg-white"></asp:DropDownList>
                </td>
                <td>
                    <label>Estrato:</label><br />
                    <asp:DropDownList ID="ddlEstrato" runat="server" CssClass="list-group-item border-primary col-lg-10 text-dark bg-white"></asp:DropDownList>
                </td>
                <td>
                    <label>Area:</label><br />
                    <asp:TextBox ID="txtArea" runat="server" CssClass="col-form-label border-primary col-lg-10" ForeColor="Black"/>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Municipio:</label><br />
                    <asp:DropDownList ID="ddlMpio" runat="server" CssClass="list-group-item border-primary col-lg-10 text-dark bg-white"></asp:DropDownList>
                </td>
                <td>
                    <label>Lugar:</label><br />
                    <asp:DropDownList ID="ddlLugares" runat="server" CssClass="list-group-item border-primary col-lg-10 text-dark bg-white"></asp:DropDownList>
                </td>
                <td>
                    <label>Sector:</label><br />
                    <asp:DropDownList ID="ddlBarrio" runat="server" CssClass="list-group-item border-primary col-lg-10 text-dark bg-white"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <label>Direccion :</label><br />
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="col-form-label border-primary col-lg-10" Style="max-width: 100%; width: 71%;" ForeColor="Black"/>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Valor Renta:</label><br />
                    <asp:TextBox ID="txtValorVenta" runat="server" CssClass="col-form-label border-primary col-lg-10" ForeColor="Black"/>
                </td>
                <td>
                    <label>Valor Arriendo:</label><br />
                    <asp:TextBox ID="txtValorArriendo" runat="server" CssClass="col-form-label border-primary col-lg-10" ForeColor="Black"/>
                </td>
                <td>
                    <label>Valor Administracion:</label><br />
                    <asp:TextBox ID="txtValorAdmon" runat="server" CssClass="col-form-label border-primary col-lg-10" ForeColor="Black"/>
                </td>
                <td>
                    <label>Valor Impuesto:</label><br />
                    <asp:TextBox ID="txtValorImpuesto" runat="server" CssClass="col-form-label border-primary col-lg-10" ForeColor="Black"/>
                </td>
            </tr>
        </table>

          </div>
        </div>

        <div style="margin: auto; width: 30%; padding: 10px;">
            <asp:Button CssClass="btn btn-success" ID="btnInsert" runat="server"
                Text="Crear" OnClick="btnInsert_Click" />
             <asp:Button CssClass="btn btn-warning" ID="btnUpdate" runat="server"
                Text="Actualizar" OnClick="btnUpdate_Click" />
             <asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server"
                Text="Borrar" OnClick="btnDelete_Click" />
             <asp:Button CssClass="btn btn-secondary" ID="btnCancel" runat="server"
                 Text="Cancelar" OnClick="btnCancel_Click" />
        </div>

        <div>

            <asp:RequiredFieldValidator class="alert alert-danger" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtMatricula" ><strong>Por favor digite la Matricula del inmueble</strong> </asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtArea" ValidationExpression="^\d+(\.\d\d)?$"><strong>Ingrese correctamente el área. Ejemplo: 100.08</strong> </asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:RequiredFieldValidator class="alert alert-danger" ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDireccion"><strong>Por favor digite la dirección</strong> </asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator5" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtValorArriendo" ValidationExpression="^\d+(\.\d\d)?$"><strong>Digite correctamente el valor del Arriendo</strong> </asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator class="alert alert-danger" ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtValorVenta"><strong>Digite correctamente el valor de la Renta</strong> </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator4" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtValorVenta" ValidationExpression="^\d+(\.\d\d)?$"><strong>Digite correctamente el valor de la Renta</strong> </asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator6" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtValorAdmon" ValidationExpression="^\d+(\.\d\d)?$"><strong>Digite correctamente el valor de la Administración</strong> </asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator7" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtValorImpuesto" ValidationExpression="^\d+(\.\d\d)?$"><strong>Digite correctamente el valor del Impuesto</strong> </asp:RegularExpressionValidator>

        </div>
    </div>
    <br />
    <div style="margin: auto; width: 90%;">
        <h3>LISTADO GENERAL DE INMUEBLES</h3>

    </div>

    <asp:GridView CssClass="table table-bordered" ID="gvDatos" runat="server" CellPadding="3" GridLines="Horizontal"
        DataKeyNames="INM_ID" AutoGenerateColumns="false" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" HeaderStyle-BackColor="#ff3399" OnRowCommand="gvDatos_RowCommand" OnRowEditing="gvDatos_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Seleccionar">
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-primary" ID="lbtnSelect" runat="server" CommandName="Select" Text="Seleccionar" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="INM_ID" HeaderText="ID" ReadOnly="true" />
            <asp:TemplateField HeaderText="Propietario" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblPropietario" Text='<%#Eval("INM_CLI_Propietario") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Matricula">
                <ItemTemplate>
                    <asp:Label ID="lblMatricula" Text='<%#Eval("INM_MatriculaInmobiliaria") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Direccion">
                <ItemTemplate>
                    <asp:Label ID="lblDireccion" Text='<%#Eval("INM_Direccion") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID Barrio" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblBarrio" Text='<%#Eval("INM_BARR_Barrio") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Barrio">
                <ItemTemplate>
                    <asp:Label ID="lblBarrio_Des" Text='<%#Eval("Barrio") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Municipio">
                <ItemTemplate>
                    <asp:Label ID="lblMpio" Text='<%#Eval("INM_MUN_Municipio") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lugar Residencia">
                <ItemTemplate>
                    <asp:Label ID="lblLugar" Text='<%#Eval("INM_LUGRES_LugarResidencia") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID Modalidad" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblModalidad" Text='<%#Eval("INM_INMMOD_Modalidad") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modalidad">
                <ItemTemplate>
                    <asp:Label ID="lblModalidad_Des" Text='<%#Eval("Modalidad") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblTipo" Text='<%#Eval("INM_INMTIPO_Tipo") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Vivienda">
                <ItemTemplate>
                    <asp:Label ID="lblTipo_Des" Text='<%#Eval("Tipo") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID Estrato" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblEstrato" Text='<%#Eval("INM_EST_Estrato") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estrato">
                <ItemTemplate>
                    <asp:Label ID="lblEstrato_Des" Text='<%#Eval("Estrato") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblArea" Text='<%#Eval("INM_Area") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor Venta" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblValorVenta" Text='<%#Eval("INM_ValorVenta") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor Arriendo" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblValorArriendo" Text='<%#Eval("INM_ValorArriendo") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor Admon" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblValorAdmon" Text='<%#Eval("INM_ValorAdministracion") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor Impuesto" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblValorImpuesto" Text='<%#Eval("INM_ValorImpuestoPredial") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Inventario">
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-success" ID="lbtnInventario" runat="server" CommandName="Inventario" Text="Inventario" />
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>
    </asp:GridView>
    <br />

    <div style="margin: 0 auto; width: 10%">
        <asp:Button CssClass="btn btn-primary" ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
    </div>
    <br />
    <br />
    <br />
<div style="margin: 0 auto; width: 30%" >
            <h3>INVENTARIO DEL INMUEBLE</h3>
    </div>

    <div style="margin: 0 auto; width: 80%" id="inventario"  runat="server">

        <h4>INVENTARIO ENTRADA</h4>

        <asp:GridView ID="gvEntrada" runat="server" CssClass="table table-bordered" HeaderStyle-BackColor="#ff3399" AutoGenerateColumns="false"
            CellPadding="3" AutoGenerateEditButton="True" OnRowCancelingEdit="gvEntrada_RowCancelingEdit" OnRowEditing="gvEntrada_RowEditing" OnRowUpdating="gvEntrada_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblId" Text='<%#Eval("Id") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Elemento">
                    <ItemTemplate>
                        <asp:Label ID="lblElemento" Text='<%#Eval("Elemento") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:Label ID="lblCantidad" Text='<%#Eval("Cantidad") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlCantidad" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Material">
                    <ItemTemplate>
                        <asp:Label ID="lblMaterial" Text='<%#Eval("Material") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlMaterial" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">Madera</asp:ListItem>
                            <asp:ListItem Value="2">Aluminio</asp:ListItem>
                            <asp:ListItem Value="3">Ceramica</asp:ListItem>
                            <asp:ListItem Value="4">Vidrio</asp:ListItem>
                            <asp:ListItem Value="5">Hierro</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" Text='<%#Eval("Estado") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">Bueno</asp:ListItem>
                            <asp:ListItem Value="2">Regular</asp:ListItem>
                            <asp:ListItem Value="3">Malo</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observaciones">
                    <ItemTemplate>
                        <asp:Label ID="lblObs" Text='<%#Eval("Observaciones") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtObservaciones" runat="server" Text='<%# Eval("Observaciones" ) %>'></asp:TextBox>
                    </EditItemTemplate>

                </asp:TemplateField>



            </Columns>

        </asp:GridView>

        <h4>INVENTARIO SALA</h4>

        <asp:GridView ID="gvSala" runat="server" CssClass="table table-bordered" HeaderStyle-BackColor="#ff3399" AutoGenerateColumns="false"
            CellPadding="3" AutoGenerateEditButton="True" OnRowCancelingEdit="gvSala_RowCancelingEdit" OnRowEditing="gvSala_RowEditing" OnRowUpdating="gvSala_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblId" Text='<%#Eval("Id") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Elemento">
                    <ItemTemplate>
                        <asp:Label ID="lblElemento" Text='<%#Eval("Elemento") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:Label ID="lblCantidad" Text='<%#Eval("Cantidad") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlCantidad" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Material">
                    <ItemTemplate>
                        <asp:Label ID="lblMaterial" Text='<%#Eval("Material") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlMaterial" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">Madera</asp:ListItem>
                            <asp:ListItem Value="2">Aluminio</asp:ListItem>
                            <asp:ListItem Value="3">Ceramica</asp:ListItem>
                            <asp:ListItem Value="4">Vidrio</asp:ListItem>
                            <asp:ListItem Value="5">Hierro</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" Text='<%#Eval("Estado") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">Bueno</asp:ListItem>
                            <asp:ListItem Value="2">Regular</asp:ListItem>
                            <asp:ListItem Value="3">Malo</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observaciones">
                    <ItemTemplate>
                        <asp:Label ID="lblObs" Text='<%#Eval("Observaciones") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtObservaciones" runat="server" Text='<%# Eval("Observaciones" ) %>'></asp:TextBox>
                    </EditItemTemplate>

                </asp:TemplateField>



            </Columns>


        </asp:GridView>
        <h4>INVENTARIO COMEDOR</h4>


        <asp:GridView ID="gvComedor" runat="server" CssClass="table table-bordered" HeaderStyle-BackColor="#ff3399" AutoGenerateColumns="false"
            CellPadding="3" AutoGenerateEditButton="True" OnRowCancelingEdit="gvComedor_RowCancelingEdit" OnRowEditing="gvComedor_RowEditing" OnRowUpdating="gvComedor_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblId" Text='<%#Eval("Id") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Elemento">
                    <ItemTemplate>
                        <asp:Label ID="lblElemento" Text='<%#Eval("Elemento") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:Label ID="lblCantidad" Text='<%#Eval("Cantidad") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlCantidad" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Material">
                    <ItemTemplate>
                        <asp:Label ID="lblMaterial" Text='<%#Eval("Material") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlMaterial" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">Madera</asp:ListItem>
                            <asp:ListItem Value="2">Aluminio</asp:ListItem>
                            <asp:ListItem Value="3">Ceramica</asp:ListItem>
                            <asp:ListItem Value="4">Vidrio</asp:ListItem>
                            <asp:ListItem Value="5">Hierro</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" Text='<%#Eval("Estado") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDown">
                            <asp:ListItem Value="1">Bueno</asp:ListItem>
                            <asp:ListItem Value="2">Regular</asp:ListItem>
                            <asp:ListItem Value="3">Malo</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observaciones">
                    <ItemTemplate>
                        <asp:Label ID="lblObs" Text='<%#Eval("Observaciones") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtObservaciones" runat="server" Text='<%# Eval("Observaciones" ) %>'></asp:TextBox>
                    </EditItemTemplate>

                </asp:TemplateField>



            </Columns>


        </asp:GridView>
    </div>


</asp:Content>
