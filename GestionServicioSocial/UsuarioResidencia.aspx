﻿
<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="UsuarioResidencia.aspx.cs" Inherits="GestionServicioSocial.UsuarioResidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titulo1 {
            text-align:center;
        }
       
        #tabla {
            padding:10px 5px 15px 20px;
        }
        #headerxd
        {
            text-align:center;
        }

        .auto-style7 {
            width: 456px;
        }
        .auto-style8 {
            width: 327px;
        }
        .auto-style9 {
            width: 340px;
        }
        #botonesxd
        {
            text-align:center;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="text-align:right">
        <asp:Button ID="BtnEditarInformacion" runat="server" OnClick="BtnEditarInformacion_Click" Text="Editar mi información" BackColor="#28A745" ForeColor="White" />
&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Cerrar sesion" OnClick="Button1_Click" BackColor="#28A745" ForeColor="White" />
    </section>
    <header>
        
        <h1 class="titulo1">
            
            Residencia Profesional
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
&nbsp;  <asp:Label ID="txtNombreProyecto" runat="server" Text="Label"></asp:Label>        
        &nbsp;
    </section>
    


    <br />
    <br />
   <section>
       <div>
           <header id="headerxd"><h2>Genera tu solicictud y carta de presentación</h2></header>
       </div>
       <div id="botonesxd">
           <asp:Button ID="BtnSolicitud" runat="server" Text="Generar Solicitud De Residencia Profesional" OnClick="BtnSolicitud_Click" Width="370px" />&nbsp; <asp:Button ID="BtnPrecentacion" runat="server" Text="Generar Carta De Presentación" OnClick="BtnPrecentacion_Click" />

       </div>
   </section>
    <section class="titulo1">
        <header><h2>Subir evidencia de residencia profesional</h2></header>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <div style="text-align: center;">
     <table style="margin: 0 auto;" cellspacing="10" border="1" cellpadding="10">
         <tr>
             <td class="auto-style9">
                 Solicitud De Residencia Profesional:
             </td>
             <td class="auto-style7">
                 <asp:FileUpload ID="FileUpload1" runat="server" Width="243px" />
                 
             </td>
             <td class="auto-style8">
                 <asp:Button runat="server" Text="Subir Solicitud" ID="BtnSubirSolicitud"  Width="361px" OnClick="BtnSubirSolicitud_Click1" />
                 <asp:Label ID="Label12" runat="server" Text="Subido el:"></asp:Label>
&nbsp;<asp:Label ID="solicitud" runat="server" Text="Archivo aun no subido"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="auto-style9">
                 Carta De Presentación: </td>
             <td class="auto-style7">
                 <asp:FileUpload ID="FileUpload2" runat="server" Width="243px" />
                 
             <td class="auto-style8">
                 <asp:Button runat="server" Text="Subir Carta De Presentación" ID="BtnSubirPrecentacion" OnClick="BtnSubirPrecentacion_Click" Width="361px" />
                 <asp:Label ID="Label13" runat="server" Text="Subido el: "></asp:Label>
                 <asp:Label ID="presentacion" runat="server" Text="Archivo aun no subido"></asp:Label>
             </td>
             </td>
         </tr>
         <tr>
             <td class="auto-style9">
                 Carta De Aceptación RP:
             </td>
             <td class="auto-style7">
                 <asp:FileUpload ID="FileUpload3" runat="server" Width="243px" />
                 
             </td>
             <td class="auto-style8">
                 <asp:Button runat="server" Text="Subir Carta De Aceptación De RP" ID="BTNSubirAceptacionRP" OnClick="BTNSubirAceptacionRP_Click" Width="361px" />
                 <asp:Label ID="Label14" runat="server" Text="Subido el: "></asp:Label>
                 <asp:Label ID="aceptacion" runat="server" Text="Archivo aun no subido"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="auto-style9">
                 Responsiva:
             </td>
             <td class="auto-style7">
                 <asp:FileUpload ID="FileUpload4" runat="server" Width="243px" />
                 
             </td>
             <td class="auto-style8">
                 <asp:Button runat="server" Text="Subir Responsiva" ID="BTNSubirResponsiva" OnClick="BTNSubirResponsiva_Click" Width="361px" />
                 <asp:Label ID="Label15" runat="server" Text="Subido el: "></asp:Label>
                 <asp:Label ID="responsiva" runat="server" Text="Archivo aun no subido"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="auto-style9">
                 Carta De Liberación RP: </td>
             <td class="auto-style7">
                 <asp:FileUpload ID="FileUpload5" runat="server" Width="243px" />
                 
             <td class="auto-style8">
                 <asp:Button runat="server" Text="Subir Carta Liberación" ID="BtnSubirLiberacion" Width="361px" OnClick="BtnSubirLiberacion_Click" />
                 <asp:Label ID="Label16" runat="server" Text="Subido el: "></asp:Label>
                 <asp:Label ID="liberacion" runat="server" Text="Archivo aun no subido"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="auto-style9">
                 Constancia De Cumplimiento:
             </td>
             <td class="auto-style7">
                 <asp:FileUpload ID="FileUpload6" runat="server" Width="243px" />
                
             <td class="auto-style8">
                 <asp:Button runat="server" Text="Subir Constancia De Cumplimiento" ID="BtnSubirCumplimiento" Width="361px" OnClick="BtnSubirCumplimiento_Click" />
                 <asp:Label ID="Label17" runat="server" Text="Subido el: "></asp:Label>
                 <asp:Label ID="cumplimiento" runat="server" Text="Archivo aun no subido"></asp:Label>
             </td>
         </tr>
         
     </table>
    </div><br />
        <asp:Label ID="Label2" runat="server" Text="Selecciona un documento: "></asp:Label>
        &nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" >
             <asp:ListItem>Solicitud Residencia</asp:ListItem>
                        <asp:ListItem>Carta presentación</asp:ListItem>
                        <asp:ListItem>Carta aceptación</asp:ListItem>
                        <asp:ListItem>Responsiva</asp:ListItem>
                        <asp:ListItem>Carta liberación</asp:ListItem>
                        <asp:ListItem>Constancia cumplimiento</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnDescargar" runat="server" Text="Descargar" OnClick="BtnDescargar_Click" />
        
      &nbsp;<asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar" />
        <br />
        <asp:Label ID="descarga" runat="server" Text=""></asp:Label>
      <br />
        <asp:GridView runat="server" ID="GridView1" Visible="False"></asp:GridView>
        <asp:GridView ID="GridView2" runat="server" Visible="False"></asp:GridView>

    </section>

</asp:Content>
