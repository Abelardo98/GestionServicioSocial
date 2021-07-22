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
        #tb {
            text-align:center;
            padding-left: 150px;

        }
        #tb2 {
            text-align:center;
            padding-left: 50px;

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
        <br />
        <asp:Label ID="Label9" runat="server" Text="NOMBRE DEL PROYECTO:" Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="txtNombreProyecto" runat="server" Text="Label"></asp:Label>
        &nbsp;
    </section>
    
    <br />
    <header>
        <h2 class="titulo1">Documentación del alumno
        </h2>
    </header>
    <br />
    <div style="padding-left: 30px; width: 1453px;">
        <div id="tb" style="overflow: scroll; width: 1448px; height: 200px;">

            <asp:GridView ID="GridView3" runat="server" CellPadding="3" GridLines="Vertical" Width="1088px" BorderColor="#999999" BackColor="White" BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <EditRowStyle BorderColor="Red" BorderStyle="Solid" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" BorderColor="Red" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" BorderColor="#00CCFF" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>

        </div>
    </div>

    <br />
    <header>
        <h2 class="titulo1">
            Calificaciones del alumno
        </h2> 
    </header>
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
    <div id="tb2" style="overflow: scroll; width: 1448px;">

        <asp:GridView ID="GridView2" runat="server" CellPadding="3" Width="434px" BorderColor="#DEBA84" BackColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                    <EditRowStyle BorderColor="Red" BorderStyle="Solid" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" BorderColor="Red" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" BorderColor="#00CCFF" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
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
