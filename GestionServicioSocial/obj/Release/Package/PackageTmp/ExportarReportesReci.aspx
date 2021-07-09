<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ExportarReportesReci.aspx.cs" Inherits="GestionServicioSocial.ExportarReportesReci" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header style="text-align:center">GENERAR DOCUMENTOS

        PARA RESIDENCIA PROFECIONAL

        <br />
        <asp:Label ID="txtNumeroControl" runat="server"></asp:Label>
        <br />
        <br />

        <article id="expo">
        
           
       <!-- <button>
            <a href="ReportePrecentacion.aspx" target="_blank">Exportar Carta de presentación</a>
        </button>
        <button>
            <a href="ReporteSolicitud.aspx" target="_blank">Exportar Solicitud de servicio social</a>
        </button>-->
            <asp:Button ID="BtnCartaSolicitud" runat="server" Text="Generar solicitud de recidencia profecional" OnClick="BtnCartaSolicitud_Click" Width="368px"  />
            &nbsp;
            <asp:Button ID="BtnCartaPrecentacion" runat="server" Text="Generar carta de presentación" OnClick="BtnCartaPrecentacion_Click" Width="296px" />
            &nbsp;

        


    </article>

    <br />
    <br />
    <br />

        <asp:Button ID="BtnMenu" runat="server" Text="Regresar" OnClick="BtnMenu_Click" />
    </header>
    <br />
    <asp:GridView ID="GridView1" runat="server" Visible="False"></asp:GridView>
    </asp:Content>
