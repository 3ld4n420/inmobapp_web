<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="inmobapp_web.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <br /> 
    <br /> 
    <br /> 
    <h1>AGENDA</h1>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <table class="table" dir="ltr" >
        <tr>
            <td class="modal-sm" style="width: 180px">
                <asp:Calendar CssClass="table table-bordered" ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Width="50px" BackColor="White" ForeColor="Black">
                    <DayHeaderStyle BackColor="#FF3399" BorderColor="White" />
                    <DayStyle BackColor="White" />
                    <OtherMonthDayStyle BackColor="#FF3399" />
                    <TitleStyle BackColor="White" BorderColor="White" Wrap="True" />
                    <WeekendDayStyle BackColor="White" />
                </asp:Calendar>
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
                         
                        <td><textarea id="txtDescripcion" rows="4" runat="server" style="width: 177px; color: #000000;" CssClass="col-form-label border-primary col-lg-10" enableviewstate="True"  ></textarea></td>
                         
                    </tr>
                     <tr>
                        <td><b>Responsable: </b></td>
                          <td><asp:DropDownList ID="ddlResponsable" runat="server"  CssClass="col-form-label border-primary col-lg-10" ForeColor="Black"></asp:DropDownList>
                         </td>
                        
                    </tr>
                    
                     <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                         
                    </tr>
                    
                     <tr>
                        <td></td>
                        <td><asp:Button CssClass="btn btn-primary" ID="btnAceptar" runat="server" Text="Aceptar" Enabled="False" OnClick="btnAceptar_Click" /></td>
                         
                    </tr>
                </table> 
            </td>
            <td style="">
            <asp:GridView ID="gvData" CssClass="table table-bordered"  runat="server" DataKeyNames="idEvento, idhora, Hora" AutoGenerateColumns="false" HeaderStyle-BackColor="#ff3399"  
                style="max-width:60%" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
                 <EditRowStyle BackColor="White" />
                 <FooterStyle BackColor="White" />


                 <PagerStyle BackColor="White" />
                 <rowstyle Height="45px" BackColor="White" BorderColor="White" Font-Bold="False" ForeColor="Black" />
                 <AlternatingRowStyle BackColor="White" />
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
             <asp:TemplateField HeaderText="Responsable" >
                <ItemTemplate>
                      <div class="text-info" style="font-style:italic;  overflow: hidden; white-space: nowrap; text-overflow: ellipsis">
                        <%# Eval("responsable") %>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>

            </asp:GridView>

              
            </td>
           
        </tr>
    </table>
    
</asp:Content>
