<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="liberacion.aspx.cs" Inherits="GestionServicioSocial.terminacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <article style="text-align:right">
            <asp:Button ID="BtnRegresar" runat="server" Text="Regresar" OnClick="BtnRegresar_Click"/>
        </article>
        

        <header style="text-align:center">
            <h1>Cargar carta de liberación de servicio social</h1>
            <h2>Numero de control: </h2>
            <asp:Label ID="txtNc" runat="server" Text=""></asp:Label>
        </header>
        <div style="text-align:center;">
            <asp:Label ID="Label3" runat="server" Text="Nombre del proyecto:"></asp:Label>
            <asp:TextBox ID="txtNombreProyecto" runat="server" Width="364px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator0" ValidationGroup="liberacion" runat="server" ErrorMessage="*"  ControlToValidate="txtNombreProyecto" ForeColor="Red"></asp:RequiredFieldValidator><br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Fecha de incio de Servicio Social:"></asp:Label> &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="numeroDia" runat="server" Width="32px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ValidationGroup="liberacion" runat="server" ErrorMessage="*" ControlToValidate="numeroDia" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;
            de
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="mesInicioServicio" runat="server">
                <asp:ListItem Value="enero">Enero</asp:ListItem>
                <asp:ListItem Value="febrero">Febrero</asp:ListItem>
                <asp:ListItem Value="marzo">Marzo</asp:ListItem>
                <asp:ListItem Value="abril">Abril</asp:ListItem>
                <asp:ListItem Value="mayo">Mayo</asp:ListItem>
                <asp:ListItem Value="junio">Junio</asp:ListItem>
                <asp:ListItem Value="julio">Julio</asp:ListItem>
                <asp:ListItem Value="agosto">Agosto</asp:ListItem>
                <asp:ListItem Value="septiembre">Septiembre</asp:ListItem>
                <asp:ListItem Value="octubre">Octubre</asp:ListItem>
                <asp:ListItem Value="noviembre">Noviembre</asp:ListItem>
                <asp:ListItem Value="diciembre">Diciembre</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            del
            &nbsp;&nbsp;
            <asp:DropDownList ID="anioInicioServicio" runat="server">
                <asp:ListItem>2020</asp:ListItem>
                <asp:ListItem>2021</asp:ListItem>
                <asp:ListItem>2022</asp:ListItem>
                <asp:ListItem>2023</asp:ListItem>
                <asp:ListItem>2024</asp:ListItem>
                <asp:ListItem>2025</asp:ListItem>
                <asp:ListItem>2026</asp:ListItem>
                <asp:ListItem>2027</asp:ListItem>
                <asp:ListItem>2028</asp:ListItem>
                <asp:ListItem>2029</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:RangeValidator id="RangeValidator7" runat="server"
                        ControlToValidate="numeroDia"
                        ForeColor="Black"
                        MinimumValue="1"
                        MaximumValue="31"
                        Type="Integer"
                        Text="* Ingresa un dia valido" 
                        ValidationGroup="liberacion"/>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="Fecha de terminación de Servicio Social:"></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="numeroDia2" runat="server" Width="32px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="liberacion" runat="server" ErrorMessage="*" ControlToValidate="numeroDia2" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;
            de &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="mesTerminoServicio" runat="server">
                <asp:ListItem Value="enero">Enero</asp:ListItem>
                <asp:ListItem Value="febrero">Febrero</asp:ListItem>
                <asp:ListItem Value="marzo">Marzo</asp:ListItem>
                <asp:ListItem Value="abril">Abril</asp:ListItem>
                <asp:ListItem Value="mayo">Mayo</asp:ListItem>
                <asp:ListItem Value="junio">Junio</asp:ListItem>
                <asp:ListItem Value="julio">Julio</asp:ListItem>
                <asp:ListItem Value="agosto">Agosto</asp:ListItem>
                <asp:ListItem Value="septiembre">Septiembre</asp:ListItem>
                <asp:ListItem Value="octubre">Octubre</asp:ListItem>
                <asp:ListItem Value="noviembre">Noviembre</asp:ListItem>
                <asp:ListItem Value="diciembre">Diciembre</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            del
            &nbsp;&nbsp;
            <asp:DropDownList ID="anioTerminoServicio" runat="server">
                <asp:ListItem>2020</asp:ListItem>
                <asp:ListItem>2021</asp:ListItem>
                <asp:ListItem>2022</asp:ListItem>
                <asp:ListItem>2023</asp:ListItem>
                <asp:ListItem>2024</asp:ListItem>
                <asp:ListItem>2025</asp:ListItem>
                <asp:ListItem Value="2026"></asp:ListItem>
                <asp:ListItem>2027</asp:ListItem>
                <asp:ListItem>2028</asp:ListItem>
                <asp:ListItem>2029</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:RangeValidator id="RangeValidator1" runat="server"
                        ControlToValidate="numeroDia2"
                        ForeColor="Black"
                        MinimumValue="1"
                        MaximumValue="31"
                        Type="Integer"
                        Text="* Ingresa un dia valido"
                        ValidationGroup="liberacion"/>
            <br />
            <asp:Label ID="asterisco" runat="server" Text="* Campos Obligatorios" style="color: red;"></asp:Label>&nbsp;&nbsp;
            </div>
        <table>
            <tr>
                <td>
                    Cargar carta de liberación
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Cargar" ValidationGroup="liberacion" OnClick="Button1_Click" style="height: 29px" />
                </td>
            </tr>
        </table>
        
    </section>
</asp:Content>
