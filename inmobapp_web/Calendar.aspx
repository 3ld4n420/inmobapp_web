﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="inmobapp_web.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>AGENDA</h1>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <table class="table"  style=" margin-top:10px">
        <tr>
            <td class="modal-sm" style="width: 206px">
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Width="71px"></asp:Calendar>
                <br />  
                    <br />  
                <table  style="width:10%">
                    <tr>
                        <td><b>Fecha :</b></td>
                        <td><asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></td>                        
                    </tr>
                      <tr>
                        <td><b>Hora : </b></td>
                        <td><asp:Label ID="lblHora" runat="server" Text=""></asp:Label></td>                        
                    </tr>
                     <tr>
                        <td><b>Evento: </b></td>
                         
                        <td><textarea id="txtDescripcion" cols="20" rows="2" runat="server"></textarea></td>
                         
                    </tr>
                     <tr>
                        <td></td>
                        <td><asp:Button CssClass="btn btn-success" ID="btnAceptar" runat="server" Text="Aceptar" Enabled="False" OnClick="btnAceptar_Click" /></td>
                         
                    </tr>
                </table> 
            </td>
            <td style="">
            <asp:GridView CssClass="table table-bordered" ID="gvData" runat="server" DataKeyNames="idEvento, idhora, Hora" AutoGenerateColumns="false" HeaderStyle-BackColor="WhiteSmoke"  
                style="max-width:60%" CellPadding="3" GridLines="Horizontal" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
                 <rowstyle Height="45px" />
        <Columns>
            <asp:TemplateField HeaderText="Seleccionar">
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-primary" ID="lbtnSelect" runat="server" CommandName="Select" Text="Seleccionar"   />
                </ItemTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Hora" >
                <ItemTemplate>
                      <div style="width: 100px; font-style:italic; font-weight:bold; overflow: hidden; white-space: nowrap; text-overflow: ellipsis">
                        <%# Eval("Hora") %>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <ItemTemplate>
                    <div style="width: 450px; overflow: hidden; white-space: nowrap; text-overflow: ellipsis">
                        <%# Eval("Descripcion") %>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>

            </asp:GridView>

              
            </td>
           
        </tr>
    </table>
    
</asp:Content>