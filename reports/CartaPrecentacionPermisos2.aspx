<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="CartaPrecentacionPermisos2.aspx.cs" Inherits="GestionServicioSocial.CartaPrecentacionPermisos21" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article style="padding-left:150px">
        <asp:TextBox ID="txtNumeroControl" runat="server"></asp:TextBox>
       </article>
        <br />
        <br />
        <div style="padding-left:150px">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSource2" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False" />
            <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                <report filename="CartaPrecentacionPermisos2.rpt">
                </report>
            </CR:CrystalReportSource>
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="CrystalReport1.rpt">
                </Report>
            </CR:CrystalReportSource>
        </div>
</asp:Content>
