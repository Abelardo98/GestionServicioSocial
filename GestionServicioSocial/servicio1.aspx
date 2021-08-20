<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="servicio1.aspx.cs" Inherits="GestionServicioSocial.servicio1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Text1 {
            width: 293px;
        }
        #nota {
            padding-left: 70px;
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
        .auto-style16 {
            width: 1311px;
            height: 45px;
        }
        .auto-style18 {
            width: 1229px;
        }
        .auto-style20 {
            height: 3px;
        }
        .auto-style21 {
            height: 34px;
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
    <!--hasta aquiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii-->

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label10" runat="server" Text="Realiza el Servicio Social en el Instituto Tecnológico Superior de Zacapoaxtla:"></asp:Label>
           &nbsp;
           <asp:DropDownList ID="txtServicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtServicio_SelectedIndexChanged">
                <asp:ListItem>NO</asp:ListItem>
                <asp:ListItem>SI</asp:ListItem>
           </asp:DropDownList>
    <br />
    <br />

    <section id="contenido">
            
            <table class="auto-style16">
                <tr>
                    <td >
                        
                        <asp:Label ID="Label2" runat="server" Text="Nombre del lugar donde vas a realizar servicio social:" Width="400px"></asp:Label>
            
                        <asp:TextBox ID="txtDependenciaOficial" runat="server" Width="880px" required OnTextChanged="txtDependenciaOficial_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    
                </tr>

                <tr>
                    <td class="auto-style21" >
                         <asp:Label ID="Label3" runat="server" Text="Titular de la dependencia:" Width="400px"></asp:Label>
                         <asp:TextBox ID="txtTitularDependencia" runat="server" Width="880px" required OnTextChanged="txtTitularDependencia_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                        
                        <asp:Label ID="Label1" runat="server" Text="Puesto del titular de la dependencia:" Width="400px"></asp:Label>
            
                        <asp:TextBox ID="txtPuestoTitular" runat="server" Width="880px" required OnTextChanged="txtPuestoTitular_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
            </table>

        <section style="text-align:center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black" Font-Bold="True">En caso de conocer los siguientes datos ingresarlos sino dejarlos en blanco</asp:LinkButton> 
        </section>         
        <table class="auto-style16">
            <tr>
                <td >
                    <asp:Label ID="Label4" runat="server" Text="Área donde estará el alumno:" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtAreaAlumno" runat="server" Width="880px" value=" " AutoPostBack="True" OnTextChanged="txtAreaAlumno_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
                
            </tr>

            
            <tr>
                <td class="auto-style21">
                    <asp:Label ID="Label12" runat="server" Text="Con copia para (Nombre de la persona):" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtCopiaNombre" runat="server" Width="880px" value=" " OnTextChanged="txtNombrePersonaServicio_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Puesto de la persona:" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtCopiaPuesto" runat="server" Width="880px" value=" " OnTextChanged="txtNombrePersonaServicio_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Nombre de la persona con la que prestaras el servicio directamente (Quien será tu supervisor):" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtNombrePersonaServicio" runat="server" Width="880px" value=" " AutoPostBack="True" OnTextChanged="txtNombrePersonaServicio_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <table class="auto-style16">

             <tr>
                    
                    <td class="auto-style20">
                        <asp:Label ID="Label6" runat="server" Text="Puesto (Quien será tu supervisor):" Width="400px"></asp:Label>
            
                        <asp:TextBox ID="txtPuesto" runat="server" Width="880px" value=" " AutoPostBack="True" OnTextChanged="txtPuesto_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                 

                </tr>
                
                
        </table>
        <section style="text-align:center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black" Font-Bold="True">En caso de conocer los siguientes datos ingresarlos sino dejarlos en blanco</asp:LinkButton> 
        </section>
            
        <table class="auto-style16">
            <tr>
                <td>

                    <asp:Label ID="Label8" runat="server" Text="Nombre de programa:" Width="400px"></asp:Label>

                    <asp:TextBox ID="txtNombrePrograma" runat="server" Width="880px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Programa de actividades:" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtProgramaActividades" runat="server" Width="880px" value="ACTIVIDADES PLASMADAS EN EL PLAN DE TRABAJO" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >

                    <asp:Label ID="Label9" runat="server" Text="Tipo de programa:" Width="400px"></asp:Label>
                    <asp:DropDownList ID="txttipoprograma" runat="server" Width="880px" AutoPostBack="True" OnSelectedIndexChanged="txttipoprograma_SelectedIndexChanged">
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
                    <asp:Label ID="Label11" runat="server" Text="Especificar:" Visible="False" Width="400px"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False" value=" " Width="880px" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            
        </table>
        
        <br />
        <div id="nota" class="auto-style18">
        <p style="text-align:center">
            Nota: Al terminar el registro serás redireccionado al inicio de sesión donde 
            tendrás que ingresar tu número de control y contraseña, se mostrará tu perfil académico y deberás generar 
            tu solicitud y carta de presentación para el servicio social.
        </p>


            
        </div>
        <article id="botoon">
            <article >                
                  <asp:Button ID="BtnContinuar" runat="server" Text="Continuar" OnClick="BtnContinuar_Click" Height="34px" Width="161px" />
            </article>
        </article>

    </section>
    

</asp:Content>
