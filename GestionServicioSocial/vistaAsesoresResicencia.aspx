<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="vistaAsesoresResicencia.aspx.cs" Inherits="GestionServicioSocial.vistaAsesores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    

    <style>
        #tb {
            text-align:center;
            padding-left: 250px;

        }
        .titu {
            text-align:center;
        width: 1219px;
    }
        .home {            width: 1356px;
        }

        .auto-style1 {
            width: 1447px;
        }

        .auto-style2 {
            
            width: 1372px;
            height: 30px;
        }

        .auto-style3 {
            width: 1456px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <header class="auto-style2">
        
        <asp:LinkButton ID="BtnServicio" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="BtnServicio_Click" >Servicio Social</asp:LinkButton>

        &nbsp;

        <asp:LinkButton ID="BtnResidencia" runat="server" Font-Bold="True" Font-Size="Smaller">Residencia Profesional</asp:LinkButton>

        &nbsp;

        &nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="LinkButton1_Click">Cerrar Sesión</asp:LinkButton>
        </header>


    <br />
    <br />
    <br />

    <section class="auto-style1">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

  <asp:Label ID="Label1" runat="server" Text="Número Control: "></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtNumerocontrol" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BTN_BUSCARREGISTRO" class="btn btn-info" runat="server" Text="Buscar Registro" OnClick="BTN_BUSCARREGISTRO_Click" />

        &nbsp;
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Selecciona un archivo:"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" class="btn btn-info" runat="server" >
             <asp:ListItem>Solicitud Residencia</asp:ListItem>
                        <asp:ListItem>Carta presentación</asp:ListItem>
                        <asp:ListItem>Carta aceptación</asp:ListItem>
                        <asp:ListItem>Responsiva</asp:ListItem>
                        <asp:ListItem>Carta liberación</asp:ListItem>
                        <asp:ListItem>Constancia cumplimiento</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnDescargar" runat="server" Text="Descargar" class="btn btn-info" OnClick="BtnDescargar_Click"/>
    </section>

    <br />
    <br />
    <br />

    <header style="text-align: center; border-top-width: medium; " class="auto-style3"><h3>DATOS DE ALUMNOS REGISTRADOS PARA REALIZAR LA RESIDENCIA PROFESIONAL</h3></header>

    <!--<section >-->
        <br />

        <div style="text-align: center; width: 1354px;">

            <asp:DropDownList ID="txtCarreras" runat="server" class="btn btn-info">
                <asp:ListItem>INGENIERÍA INFORMÁTICA</asp:ListItem>
                <asp:ListItem>INGENIERÍA MECATRÓNICA</asp:ListItem>
                <asp:ListItem>INGENIERÍA EN ADMINISTRACIÓN</asp:ListItem>
                <asp:ListItem>INGENIERÍA INDUSTRIAL</asp:ListItem>
                <asp:ListItem>INGENIERÍA FORESTAL</asp:ListItem>
                <asp:ListItem>LICENCIATURA EN BIOLOGÍA</asp:ListItem>
                <asp:ListItem>GASTRONOMÍA</asp:ListItem>
            </asp:DropDownList>

            &nbsp;

            <asp:Button ID="BtnVerRegistros" runat="server" class="btn btn-info" Text="Ver Registros" OnClick="BtnVerRegistros_Click" />

            &nbsp;

            <asp:Button ID="descargarResi" runat="server" Text="Exportar Datos" class="btn btn-info" OnClick="descargarResi_Click"/>


        </div>

        <br />
        <br />
        <div style="padding-left:30px; width: 1453px;">


            <div style="overflow: scroll; width: 1448px; height:350px; ">

                &nbsp;

                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="434px" BorderColor="White">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" BorderColor="Red" BorderStyle="Solid" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" BorderColor="Red" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" BorderColor="#00CCFF" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>


            </div>


        </div>
       <br />
       
    <header style="text-align: center; border-top-width: medium; " class="auto-style3"><h3>DOCUMENTACIÓN DEL ALUMNO</h3></header>
      <br />

    <div style="padding-left: 30px; width: 1453px;">
        <div id="tb" style="overflow: scroll; width: 1448px; height: 350px;">

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
    </div>   

   <!-- </section>-->


    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>

</asp:Content>
