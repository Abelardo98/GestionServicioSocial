<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="SalidaDeEstudios.aspx.cs" Inherits="GestionServicioSocial.SalidaDeEstudios" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titulo {
            text-align:center
        }
        #Label8 {
            padding-bottom:289px;
            text-align:center;
            
        }
        .auto-style3 {
            height: 34px;
            width: 739px;
        }
        .auto-style4 {
            width: 739px;
        }
        .auto-style7 {
            width: 913px;
        }
        .auto-style9 {
            width: 913px;
            height: 34px;
        }
        .auto-style11 {
            height: 163px;
        }
        .auto-style12 {
            width: 965px;
        }
        .auto-style13 {
            width: 965px;
            height: 34px;
        }
        .auto-style14 {
            width: 798px;
            height: 34px;
        }
        .auto-style15 {
            width: 798px;
        }
        .auto-style16 {
            height: 144px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="titulo"><h1>Salida de visita estudios</h1></header>
    <br />
    <section>
        <article class="titulo">
            <asp:Label ID="Label9" runat="server" Text="VISITA INDUSTRIAL Y PRÁCTICA"></asp:Label>
            <asp:DropDownList ID="txtVisitaPractica" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtVisitaPractica_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>PRESENCIAL</asp:ListItem>
                <asp:ListItem>VIRTUAL</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" Text="VISITA INDUSTRIAL:"></asp:Label>
        
            <asp:DropDownList ID="txtVisitaIndustrial" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="txtVisitaIndustrial_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>PRESENCIAL</asp:ListItem>
                <asp:ListItem>VIRTUAL</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="PRÁCTICA:"></asp:Label>
            <asp:DropDownList ID="txtPractica" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtPractica_SelectedIndexChanged1">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>PRESENCIAL</asp:ListItem>
                <asp:ListItem>VIRTUAL</asp:ListItem>
            </asp:DropDownList>
        </article>



        <article class="titulo">
            <header class="titulo"><h2>Datos académicos</h2></header>


            <table >
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="Label2" runat="server" Text="Docente responsable:" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtDocenteResponsable" runat="server" required Width="401px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Text="Núm.Cel:" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtNumeroCelDocente" runat="server" required Width="468px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label runat="server" Text="Correo electrónico:"  Width="200px"></asp:Label>
                        <asp:TextBox ID="txtCorreoElextronicoDocente" runat="server" required Width="401px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="Label4" runat="server" Text="Materia:" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtMateria" runat="server" Width="468px" required Height="21px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="Label19" runat="server" Text="Semestre:" Width="200px"></asp:Label>
                        <asp:DropDownList ID="txtSemestre" runat="server" Width="401px">
                            <asp:ListItem Value="primer">primero</asp:ListItem>
                            <asp:ListItem>segundo</asp:ListItem>
                            <asp:ListItem Value="tercer">tercero</asp:ListItem>
                            <asp:ListItem>cuarto</asp:ListItem>
                            <asp:ListItem>quinto</asp:ListItem>
                            <asp:ListItem>sexto</asp:ListItem>
                            <asp:ListItem>septimo</asp:ListItem>
                            <asp:ListItem>octavo</asp:ListItem>
                            <asp:ListItem>noveno</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="Label5" runat="server" Text="Grupo:" Width="200px"></asp:Label>
                        <asp:DropDownList ID="txtGrupo" runat="server" Width="468px">
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>D</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="Label6" runat="server" Text="Cantidad de Alumnos Programados:" Width="200px"></asp:Label>
                        .<asp:TextBox ID="txtyCantidadAlumnos" runat="server" required Width="401px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="Label7" runat="server" Text="Especialidad:" Width="200px"></asp:Label>
                        <asp:DropDownList ID="txtEspecialidad" runat="server" Width="468px">
                            <asp:ListItem>IINF</asp:ListItem>
                            <asp:ListItem>IM</asp:ListItem>
                            <asp:ListItem>IA</asp:ListItem>
                            <asp:ListItem>II</asp:ListItem>
                            <asp:ListItem>IF</asp:ListItem>
                            <asp:ListItem>LB</asp:ListItem>
                            <asp:ListItem>LG</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
            </table>

            <br />

            <br />

            <br />
            <article class="titulo">
                <table>
                    <tr>
                        <td class="auto-style16">
                            <asp:Label ID="Label8" runat="server" Text="Objetivo:"></asp:Label>
                        </td>
                        <td class="auto-style16">
                            <asp:TextBox ID="txtObjetivo" runat="server" required Height="134px" TextMode="MultiLine" Width="1126px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="txtEncasoDeSerPractica2" runat="server" Text="En caso de ser Práctica (descripción de la misma):" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style11">
                            <asp:TextBox ID="txtEncasoPractica" runat="server" Height="153px" TextMode="MultiLine" Width="1126px" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    
                </table>
            

            </article>
            
            <br />

        </article>
        <article class="titulo">
            <header class="titulo"><h2>Datos de la empresa,organimos ó institucion</h2></header>

        </article>
        <br />
        <article>
            <section style="text-align:center">
                 <asp:Label ID="Label10" runat="server" Text="Nombre de la empresa, organismo ó institución:" Width="386px"></asp:Label>
                        <asp:TextBox ID="txtInstitucion" required runat="server" Width="618px"></asp:TextBox>
            </section>
                       
                   
            <br />
            <br />

            <table class="titulo">
                
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label11" runat="server" Text="Representante:" Width="150px"></asp:Label>

                        <asp:TextBox ID="txtRepresentante" runat="server" Width="404px"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="Label12" runat="server" Text="Puesto ó cargo:" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtPuestoOCargo" runat="server" Width="404px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label13" runat="server" Text="Dirección:" Width="150px"></asp:Label>

                        <asp:TextBox ID="txtDireccion" runat="server" Width="404px"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="Label14" runat="server" Text="Municipio / Estado:" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtMunicipioEstado" runat="server" required Width="404px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label20" runat="server" Text="Telefono:" Width="150px"></asp:Label>

                        <asp:TextBox ID="txtTelefonoEmpresa" runat="server" Width="404px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="Label15" runat="server" Text="Fax:" Width="200px"></asp:Label>

                         <asp:TextBox ID="txtFax" runat="server" Width="404px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style12">

                        <asp:Label ID="Label21" runat="server" Text="E-mail:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" Width="404px"></asp:TextBox>

                    </td>
                    <td class="auto-style7">

                        <asp:Label ID="Label22" runat="server" Text="Página Web:" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtPaginaWeb" runat="server" Width="404px" ></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label16" runat="server" Text="Fecha propuesta de la visita:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtFechaPropuesta" runat="server" Width="404px" required placeholder="24 de marzo"></asp:TextBox>
                    </td>
                    <td class="auto-style7">

                        <asp:Label ID="Label23" runat="server" Text="Hora propuesta" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtHoraPropuesta" runat="server" required Width="404px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                         <asp:Label ID="txtRecomendaciones" runat="server" Text="Recomendaciones:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtRecomedacionesOrganizacion" runat="server" Width="404px"></asp:TextBox>
                        
                    </td>
                    <td class="auto-style7">

                       <asp:Label ID="txtViajeNoche2" runat="server" Text="ViajePorlaNoche" Width="200px" Visible="False"></asp:Label>
                        <asp:DropDownList ID="txtViajeNoche" runat="server" Height="19px" Width="404px" Visible="False">
                            <asp:ListItem>SI</asp:ListItem>
                            <asp:ListItem>NO</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                </tr>
                
            </table>
            <br />
            <br />


            <section style="text-align:center">
                <asp:Button runat="server" Text="Generar Permiso" ID="BtnGenerarPermiso" OnClick="BtnGenerarPermiso_Click" />
            </section>

        </article>
        <br />
        <br />
        <br />



    </section>
</asp:Content>
