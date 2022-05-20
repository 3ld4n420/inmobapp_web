<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuariosSistema.aspx.cs" Inherits="inmobapp_web.UsuariosSistema" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <br />

    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <br />
    <br />
    <br />

    <div runat="server" id="formulario">
        <div class="card border-primary mb-12">
          <div class="card-header">DATOS DE LOS USUARIOS DEL SISTEMA</div>
          <div class="card-body">
            <table  style="margin: auto; width: 90%; padding: 10px;" >
            <tr>
                <td hidden>
                    <label>ID del usuario:</label><br />
                    <asp:TextBox ID="txt_usr_id" runat="server" CssClass="list-group-item text-dark col-lg-10" />
                </td>
                <td hidden>
                    <label>Fecha creacion del usuario:</label><br />
                    <asp:TextBox ID="txt_usr_fecha_creacion" runat="server" CssClass="list-group-item text-dark col-lg-10" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>Nombres y Apellidos :</label><br />
                    <asp:TextBox ID="txt_usr_nombres_apellidos" runat="server" CssClass="col-form-label text-dark border-primary col-lg-10"  style=" max-width: 100%; width: 92%;" />
                </td>
                <td>
                    <label>Tipo identificación:</label><br />
                    <asp:DropDownList ID="ddl_usr_tipo_identificacion" runat="server" CssClass="list-group-item border-primary text-dark col-lg-10 text-dark bg-white"></asp:DropDownList>
                </td>                
                <td>
                    <label>Número identificacion:</label><br />
                    <asp:TextBox ID="txt_usr_numero_identificacion" runat="server" CssClass="col-form-label text-dark border-primary col-lg-10" />
                </td>
            </tr>
            <tr>
               
                
               <td colspan="2">
                   <br />
                    <label>Correo usuario:</label><br />
                    <asp:TextBox ID="txt_usr_correo" runat="server" CssClass="col-form-label text-dark border-primary col-lg-10" style=" max-width: 100%; width: 95%; top: 0px; left: 0px;" />
                </td>
              
                
               <td>
                   <br />
                    <label>Clave usuario:</label><br />
                    <asp:TextBox ID="txt_usr_clave" runat="server" CssClass="col-form-label text-dark border-primary col-lg-10" style=" max-width: 100%; width: 95%; top: 0px; left: 0px;" />
                </td>

                <td>
                    <br />
                     <label>Permisos usuario:</label><br />
                    <asp:DropDownList ID="ddl_usr_rol" runat="server" CssClass="list-group-item text-dark border-primary col-lg-10 text-dark bg-white"></asp:DropDownList>                
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <label>Estado Usuario:</label><br />
                    <asp:DropDownList ID="ddl_usr_activo" runat="server" CssClass="list-group-item text-dark border-primary col-lg-10 text-dark bg-white">
                        <asp:ListItem Value="1">Activo</asp:ListItem>
                        <asp:ListItem Value="0">Innactivo</asp:ListItem>
                    </asp:DropDownList>                
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
        <br />
        <br />
        <!------------------------------------VALIDACIONES DE LOS CAMPOS------------------------------------------------------------>
        <div >
        </div>

    </div>

    <br />
    <asp:GridView CssClass="table table-bordered" ID="gvDatos" runat="server" CellPadding="3" GridLines="Horizontal"
        DataKeyNames="usr_id" AutoGenerateColumns="False" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" HeaderStyle-BackColor="#ff3399">


        <Columns>

            <asp:TemplateField HeaderText="Seleccionar"> 
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-primary" ID="lbtnSelect" runat="server" CommandName="Select" Text="Seleccionar" />
                </ItemTemplate>


            </asp:TemplateField>


            <asp:BoundField DataField="usr_id" HeaderText="ID" ReadOnly="true"></asp:BoundField>

            <asp:TemplateField HeaderText="Tipo identificación">
                <ItemTemplate>
                    <asp:Label ID="ddl_usr_tipo_identificacion" Text='<%#Eval("usr_tipo_identificacion") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Número identificación">
                <ItemTemplate>
                    <asp:Label ID="txt_usr_numero_identificacion" Text='<%#Eval("usr_numero_identificacion") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombres y apellidos">
                <ItemTemplate>
                    <asp:Label ID="txt_usr_nombres_apellidos" Text='<%#Eval("usr_nombres_apellidos") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Correo usuario">
                <ItemTemplate>
                    <asp:Label ID="txt_usr_correo" Text='<%#Eval("usr_correo") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Clave usuario">
                <ItemTemplate>
                    <asp:Label ID="txt_usr_clave" Text='<%#Eval("usr_clave") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rol usuario">
                <ItemTemplate>
                    <asp:Label ID="ddl_usr_rol" Text='<%#Eval("usr_rol") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fecha registrado">
                <ItemTemplate>
                    <asp:Label ID="txt_usr_fecha_creacion" Text='<%#Eval("usr_fecha_creacion") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Activo">
                <ItemTemplate>
                    <asp:Label ID="ddl_usr_activo" Text='<%#Eval("usr_activo") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>       
        </Columns>

<HeaderStyle BackColor="#ff3399"></HeaderStyle>
    </asp:GridView>
    <br />

    <div style="margin: 0 auto; width: 10%">

        <asp:Button CssClass="btn btn-primary" ID="btnNuevo" runat="server"
            Text="Nuevo" OnClick="btnNuevo_Click" />
    </div>

    
</asp:Content>

