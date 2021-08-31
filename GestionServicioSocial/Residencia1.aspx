<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Residencia1.aspx.cs" Inherits="GestionServicioSocial.Recidencia1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="swalert.js" type="text/javascript"></script>
    
    <script>
        function alertme() {
            Swal.fire(
                'Good job!',
                'You clicked the button!',
                'success'
            )
        }
    </script>
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
            
            padding-top:30px;
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
        .auto-style15 {
            height: 58px;
        }
        .auto-style16 {
            height: 47px;
        }
        .auto-style18 {
            width: 1398px;
            height: 157px;
        }
        .auto-style19 {
            height: 28px;
        }
        .auto-style20 {
            height: 50px;
        }
        .auto-style21 {
            height: 46px;
        }
        .auto-style22 {
            width: 768px;
            height: 36px;
        }
        .auto-style23 {
            height: 36px;
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
                <asp:Label ID="Label7" runat="server" Text="Realiza la Residencia Profesional en el Instituto Tecnológico Superior de Zacapoaxtla:  "></asp:Label>
                 <asp:DropDownList ID="txtResidencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtResidencia_SelectedIndexChanged">
                     <asp:ListItem>NO</asp:ListItem>
                     <asp:ListItem>SI</asp:ListItem>
                 </asp:DropDownList>
            </article>

    <section id="contenido">
        
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Nombre del lugar donde vas a realizar residencias profesionales: " Width="340px"></asp:Label>            
                        <asp:TextBox ID="txtRazonSocial" runat="server" Width="400px" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                         <asp:Label ID="Label10" runat="server" Text="Tipo" Width="200px"></asp:Label>
                         <asp:DropDownList ID="txtTipo" runat="server" Width="405px">
                             <asp:ListItem>Público</asp:ListItem>
                             <asp:ListItem>Privado</asp:ListItem>
                             <asp:ListItem>Social</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        <asp:Label ID="Label3" runat="server" Text="Nombre del titular:" Width="340px"></asp:Label>
                        <asp:TextBox ID="txtTitularDependencia" runat="server" Width="400px" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    <td class="auto-style23">
                         <asp:Label ID="Label1" runat="server" Text="Puesto del titular" Width="200px"></asp:Label>
            
                         <asp:TextBox ID="txtPuestoTitular" required runat="server" Width="405px" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
            
               
            </table>
        <section style="text-align:center">
            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black" Font-Bold="True">En caso de conocer los siguientes datos, ingresarlos, si no, dejarlos en blanco</asp:LinkButton>
        </section>
        <table class="auto-style18">
            <tr>
                <td class="auto-style15">
                    <asp:Label ID="Label4" runat="server" Text="Área en donde estará ubicado el residente:" Width="300px"></asp:Label>

                    <asp:TextBox ID="txtAreaAlumno" runat="server" Width="1000px" value=" " AutoPostBack="True" OnTextChanged="txtAreaAlumno_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="auto-style15">
                    <asp:Label ID="Label9" runat="server" Text="Si requieres que tu documento sea dirigido con atención a una persona en especifico, puedes colocarlo, en caso contrario dejar en blanco:" Width="300px"></asp:Label>

                    <asp:TextBox ID="txtCopiaNombre" runat="server" Width="1000px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>
                        <tr>
                <td class="auto-style15">
                    <asp:Label ID="Label12" runat="server" Text="Puesto de la persona a quien va dirigido el documento:" Width="300px"></asp:Label>

                    <asp:TextBox ID="txtCopiaPuesto" runat="server" Width="1000px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="auto-style16">
                    <asp:Label ID="Label5" runat="server" Text="Nombre de la persona con la que prestaras el servicio directamente (Quien será tu asesor externo):" Width="300px"></asp:Label>

                    <asp:TextBox ID="txtNombreAsesorExterno" runat="server" Width="1000px" value=" " AutoPostBack="True" OnTextChanged="txtNombreAsesorExterno_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:Label ID="Label6" runat="server" Text="Puesto (Quien será tu asesor externo):" Width="300px"></asp:Label>
                    <asp:TextBox ID="txtPuestoAsesorExterno" runat="server" Width="1000px" value=" " AutoPostBack="True" OnTextChanged="txtPuestoAsesorExterno_TextChanged" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
        </table>
        <section style="text-align:center">
         <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black" Font-Bold="True">En caso de conocer los siguientes datos, ingresarlos. Si no, dejarlos en blanco</asp:LinkButton>
        </section>


        <table class="auto-style2">
              <tr>
                    
                    <td class="auto-style20">
                        <asp:Label ID="Label11" runat="server" Text="Correo electrónico del asesor externo:" Width="300px"></asp:Label>              
                        <asp:TextBox ID="txtCorreo" runat="server" Width="1000px"></asp:TextBox>
                    </td>
                  
                </tr>
                <tr>
                    <td class="auto-style21">
                        <asp:Label ID="Label8" runat="server" Text="Nombre del proyecto:" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtNombreProyecto" runat="server" Width="1000px" onkeyup="javascript:this.value=this.value.toUpperCase();" value=" "></asp:TextBox>
                    </td>
                </tr>
               
        </table>

        <br />
        
        <div id="nota" style="width: 1222px">
        <p style="text-align:center">
            Nota: Al terminar el registro serás redireccionado al inicio de sesión donde 
            tendrás que ingresar tu número de control y contraseña, se mostrará tu perfil académico y deberás generar 
            tu solicitud y carta de presentación para la residencia profesional.
        </p>


            
        </div>
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
