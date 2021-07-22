<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="UsuarioResidenciaAdmin.aspx.cs" Inherits="GestionServicioSocial.UsuarioResidenciaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .titulo1 {
            text-align:center;
        }
        #tabla {
            padding:10px 5px 15px 20px;
        }
        #tb {
            text-align:center;
            padding-left: 250px;

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
        
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="text-align:right">
        <asp:Button ID="Button2" runat="server" Text="Regresar" href='javascript:history.go(-1)' OnClick="Button2_Click" />
    </section>
    <header>
        <h1 class="titulo1">
            Residencia profesional
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
    <section style="text-align:center">
         <asp:Label ID="Label12" runat="server" Text="Documentación del Alumno" Font-Bold="True"></asp:Label>
         &nbsp;
         
      
    </section>
   
    <br />    
    <br />
    <div id="tb">

        <asp:GridView ID="GridView2" runat="server" CellPadding="3" GridLines="Vertical" Width="1088px" BorderColor="#999999" BackColor="White" BorderStyle="None" BorderWidth="1px">
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
    <br />

    <br />

     <header>
        <h2 class="titulo1">
            Descargar documentación
        
    </header>
    <br />
    <article style="text-align:center">
        <asp:Label ID="Label2" runat="server" Text="Selecciona documento: "></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" >
             <asp:ListItem>Solicitud Residencia</asp:ListItem>
                        <asp:ListItem>Carta presentación</asp:ListItem>
                        <asp:ListItem>Carta aceptación</asp:ListItem>
                        <asp:ListItem>Responsiva</asp:ListItem>
                        <asp:ListItem>Carta liberación</asp:ListItem>
                        <asp:ListItem>Constancia cumplimiento</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnDescargar" runat="server" Text="Descargar" OnClick="BtnDescargar_Click" />&nbsp;&nbsp;&nbsp;
    </article>
    
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" Visible="False">
    </asp:GridView>


</asp:Content>
