<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ReporteSolicitud.aspx.cs" Inherits="GestionServicioSocial.ReporteSolicitud" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <header id="titulo"> REPORTE DE SOLICITUD PARA SERVICIO SOCIAL</header>
    </div>
        
    <div>

        <asp:TextBox ID="txtNumeroControl" runat="server" OnTextChanged="txtNumeroControl_TextChanged"></asp:TextBox>
           
    </div>
        
    <div id="reporte">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="900px" Height="48px">
            <LocalReport ReportPath="informeSolicitud.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ReporteSolicitud" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GestionServicioSocial.DatosSolicitudRep0rteTableAdapters.DataTable1TableAdapter">
            <SelectParameters>
                <asp:ControlParameter Name="x" ControlID="txtNumeroControl" Type="String" /> 
            </SelectParameters>
        </asp:ObjectDataSource>
        
    </div>
    


</asp:Content>
