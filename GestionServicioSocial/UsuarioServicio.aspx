<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="UsuarioServicio.aspx.cs" Inherits="GestionServicioSocial.UsuarioServicio" %>
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

        .auto-style7 {
            width: 456px;
        }
        .auto-style8 {
            width: 327px;
        }
        .auto-style9 {
            width: 340px;
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
            width: 818px;
        }
        
        
        </style>
    <script type="text/javascript">
        function closeCurrentWindow() {

            window.close();
            window.open('index.aspx');

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="text-align:right">
       <!-- <asp:Button ID="BtnCerraSesion" runat="server" Text="Cerrar sesion" OnClick="BtnCerraSesion_Click" />-->
        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Cerrar sesión</asp:LinkButton>
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
    <section>
        <div>
            <header id="cabezaxd"><h2>Genera tu solicitud de servicio social y carta de presentación</h2></header>
        </div>
        <div id="btns">
            <asp:Button ID="generarSolicitud" runat="server" Text="Generar solicitud de Servicio Social" OnClick="generarSolicitud_Click" />&nbsp;
            <asp:Button ID="generarCarta" runat="server" Text="Generar carta de presentación" OnClick="generarCarta_Click" />
        </div>
    </section>
    <section class="titulo1">
        <header id="cabexd"><h2>Evidencia Servicio Social</h2></header>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <div style="text-align: center;">
          <table style="margin: 0 auto;" cellspacing="10" border="1" cellpadding="10">
              <tr>
                  <td class="auto-style9">
                      Solicitud de servicio social
                  </td>
                  <td class="auto-style7">
                      <asp:FileUpload ID="FileUpload1" runat="server" width="243px"/>
                  </td>
                  <td class="auto-style8">
                      <asp:Button ID="Button1" runat="server" Text="Subir solicitud de servicio social" Width="361px" OnClick="Button1_Click"/>
                      <asp:Label ID="solicitud" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="auto-style9">
                      Acuse de carta de presentación
                  </td>
                  <td class="auto-style7">
                      <asp:FileUpload ID="FileUpload2" runat="server" width="243px"/>
                  </td>
                  <td class="auto-style8">
                      <asp:Button ID="acusePresentacion" runat="server" Text="Subir acuse de carta de presentación" Width="361px" OnClick="acusePresentacion_Click"/>
                      <asp:Label ID="presentacion" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="auto-style9">
                      Carta de aceptación
                  </td>
                  <td class="auto-style7">
                      <asp:FileUpload ID="FileUpload3" runat="server" width="243px"/>
                  </td>
                  <td class="auto-style8">
                      <asp:Button ID="cartaAceptacion" runat="server" Text="Subir carta de aceptación" Width="361px" OnClick="cartaAceptacion_Click" />
                      <asp:Label ID="aceptacion" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="auto-style9">
                      Responsiva
                  </td>
                  <td class="auto-style7">
                      <asp:FileUpload ID="FileUpload4" runat="server" width="243px" />
                  </td>
                  <td class="auto-style8">
                      <asp:Button ID="Responsiva" runat="server" Text="Subir Responsiva" Width="361px" OnClick="Responsiva_Click" />
                      <asp:Label ID="responsivaxd" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="auto-style9">
                      Carta compromiso
                  </td>
                  <td class="auto-style7">
                      <asp:FileUpload ID="FileUpload7" runat="server" width="243px" />
                  </td>
                  <td class="auto-style8">
                      <asp:Button ID="cartaCompromiso" runat="server" Text="Subir carta compromiso" Width="361px" OnClick="cartaCompromiso_Click" />
                      <asp:Label ID="compromiso" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="auto-style9">
                      Apartado para:&nbsp;</td>
                  <td class="auto-style7">
                      <asp:Button ID="planTrabajo" runat="server" Text="Subir plan de trabajo" OnClick="planTrabajo_Click" Width="246px" />
                  </td>
                  <td class="auto-style8">
                      <asp:Button ID="subirReporte" runat="server" Text="Subir Reportes" OnClick="subirReporte_Click" Width="361px" />
                  </td>
              </tr>
              <tr>
                  <td class="auto-style9">
                      Reporte final
                  </td>
                  <td class="auto-style7">
                      <asp:FileUpload ID="FileUpload5" runat="server" width="243px" />
                  </td>
                  <td class="auto-style8">
                      <asp:Button ID="reporteFinal" runat="server" Text="Subir reporte final" Width="361px" OnClick="reporteFinal_Click" />
                      <asp:Label ID="final" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              
              
          </table>
        </div><br />
        <div style="text-align: center;">
          <table style="margin: 0 auto;" cellspacing="10" border="1" cellpadding="10">
              <tr>
                  <td class="auto-style9">
                      Apartado para:</td>
                  <td class="auto-style10">
                      
                      <asp:Button ID="cartaLibre" runat="server" Text="Subir carta de liberación" Width="246px" OnClick="cartaLibre_Click" />
                   </td>
                 <!-- <td class="auto-style8">
                      <asp:Button ID="BtnGenerarConstanciaTerminacion" runat="server" Text="Generar constancia terminación" Width="361px" OnClick="BtnGenerarConstanciaTerminacion_Click" />
                  </td>-->
              </tr>

          </table>
        </div>
        <div style="text-align: center;">
          <table style="margin: 0 auto;" cellspacing="10" border="1" cellpadding="10">
              <tr>
                  <td class="auto-style9">
                      Apartado para:
                  </td>
                  <td class="auto-style7">
                      <asp:FileUpload ID="FileUpload6" runat="server" Width="243px" />
                  </td>
                  <td class="auto-style8">
                        <asp:Button ID="consTerminacion" runat="server" Text="Subir constancia terminación" Width="361px" OnClick="consTerminacion_Click" />
                      <asp:Label ID="terminacion" runat="server" Text=""></asp:Label>
                  </td>
              </tr>

          </table>
        </div>
        <br />
        <br />
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
        <asp:Button ID="BtnDescargar" runat="server" Text="Descargar" OnClick="descargar_Click" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="eliminar" runat="server" Text="Eliminar" OnClick="eliminar_Click" />
      
        <br />
        <asp:Label ID="descarminar" runat="server" Text=""></asp:Label>
      
      <br />
      <br />
        <asp:GridView runat="server" ID="GridView1" Visible="False"></asp:GridView>
        

    </section>

    <br />
    <br />


    
</asp:Content>
