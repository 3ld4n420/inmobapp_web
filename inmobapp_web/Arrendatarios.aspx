<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Arrendatarios.aspx.cs" Inherits="inmobapp_web.Arrendatarios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <br />
    <br />
    <br />

    <div runat="server" id="formulario">
        <div class="card border-primary mb-12">
        <div class="card-header">DATOS BASICOS DEL ARRENDATARIO</div>
        <div class="card-body">
        <table  style="margin: auto; width: 90%; padding: 10px;" >
            <tr>
                <td hidden>
                    <label>Codigo:</label><br />
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="list-group-item col-lg-10" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>Nombres y Apellidos :</label><br />
                    <asp:TextBox ID="txtNombres" runat="server" CssClass="col-form-label border-primary col-lg-10"  style=" max-width: 100%; width: 92%;" />
                </td>
                <td>
                    <label>Tipo identificación:</label><br />
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="list-group-item border-primary col-lg-10 text-dark bg-white"></asp:DropDownList>
                </td>                
                <td>
                    <label>Identificacion:</label><br />
                    <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="col-form-label border-primary col-lg-10" />
                </td>
            </tr>
            <tr>
               
               <td colspan="3">
                   <br />
                    <label>Direccion de Residencia:</label><br />
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="col-form-label border-primary col-lg-10" style=" max-width: 100%; width: 95%;" />
                </td>
              
                <td>
                    <br />
                     <label>Telfono Fijo :</label><br />
                    <asp:TextBox ID="txtFijo" runat="server" CssClass="col-form-label border-primary col-lg-10"  />
                
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <label>Telefono Movil :</label><br />
                    <asp:TextBox ID="txtCelular" runat="server" CssClass="col-form-label border-primary col-lg-10" style="max-width: 100%; width: 92%;" />
                </td>
                  <td colspan="2">
                      <br />
                    <label>Correo Electronico:</label><br />
                     <asp:TextBox ID="txtMail" runat="server" CssClass="col-form-label border-primary col-lg-10" style="max-width: 100%; width: 75%;"  />

                </td>                
             
            </tr>
        </table>
      </div>
    </div>

         


        <div style="margin: auto; width: 36%; padding: 10px;">
             <asp:Button CssClass="btn btn-success" ID="btnInsert" runat="server"
                Text="Crear" OnClick="btnInsert_Click" />
             <asp:Button CssClass="btn btn-warning" ID="btnUpdate" runat="server"
                Text="Actualizar" OnClick="btnUpdate_Click" />
             <asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server"
                Text="Borrar" OnClick="btnDelete_Click" />
             <asp:Button CssClass="btn btn-secondary" ID="btnCancel" runat="server"
                 Text="Cancelar" OnClick="btnCancel_Click" />
        </div>

        <div >
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator3" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtNombres" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"><strong>Escriba correctamente sus nombres y apellidos</strong></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><strong>Correo electrónico incorrecto</strong></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^\d+$" ControlToValidate="txtIdentificacion"><strong>Digite correctamente su identificación</strong> </asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator4" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^\d+$" ControlToValidate="txtFijo"><strong>Digite correctamente su teléfono fijo</strong></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            <asp:RegularExpressionValidator class="alert alert-danger" ID="RegularExpressionValidator5" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^\d+$" ControlToValidate="txtCelular"><strong>Digite correctamente su teléfono móvil</strong></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
        </div>

    </div>

    <br />
    <asp:GridView CssClass="table table-bordered" ID="gvDatos" runat="server" CellPadding="3" GridLines="Horizontal"
        DataKeyNames="Codigo" AutoGenerateColumns="False" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" HeaderStyle-BackColor="#ff3399">


        <Columns>

            <asp:TemplateField HeaderText="Seleccionar">
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-primary" ID="lbtnSelect" runat="server" CommandName="Select" Text="Seleccionar" />
                </ItemTemplate>

            </asp:TemplateField>


            <asp:BoundField DataField="Codigo" HeaderText="ID" ReadOnly="true" />
            <asp:TemplateField HeaderText="Codigo">
                <ItemTemplate>
                    <asp:Label ID="lblTipoId" Text='<%#Eval("TipoId") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numero Id">
                <ItemTemplate>
                    <asp:Label ID="lblNumeroId" Text='<%#Eval("NumeroId") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombres">
                <ItemTemplate>
                    <asp:Label ID="lblNombres" Text='<%#Eval("Nombres") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Direccion">
                <ItemTemplate>
                    <asp:Label ID="lblDireccion" Text='<%#Eval("Direccion") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefono">
                <ItemTemplate>
                    <asp:Label ID="lblTelefono" Text='<%#Eval("Telefono") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Celular">
                <ItemTemplate>
                    <asp:Label ID="lblCelular" Text='<%#Eval("Celular") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="lblEmail" Text='<%#Eval("Email") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
         
        </Columns>

<HeaderStyle BackColor="#ff3399"></HeaderStyle>
    </asp:GridView>
    <br />

    <div style="margin: 0 auto; width: 10%">

        <asp:Button CssClass="btn btn-primary" ID="btnNuevo" runat="server"
            Text="Nuevo" OnClick="btnNuevo_Click" Width="82px" />
    </div>


</asp:Content>

