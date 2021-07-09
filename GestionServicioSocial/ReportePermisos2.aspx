<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ReportePermisos2.aspx.cs" Inherits="GestionServicioSocial.ReportePermisos2" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        #titulo {
            text-align:center;
            width: 1343px;
            padding-top:40px;
    }
        #reporte {
            padding-top:80px;
            padding-left:200px;
            width: 1139px;
           
        }
        #ReportViewer1 {
          
        }
        table div {
           text-align:justify !important;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="cabezera">
        <header id="titulo"> GENERAR SOLICITUD DE VISITA A ORGANISMO</header>
    </div>
        
    <div>

        <asp:TextBox ID="txtNumeroControl" runat="server"></asp:TextBox>
           
    </div>
    <div id="reporte">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" ReportSourceID="CrystalReportSource1" />
    </div>
    <div>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="permisoIndustrial.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
</asp:Content>
