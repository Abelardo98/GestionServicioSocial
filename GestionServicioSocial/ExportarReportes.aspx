<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ExportarReportes.aspx.cs" Inherits="GestionServicioSocial.ExportarReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header style="text-align:center">EXPORTAR DOCUMENTOS

        SERVICIO SOCIAL

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
            <asp:Button ID="BtnCartaSolicitud" runat="server" Text="Exportar Solicitud de servicio social" OnClick="BtnCartaSolicitud_Click" Width="325px" />
            &nbsp;&nbsp;
            <asp:Button ID="BtnCartaPrecentacion" runat="server" Text="Exportar Carta de presentación" OnClick="BtnCartaPrecentacion_Click" />
            
        


    &nbsp;<asp:Button ID="BtnConstanciaTerminacion" runat="server" OnClick="BtnConstanciaTerminacion_Click" Text="Generar constancia terminación" />
            
        


    </article>

    <br />
    <br />
    <br />
        <asp:GridView ID="GridView1" runat="server" Visible="False"></asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click" />
    </header>
</asp:Content>
