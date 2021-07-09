<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Residencia1.aspx.cs" Inherits="GestionServicioSocial.Recidencia1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Text1 {
            width: 293px;
        }

        #bloque11 {
            width: 1383px;
        }

        #Text8 {
            width: 370px;
        }

        .titulos {
            text-align: center;
            width: 1382px;
            height: 57px;
        }

        #botoon {
            text-align: center;
        }
        #contenido {
            
            padding-top:30px;
        }
        .auto-style1 {
            width: 768px;
        }
        .auto-style2 {
            width: 1398px;
        }
        .auto-style3 {
            width: 768px;
            height: 43px;
        }
        .auto-style4 {
            height: 43px;
        }
        .auto-style5 {
            width: 768px;
            height: 45px;
        }
        .auto-style6 {
            height: 45px;
        }
        .auto-style7 {
            width: 768px;
            height: 85px;
        }
        .auto-style8 {
            height: 85px;
        }
        .auto-style9 {
            width: 768px;
            height: 48px;
        }
        .auto-style10 {
            width: 1384px;
            height: 50px;
        }
        .auto-style11 {
            width: 1384px;
            height: 27px;
        }
        .auto-style12 {
            text-align: center;
            width: 1382px;
            height: 35px;
        }
        .auto-style13 {
            text-align: center;
            width: 1382px;
            height: 27px;
        }
        .auto-style14 {
            margin-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="titulos">
        <asp:Label ID="txtNumeroControl" runat="server" Text="N1" Visible="False"></asp:Label>
        <h1 style="width: 1384px; height: 53px;">Datos del Programa de Residencia Profesional</h1>  
    </header>
    <br />
    <br />
    <article style="width: 1379px">
                <asp:Label ID="Label7" runat="server" Text="Realiza la residencia profecional en el instituto Tecnológico superior de Zacapoaxtla:  "></asp:Label>
                 <asp:DropDownList ID="txtResidencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtResidencia_SelectedIndexChanged">
                     <asp:ListItem>NO</asp:ListItem>
                     <asp:ListItem>SI</asp:ListItem>
                 </asp:DropDownList>
            </article>
    <br />

    <section id="contenido">
        
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Razón social: " Width="200px"></asp:Label>            
                        <asp:TextBox ID="txtRazonSocial" runat="server" Width="540px" required></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                         <asp:Label ID="Label10" runat="server" Text="Tipo" Width="200px"></asp:Label>
                         <asp:DropDownList ID="txtTipo" runat="server" Width="405px">
                             <asp:ListItem>Público </asp:ListItem>
                             <asp:ListItem>Privado</asp:ListItem>
                             <asp:ListItem>Social</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label3" runat="server" Text="Nombre del titular:" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtTitularDependencia" runat="server" Width="540px" required></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                         <asp:Label ID="Label1" runat="server" Text="Puesto del Titular" Width="200px"></asp:Label>
            
                         <asp:TextBox ID="txtPuestoTitular" required runat="server" Width="405px"></asp:TextBox>
                    </td>
                </tr>
               
            </table>
        <asp:Panel ID="Panel2" runat="server" Height="25px">
            <header class="auto-style12">
            <h3 class="auto-style11">
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black">En caso de conocer los siguientes datos ingresarlos sino dejarlos en blanco</asp:LinkButton> </h3>  
            </header>
        </asp:Panel>           
        <table class="auto-style2">
             <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label4" runat="server" Text="Área donde estára el alumno:" Width="200px"></asp:Label>
            
                        <asp:TextBox ID="txtAreaAlumno" runat="server" Width="540px" value=" " AutoPostBack="True" OnTextChanged="txtAreaAlumno_TextChanged"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="Label5" runat="server" Text="Nombre de la persona con la que prestaras el servicio directamente:" Width="200px"></asp:Label>
            
                        <asp:TextBox ID="txtNombreAsesorExterno" runat="server" Width="405px" value=" " AutoPostBack="True" OnTextChanged="txtNombreAsesorExterno_TextChanged"></asp:TextBox>
                    </td>
                </tr>


              
        </table>
        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style14" Height="30px">
            <article id="ab">
             <header class="auto-style13"> 
            <h3 class="auto-style10">
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black">En caso de conocer los siguientes datos ingresarlos sino dejarlos en blanco</asp:LinkButton> </h3>  
            </header>
        </article>
        </asp:Panel>          
        <table class="auto-style2">
              <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label6" runat="server" Text="Puesto:" Width="200px"></asp:Label>
                         <asp:TextBox ID="txtPuestoAsesorExterno" runat="server" Width="540px" value=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Correo electrónico:" Width="200px"></asp:Label>              
                        <asp:TextBox ID="txtCorreo" runat="server" Width="405px"></asp:TextBox>
                    </td>
                </tr>
            <br />
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label8" runat="server" Text="Nombre del Proyecto:" Width="200px"></asp:Label>
                        <asp:TextBox ID="txtNombreProyecto" runat="server" Width="540px" value=" "></asp:TextBox>
                    </td>
                </tr>
        </table>
            

        
        
        <br />
        <br />
        <br />
        <br />
        <br />

        <article id="botoon">
            <article >             
                  <asp:Button ID="BtnContinuar" runat="server" Text="Continuar" OnClick="BtnContinuar_Click" Height="34px" Width="161px" />
            </article>
        </article>

        <br />
        <br />
    

    </section>
</asp:Content>
