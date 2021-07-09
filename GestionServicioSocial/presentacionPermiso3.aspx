﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="presentacionPermiso3.aspx.cs" Inherits="GestionServicioSocial.presentacionPermiso3" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="text-align: center">
        <h1>Oficio de solicitud para la visita de estudios</h1>
    </section>
    <asp:TextBox ID="txtNumeroControl" runat="server"></asp:TextBox>
    <br />
    <br />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" />
    <br />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="CartaPrecentacionPermisos3.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>
