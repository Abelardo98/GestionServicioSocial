<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="vistaRecidencia.aspx.cs" Inherits="GestionServicioSocial.vistaRecidencia" %>
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
            width: 1270px;
        }

        .auto-style2 {
           
            width: 1310px;
        }

        .auto-style3 {
            width: 1377px;
        }

        .auto-style4 {
            width: 1369px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <header class="auto-style2">
        <asp:LinkButton ID="BtnServicio" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="BtnServicio_Click">Servicio Social</asp:LinkButton>

        &nbsp;

        <asp:LinkButton ID="BtnResidencia" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="BtnResidencia_Click" >Residencia Profesional</asp:LinkButton>

        &nbsp;

        <asp:LinkButton ID="BtnPermisos" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="BtnPermisos_Click">Visitas Industriales</asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="LinkButton2_Click">Carta Provisional</asp:LinkButton>
        &nbsp;
        
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Smaller" OnClick="LinkButton1_Click1">Cerrar Sesión</asp:LinkButton>
        
        
        
    </header>


    <br />
    <br />

    <section class="auto-style1">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

  <asp:Label ID="Label1" runat="server" Text="Número Control: "></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtNumerocontrol" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BTNeditar" runat="server" Text="Editar" class="btn btn-info" Height="40px" OnClick="BTNeditar_Click" />
        &nbsp;&nbsp; &nbsp;<button class="btn btn-info" type="button" data-toggle="modal" data-target="#exampleModal">Eliminar</button>
        &nbsp;&nbsp; &nbsp;


        &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnGenerarReporte" runat="server" class="btn btn-info" Text="Generar Reportes" OnClick="BtnGenerarReporte_Click" />


        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnDocumentosAlumno" runat="server" class="btn btn-info" OnClick="Button1_Click" Text="Información Detallada" Width="227px" />

<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">¿Esta seguro de querer elinar el numero de control?</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Cancelar">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
         <asp:Button ID="BTN_Eliminar" runat="server" class="btn btn-info" Text="Eliminar" OnClick="BTN_Eliminar_Click" />
      </div>
    </div>
  </div>
</div>

    &nbsp;</section>

    <br />
    <br />
    <br />

    <header style="text-align: center; border-top-width: medium; " class="auto-style4"><h3 class="auto-style3">DATOS DE ALUMNOS REGISTRADOS PARA REALIZAR LA RESIDENCIA PROFESIONAL</h3></header>

    <!--<section >-->
        <br />

        <div style="text-align: center; width: 1354px;">

            <asp:Button ID="BtnVerRegistros" runat="server" class="btn btn-info" Text="Ver Registros" OnClick="BtnVerRegistros_Click"  />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BTN_BUSCARREGISTRO" class="btn btn-info" runat="server" Text="Buscar Registro" OnClick="BTN_BUSCARREGISTRO_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="descargarResi" runat="server" Text="Exportar Datos" class="btn btn-info" OnClick="descargarResi_Click"/>

        </div>

        <br />
        <br />
        <div style="padding-left:30px; width: 1453px;">


            <div style="overflow: scroll; width: 1448px; height:500px;" >

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
