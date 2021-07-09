<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="vistaAsesoresServicio.aspx.cs" Inherits="GestionServicioSocial.vistaAsesoresServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    

    <style>

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
        
        <asp:LinkButton ID="BtnServicio" runat="server" Font-Bold="True" Font-Size="Smaller" >Servicio social</asp:LinkButton>

        &nbsp;

        <asp:LinkButton ID="BtnResidencia" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="BtnResidencia_Click">Residencia profesional</asp:LinkButton>

        &nbsp;

        &nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="LinkButton1_Click">Cerrar Sesión</asp:LinkButton>
        </header>


    <br />
    <br />
    <br />

    <section class="auto-style1">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

  <asp:Label ID="Label1" runat="server" Text="Numero control: "></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtNumerocontrol" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BTN_BUSCARREGISTRO" class="btn btn-info" runat="server" Text="Buscar Registro" OnClick="BTN_BUSCARREGISTRO_Click" />

        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Descargar documentación:"></asp:Label>&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-info" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>Selecciona un archivo</asp:ListItem>
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
        </asp:DropDownList>&nbsp;
        <asp:Label ID="descarminar" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
    </section>

    <br />
    <br />
    <br />

    <header style="text-align: center; border-top-width: medium; " class="auto-style3"><h3>DATOS DE ALUMNOS REGISTRADOS PARA REALIZAR SERVICIO SOCIAL</h3></header>

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
            <asp:Button ID="descargarRegistros" runat="server" class="btn btn-info" Text="Exportar registros" OnClick="descargarRegistros_Click" />
            


        </div>

        <br />
        <br />
        <div style="padding-left:30px; width: 1453px;">


            <div style="overflow: scroll; width: 1448px;">

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


   <!-- </section>-->


    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>

</asp:Content>
