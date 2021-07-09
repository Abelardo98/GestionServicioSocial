<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="UsuarioServicioAdmin.aspx.cs" Inherits="GestionServicioSocial.UsuarioServicioAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titulo1 {
            text-align:center;
        }
        #tabla {
            padding:10px 5px 15px 20px;
        }
        #cabezaxd
        {
            text-align:center;
        }

        #cabexd
        {
            text-align:center;
        }

        #btns
        {
            text-align:center;
        }
        
        
        .auto-style10 {
            width: 1442px;
            text-align:center;
        }
        
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="text-align:right">
        <asp:Button ID="Button2" runat="server" Text="Regresar" OnClick="Button2_Click" />
    </section>
    <header>
        <h1 class="titulo1">
            Servicio Social
        </h1> 
    </header>
    <br />
    <br />

    <section class="titulo1">
        <asp:Label runat="server" Text="NOMBRE:" ID="label1" Font-Bold="True"></asp:Label>
    &nbsp;<asp:Label ID="txtnombre" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="txtAP" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="txtAM" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="N.C:"></asp:Label>
&nbsp;<asp:Label ID="txtNc" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="CARRERA:" Font-Bold="True"></asp:Label>
        <asp:Label ID="txtCarrera" runat="server">label</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="SEMESTRE:" Font-Bold="True"></asp:Label>
        <asp:Label ID="txtSemestre" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="PERIODO:"></asp:Label>
        &nbsp;<asp:Label ID="txtPeriodo" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="NOMBRE DEL PROYECTO:" Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="txtNombreProyecto" runat="server" Text="Label"></asp:Label>
        &nbsp;
    </section>
    
    <br />
    <section style="text-align:center">
         <asp:Label ID="Label12" runat="server" Text="Numero de reportes:"></asp:Label>
         <asp:DropDownList ID="txtNreportes" runat="server">
             <asp:ListItem>3</asp:ListItem>
             <asp:ListItem>4</asp:ListItem>
             <asp:ListItem>5</asp:ListItem>
         </asp:DropDownList>
&nbsp;<asp:Button ID="Btn_CalcularCalificaciones" runat="server" Text="Calcular calificaciones" OnClick="Btn_CalcularCalificaciones_Click" />
      
    </section>
   
    <br />    
    <br />
    <div style="overflow: scroll; width: 1448px;">

        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="434px" BorderColor="White">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" BorderColor="Red" BorderStyle="Solid" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" BorderColor="Red" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" BorderColor="#00CCFF" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
    </div>
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <table class="auto-style10">
            <tr>
                <td>
                    FINAL DE EV
                </td>
                <td>
                    FINAL DE AUTO
                </td>
                <td>
                    FINAL
                </td>
                <td>
                    CALIFICACIÓN
                </td>
                <td>
                    NIVEL DE DESEMPEÑO
                </td>
            </tr>

             <tr>
                <td>
                    <asp:TextBox ID="txtEV" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtAuto" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtFinal" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCalificacion" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNivelDesem" runat="server"></asp:TextBox>
                </td>
            </tr>

        </table>

    </asp:Panel>

    <br />

     <header>
        <h2 class="titulo1">
            Descargar documentación
        
    </header>
    <br />
    <article style="text-align:center">
        <asp:Label ID="Label2" runat="server" Text="Selecciona documento: "></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="servicioSocial">Solicitud Servicio Social</asp:ListItem>
            <asp:ListItem Value="presentacion">Acuse Carta de Presentación</asp:ListItem>
            <asp:ListItem Value="cartaAceptación">Carta de Aceptación</asp:ListItem>
            <asp:ListItem Value="responsiva">Responsiva</asp:ListItem>
            <asp:ListItem Value="compromiso">Carta Compromiso</asp:ListItem>
            <asp:ListItem Value="planTrabajo">Plan de Trabajo</asp:ListItem>
            <asp:ListItem>Reporte 1</asp:ListItem>
            <asp:ListItem>Reporte 2</asp:ListItem>
            <asp:ListItem>Reporte 3</asp:ListItem>
            <asp:ListItem>Reporte 4</asp:ListItem>
            <asp:ListItem>Reporte 5</asp:ListItem>
            <asp:ListItem>Evaluaciones finales</asp:ListItem>
            <asp:ListItem Value="rFinal">Reporte Final</asp:ListItem>
            <asp:ListItem Value="liberacion">Carta de Liberación</asp:ListItem>
            <asp:ListItem Value="Constancia de terminación">Constancia de terminación</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnDescargar" runat="server" Text="Descargar" OnClick="BtnDescargar_Click" />&nbsp;&nbsp;&nbsp;
    </article>
    
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" Visible="False">
    </asp:GridView>

</asp:Content>
