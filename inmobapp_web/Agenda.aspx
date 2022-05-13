<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="inmobapp_web.Agenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <asp:Label ID="lblMsg" runat="server"></asp:Label>

    <div runat="server" id="formulario">

        <h4>AGENDAR CITAS</h4>

         <table  style="margin: auto 0px auto auto; width: 90%; padding: 10px;" >
            <tr>
                <td hidden>
                    <label>Codigo:</label><br />
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="list-group-item col-lg-10" />
                </td>
            </tr>
            <tr>
                <td style="width: 41%">
                    <label>Titulo de la cita:</label><br />
                    <asp:TextBox ID="txtNombreCita" runat="server" CssClass="list-group-item"  style=" max-width: 100%; width: 94%; left: 0px; top: 0px;" />
                </td>
            </tr>
            <tr>
               
               <td colspan="2" style="height: 57px">
                    <label>Descripcion:</label><br />
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="list-group-item" style=" max-width: 100%; width: 78%; top: 0px; left: 0px; height: 52px;" />
                </td>
            </tr>
            <tr>
                <td style="height: 58px; width: 41%">
                    <label>Nombre del cliente :</label><br />
                    <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="list-group-item" style="max-width: 100%; width: 97%; left: 0px; top: 0px;" />
                </td>
                <td style="height: 58px">
                    <label>Correo Electronico:</label><br/>
                    <asp:TextBox ID="txtCorreoCliente" runat="server" CssClass="list-group-item" style="max-width: 100%; width: 75%; left: 5px; top: 0px;"  />
                </td>                
             
            </tr>
            <tr>
                 <td style="height: 50px">
                    <label>Fecha de Registro:</label><br/>
                    <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="list-group-item" style="max-width: 100%; width: 75%; left: 5px; top: 0px;"  />
                </td>   
                 <td style="height: 50px">
                    <label>Fecha de Finalización:</label><br/>
                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="list-group-item" style="max-width: 100%; width: 75%; left: 5px; top: 0px;"  />
                </td>   
                
            </tr>

        </table>



        <div style="margin: auto; width: 38%; padding: 10px;">

            <asp:Button CssClass="btn btn-success" ID="btnInsert" runat="server"
                Text="Crear" OnClick="btnInsert_Click" />
            <asp:Button CssClass="btn btn-warning" ID="btnUpdate" runat="server"
                Text="Actualizar" OnClick="btnUpdate_Click" />
            <asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server"
                Text="Borrar" OnClick="btnDelete_Click" />
            <asp:Button CssClass="btn btn-secondary" ID="btnCancel" runat="server"
                Text="Cancelar" OnClick="btnCancel_Click" />
        </div>



    </div>





    <br />
    <asp:GridView CssClass="table table-bordered" ID="gvDatos" runat="server" CellPadding="3" GridLines="Horizontal"
        DataKeyNames="id_cita" AutoGenerateColumns="false" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" HeaderStyle-BackColor="WhiteSmoke">


        <Columns>

            <asp:TemplateField HeaderText="Seleccionar">
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-primary" ID="lbtnSelect" runat="server" CommandName="Select" Text="Seleccionar" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="NumeroId">
                <ItemTemplate>
                    <asp:Label ID="lblNumeroId" Text='<%#Eval("id_cita") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre Cita">
                <ItemTemplate>
                    <asp:Label ID="lblNombre" Text='<%#Eval("nombre_cita") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <ItemTemplate>
                    <asp:Label ID="lblDescripcion" Text='<%#Eval("descripcion_cita") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cliente">
                <ItemTemplate>
                    <asp:Label ID="lblCliente" Text='<%#Eval("cliente_cita") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Correo del cliente">
                <ItemTemplate>
                    <asp:Label ID="lblCorreo" Text='<%#Eval("cliente_correo_cita") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Fecha de Registro">
                <ItemTemplate>
                    <asp:Label ID="lblFechaRegistro" Text='<%#Eval("fecha_registro_cita") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Fecha a Terminar">
                <ItemTemplate>
                    <asp:Label ID="lblFechaFin" Text='<%#Eval("fecha_fin_cita") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
         

         
        </Columns>
    </asp:GridView>
    <br />

    <div style="margin: 0 auto; width: 10%">

        <asp:Button CssClass="btn btn-primary" ID="btnNuevo" runat="server"
            Text="Nuevo" OnClick="btnNuevo_Click" />
    </div>


</asp:Content>
