<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="servicio3.aspx.cs" Inherits="GestionServicioSocial.servicio3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #botones {
            text-align: center;
        }

        #titulo {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header id="titulos">
        <h1>Para uso Exclusivo de Departamento de RPySS

        </h1>

    </header>
    <br />
    <br />
    <section style="width: 1251px">

        <article>
            <asp:Label ID="Label1" runat="server" Text="Modalidad:"></asp:Label>
            <asp:TextBox ID="txtmodalidad" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            &nbsp;<asp:Label ID="txtNumeroControl" runat="server" Text="N" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:Button ID="BtnfechaInicio" runat="server" Text="Seleccionar Fecha De Inicio" Width="218px" />
            &nbsp;&nbsp;<asp:TextBox ID="txtinicio" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="BtnFechatermi" runat="server" Text="Seleccionar Fecha Terminación" Width="242px" />
            &nbsp;
            <asp:TextBox ID="txttermi" runat="server"></asp:TextBox>

            <section>
                <table>

                    <tr>
                        <td>
                            <asp:Calendar ID="Calendar2" runat="server" ></asp:Calendar>

                        </td>

                        <td>
                            <asp:Calendar ID="Calendar3" runat="server" ></asp:Calendar>
                        </td>



                    </tr>
                </table>

            </section>

            &nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Aceptado:"></asp:Label>

            &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="txtaseptado" runat="server">
                <asp:ListItem>SI</asp:ListItem>
                <asp:ListItem>NO</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:Label ID="Label7" runat="server" Text="Motivo:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtmotivo" runat="server"></asp:TextBox>
            &nbsp; Observaciones
            <asp:TextBox ID="txtobservaciones" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />

        </article>

        <br />
        <br />
        <article id="botones">
            <asp:Button ID="Button1" runat="server" Text="Guardar" /><asp:Button ID="Button2" runat="server" Text="Generar" />

        </article>
    </section>
</asp:Content>
