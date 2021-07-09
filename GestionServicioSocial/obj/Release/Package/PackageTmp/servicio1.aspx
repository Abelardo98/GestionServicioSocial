<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="servicio1.aspx.cs" Inherits="GestionServicioSocial.servicio1" %>
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
            
            text-align:center;
        }
        .auto-style2 {
            width: 1311px;
        }
        .auto-style7 {
            width: 692px;
            height: 77px;
        }
        .auto-style8 {
            height: 77px;
            width: 691px;
        }
        .auto-style10 {
            height: 59px;
            width: 691px;
        }
        .auto-style13 {
            width: 651px;
            height: 27px;
        }
        .auto-style14 {
            height: 27px;
        }
        .auto-style15 {
            height: 59px;
            width: 692px;
        }
        .auto-style16 {
            width: 1311px;
            height: 45px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <header class="titulos">
        <asp:Label ID="txtNumeroControl" runat="server" Text="N1" Visible="False"></asp:Label>
    <h1 style="width: 1384px; height: 53px;">Datos del Programa de Servicio Social</h1>
        
    </header>
    <br />
    <br />
    <asp:Label ID="Label10" runat="server" Text="Realiza el servicio social en el instituto Tecnológico superior de Zacapoaxtla:"></asp:Label>
           <asp:DropDownList ID="txtServicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtServicio_SelectedIndexChanged">
                <asp:ListItem>NO</asp:ListItem>
                <asp:ListItem>SI</asp:ListItem>
           </asp:DropDownList>
    <br />
    <br />

    <section id="contenido">
            
            <table class="auto-style16">
                <tr>
                    <td class="auto-style13">
                        
                        <asp:Label ID="Label2" runat="server" Text="Dependencia Oficial:" Width="200px"></asp:Label>
            
                        <asp:TextBox ID="txtDependenciaOficial" runat="server" Width="350px" required OnTextChanged="txtDependenciaOficial_TextChanged"></asp:TextBox>
                    </td>
                    <td class="auto-style14">
                         <asp:Label ID="Label3" runat="server" Text="Titular de la Dependencia:" Width="200px"></asp:Label>
                         <asp:TextBox ID="txtTitularDependencia" runat="server" Width="350px" required OnTextChanged="txtTitularDependencia_TextChanged"></asp:TextBox>
                    </td>
                </tr> 
            </table>
        <br />
        <table class="auto-style16">
            <tr>
                    <td class="auto-style11">
                        
                        <asp:Label ID="Label1" runat="server" Text="Puesto del Titular de la Dependencia:" Width="400px"></asp:Label>
            
                        <asp:TextBox ID="txtPuestoTitular" runat="server" Width="600px" required OnTextChanged="txtPuestoTitular_TextChanged"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        
                    </td>
                </tr>
        </table>

            <asp:Panel ID="Panel2" runat="server" Height="25px">
            
            <h3>
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black">En caso de conocer los siguientes datos ingresarlos sino dejarlos en blanco</asp:LinkButton> </h3>  
            
            </asp:Panel>           

        
        <table class="auto-style2">
             <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label4" runat="server" Text="Área donde estára el alumno:" Width="200px"></asp:Label>
            
                        <asp:TextBox ID="txtAreaAlumno" runat="server" Width="350px" value=" " AutoPostBack="True" OnTextChanged="txtAreaAlumno_TextChanged"></asp:TextBox>
                        
                    </td>
                <td class="auto-style7">
                        
                        <asp:Label ID="Label5" runat="server" Text="Nombre de la Persona con la que prestaras el servicio directamente:" Width="200px"></asp:Label>
            
                        <asp:TextBox ID="txtNombrePersonaServicio" runat="server" Width="350px" value=" " AutoPostBack="True" OnTextChanged="txtNombrePersonaServicio_TextChanged"></asp:TextBox>
                    </td>

            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Height="25px">
            
            <h3>
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black">En caso de conocer los siguientes datos ingresarlos sino dejarlos en blanco</asp:LinkButton> </h3>  
            
            </asp:Panel> 
        <table class="auto-style2">

             <tr>
                    
                    <td class="auto-style8">
                        <asp:Label ID="Label6" runat="server" Text="Puesto:" Width="200px"></asp:Label>
            
                        <asp:TextBox ID="txtPuesto" runat="server" Width="350px" value=" "></asp:TextBox>
                    </td>
                 <td class="auto-style7">
                        
                        <asp:Label ID="Label8" runat="server" Text="Nombre de programa:" Width="200px"></asp:Label>
            
                        <asp:TextBox ID="txtNombrePrograma" runat="server" Width="350px" value=" "></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    
                    <td class="auto-style10">
                        <asp:Label ID="Label7" runat="server" Text="Programa de actividades:" Width="200px"></asp:Label>           
                        <asp:TextBox ID="txtProgramaActividades" runat="server" Width="350px" value=" "></asp:TextBox>
                    </td>
                    <td class="auto-style15">
                        
                        <asp:Label ID="Label9" runat="server" Text="Tipo de Programa:" Width="200px"></asp:Label>
                        <asp:DropDownList ID="txttipoprograma" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="txttipoprograma_SelectedIndexChanged">
                            <asp:ListItem>EDUCACIÓN PARA ADULTOS</asp:ListItem>
                            <asp:ListItem>ACTIVIDADES CÍVICAS</asp:ListItem>
                            <asp:ListItem>DESRROLLO SUSTENTABLE</asp:ListItem>
                            <asp:ListItem>DESARROLLO DE LA COMUNIDAD</asp:ListItem>
                            <asp:ListItem>ACTIVIDADES CULTURALES</asp:ListItem>
                            <asp:ListItem>APOYO A LA SALUD</asp:ListItem>
                            <asp:ListItem>ACTIVIDADES DEPORTIVAS</asp:ListItem>
                            <asp:ListItem>MEDIO AMBIENTE</asp:ListItem>
                            <asp:ListItem>OTRO</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Especificar:" Visible="False" Width="200px"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" value=" "  Width="350px"></asp:TextBox>
                    </td>
                </tr>
                
        </table>


        
        <br />
        <br />
        <article id="botoon">
            <article >                
                  <asp:Button ID="BtnContinuar" runat="server" Text="Continuar" OnClick="BtnContinuar_Click" Height="34px" Width="161px" />
            </article>
        </article>

    </section>
    

</asp:Content>
