<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="presentacionPermiso2.aspx.cs" Inherits="GestionServicioSocial.presentacionPermiso2" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Carta presentacion de servicio 2</h1>
    </div>
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" /><br />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="CartaPrecentacionPermisos2.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
</asp:Content>
