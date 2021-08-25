<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="EditarServicoAlumno.aspx.cs" Inherits="GestionServicioSocial.EditarServicoAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <meta charset="utf-8" />
    <meta charset="iso-8859-1" />
    <meta charset="iso-8859-15" />
    <meta charset="iso-8859-2" />
    <meta charset="us-ascii" />

   <style type="text/css">
        #Text1 {
            width: 232px;
        }

        .titulos {
            text-align: center;
            width: 1250px;
        }
        #contenido {
            
            padding-left:100px;
        }

        #botones {
            text-align: center;
        }

        #Text2 {
            width: 416px;
        }


        #Text5 {
            width: 221px;
        }

        #Text7 {
            width: 139px;
        }

        #Text8 {
            width: 161px;
        }
        #Content2 {
            width: 50px;
            background-color:aqua;
        }

        .auto-style6 {
            height: 34px;
        }
        
        .auto-style12 {
            width: 1419px;
        }
        .auto-style13 {
            width: 469px;
            height: 34px;
        }
        .auto-style16 {
            width: 465px;
            height: 34px;
        }

        .auto-style17 {
            width: 469px;
        }
        .auto-style18 {
            width: 465px;
        }
        .auto-style19 {
            width: 463px;
        }

        .auto-style20 {
            width: 465px;
            height: 39px;
        }
        .auto-style21 {
            width: 463px;
            height: 39px;
        }
        .auto-style22 {
            height: 39px;
        }

       .auto-style35 {
           width: 1424px;
           height: 34px;
       }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="titulo">
        <h1 class="titulos">IInformación Personal</h1>
    </header>
    <br />
    <asp:TextBox ID="txtbuscar" runat="server" Width="185px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="BTN_Buscar" runat="server" Text="Buscar" OnClick="BTN_Buscar_Click1" />

    <br />
    <br />

    <section style="width: 1254px">


        <article>

            <table class="auto-style12">
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="Label1" runat="server" Text="Nómbre:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtnombre" runat="server" Width="300px" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="Label20" runat="server" Text="Apellido Paterno:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtAp" runat="server" Width="300px" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="Apellido Materno:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtAm" runat="server" TextMode="Search" Width="300px" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label2" runat="server" Text="Edad:" Width="150px"></asp:Label>

                         <asp:DropDownList ID="txtedad" runat="server" Width="300px">
                            <asp:ListItem Value="17"></asp:ListItem>
                            <asp:ListItem Value="18"></asp:ListItem>
                            <asp:ListItem Value="19"></asp:ListItem>
                            <asp:ListItem Value="20"></asp:ListItem>
                            <asp:ListItem Value="21"></asp:ListItem>
                            <asp:ListItem Value="22"></asp:ListItem>
                            <asp:ListItem Value="23"></asp:ListItem>
                            <asp:ListItem Value="24"></asp:ListItem>
                            <asp:ListItem Value="25"></asp:ListItem>
                            <asp:ListItem Value="26"></asp:ListItem>
                            <asp:ListItem Value="27"></asp:ListItem>
                            <asp:ListItem Value="28"></asp:ListItem>
                            <asp:ListItem Value="29"></asp:ListItem>
                            <asp:ListItem Value="30"></asp:ListItem>
                            <asp:ListItem Value="31"></asp:ListItem>
                            <asp:ListItem Value="32"></asp:ListItem>
                            <asp:ListItem Value="33"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style16">
                        <asp:Label ID="Label5" runat="server" Text="Género: " Width="150px"></asp:Label>

                         <asp:DropDownList ID="txtGenero" runat="server" Width="300px">
                             <asp:ListItem>H</asp:ListItem>
                             <asp:ListItem>M</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style6">
                         <asp:Label ID="Label6" runat="server" Text="Estado Civil:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtEstadoCivil" runat="server" Width="300px">
                            <asp:ListItem>Soltero</asp:ListItem>
                            <asp:ListItem>Casado</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="Label22" runat="server" Text="Correo Electrónico:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtcorreo" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="Label7" runat="server" Text="Domicilio:" Width="150px"></asp:Label>
            
                        <asp:TextBox ID="txtDomicilio" runat="server" Width="300px" placeholder="Calle: Ejemplo # 1, Zacapoaxtla, Puebla" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
            
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Código Postal:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtCodigoPostal" runat="server" Width="300px" pattern="[0-9]+" title="Solo ingresa Números" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="Label9" runat="server" Text="Localidad:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtLocalidad" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" onkeyup="javascript:this.value=this.value.toUpperCase();" ></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="Label10" runat="server" Text="Municipio:" Width="150px"></asp:Label>
            
                        <asp:TextBox ID="txtMunicipio" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" onkeyup="javascript:this.value=this.value.toUpperCase();" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Estado:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtestado" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label23" runat="server" Text="Telefono:" Width="150px"></asp:Label>
            
                        <asp:TextBox ID="txttelefono" type="number" runat="server" pattern="[0-9]+" title="Solo ingresa Números" placeholder="233 121 99 48" MaxLength="10" Width="300px"></asp:TextBox>
                    </td>
                    <td class="auto-style16">

                    </td>
                    <td class="auto-style6">

                    </td>
                </tr>
            </table>

        </article>
        <br />
        <br />

        <header class="titulos">
            <h1>Información Escolar/h1>
        </header>

        <br />
        <br />
        <article>
            <table class="auto-style12">
                <tr>
                    <td class="auto-style18">
                        <asp:Label ID="Label12" runat="server" Text="Número de Control:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtNumeroControl" runat="server" Width="300px" ReadOnly="True" ></asp:TextBox>
                    </td>
                     <td class="auto-style19">
                         <asp:Label ID="Label13" runat="server" Text="Carrera:" Width="150px"></asp:Label> 
                         <asp:Label ID="TxtCarrera" runat="server" Text="Label" Width="300px"></asp:Label>
                    </td>
                     <td>
                         <asp:Label ID="Label14" runat="server" Text="Periodo:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtPeriodo" runat="server" Width="300px">
                            <asp:ListItem>Enero-Junio</asp:ListItem>
                            <asp:ListItem>Julio-Diciembre</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label15" runat="server" Text="Semestre:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtSemestre" runat="server" Width="300px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <td class="auto-style21">
                         <asp:Label ID="Label17" runat="server" Text="Modalidad para el Servicio:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtModalidad" runat="server" Height="25px" Width="300px">
                            <asp:ListItem>Presencial</asp:ListItem>
                            <asp:ListItem>Virtual</asp:ListItem>
                            <asp:ListItem>Mixto</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <td class="auto-style22">
                         <asp:Label ID="Label29" runat="server" Text="Inscrito:" Width="150px"></asp:Label>
                         <asp:DropDownList ID="txtInscrito" runat="server" Width="300px">
                            <asp:ListItem>SI</asp:ListItem>
                            <asp:ListItem>NO</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style18">
                        <asp:Label ID="Label30" runat="server" Text="Créditos Aprobados: " Width="150px"></asp:Label>
                        <asp:Label ID="txtCreditos" runat="server" Width="300px"></asp:Label>

                    </td>
                     <td class="auto-style19">
                         
                    </td>
                     <td>
                         
                    </td>
                </tr>
               
            </table>
            <br />
            <asp:Label ID="Label31" runat="server" Text="Nota: contraseña para iniciar sesión: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtcontraseña" runat="server" Width="275px"></asp:TextBox>
            <br />
        </article>
    </section>


                                                                     <!--Division-->



    
    <header class="titulos">
        <asp:Label ID="Label3" runat="server" Text="N1" Visible="False"></asp:Label>
    <h1 style="width: 1384px; height: 53px;">Datos del Programa de Servicio Social</h1>
        
    </header>
    <br />
    <br />
    <!--Hasta aquiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii-->
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label runat="server" Text="Realiza el Servicio Social en el Instituto Tecnológico Superior de Zacapoaxtla:"></asp:Label>
           &nbsp;
           <asp:DropDownList ID="txtServicio" runat="server">
                <asp:ListItem>NO</asp:ListItem>
                <asp:ListItem>SI</asp:ListItem>
           </asp:DropDownList>
    <br />
    <br />

    <section id="contenido">
            
            <table class="auto-style35">
                <tr>
                    <td >
                        
                        <asp:Label ID="Label16" runat="server" Text="Nombre del lugar donde vas a realizar servicio social:" Width="400px"></asp:Label>
            
                        <asp:TextBox ID="txtDependenciaOficial" runat="server" Width="880px" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    
                </tr>

                <tr>
                    <td >
                         <asp:Label ID="Label18" runat="server" Text="Titular de la dependencia:" Width="400px"></asp:Label>
                         <asp:TextBox ID="txtTitularDependencia" runat="server" Width="880px" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                        
                        <asp:Label ID="Label19" runat="server" Text="Puesto del titular de la dependencia:" Width="400px"></asp:Label>
            
                        <asp:TextBox ID="txtPuestoTitular" runat="server" Width="880px" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
            </table>

        
        <table class="auto-style35">
            <tr>
                <td >
                    <asp:Label ID="Label24" runat="server" Text="Área donde estará el alumno:" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtAreaAlumno" runat="server" Width="880px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Con copia para (Nombre de la persona):" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtCopiaNombre" runat="server" Width="880px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label37" runat="server" Text="Puesto de la persona:" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtCopiaPuesto" runat="server" Width="880px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Nombre de la persona con la que prestaras el servicio directamente (Quien será tu supervisor):" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtNombrePersonaServicio" runat="server" Width="880px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <table class="auto-style35">

             <tr>
                    
                    <td>
                        <asp:Label ID="Label26" runat="server" Text="Puesto de (Quien será tu supervisor):" Width="400px"></asp:Label>
            
                        <asp:TextBox ID="txtPuesto" runat="server" Width="880px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                 

                </tr>
                
                
        </table>
        <section style="text-align:center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              
        </section>
            
        <table class="auto-style35">
            <tr>
                <td>

                    <asp:Label ID="Label27" runat="server" Text="Nombre del programa:" Width="400px"></asp:Label>

                    <asp:TextBox ID="txtNombrePrograma" runat="server" Width="880px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label28" runat="server" Text="Programa actividades:" Width="400px"></asp:Label>
                    <asp:TextBox ID="txtProgramaActividades" runat="server" Width="880px" value="ACTIVIDADES PLASMADAS EN EL PLAN DE TRABAJO" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >

                    <asp:Label ID="Label32" runat="server" Text="Tipo de programa:" Width="400px"></asp:Label>
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
                    <asp:Label ID="Label33" runat="server" Text="Especificar:" Visible="False" Width="400px"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False" value=" " Width="880px" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            
        </table>


        <br />
        <br />
        <asp:Label ID="Label34" runat="server" Text="Fecha inicio del servicio:"></asp:Label>&nbsp; <asp:TextBox ID="txtFechaInicioServ" runat="server"></asp:TextBox>
        &nbsp;
            <asp:Label ID="Label35" runat="server" Text="Fecha terminación del servicio:"></asp:Label>
&nbsp;<asp:TextBox ID="txtFechaTerminoServ" runat="server"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label36" runat="server" Text="Correo asesor externo:"></asp:Label>
&nbsp;<asp:TextBox ID="txtCorreoAcesorExterno" runat="server"></asp:TextBox>
        <br />
        <br />
        <article style="text-align:center">
            <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Width="195px" OnClick="BtnCancelar_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar Cambios" OnClick="BtnGuardar_Click1" />
        </article>

    </section>
    <br />
    <asp:GridView ID="GridView1" runat="server" Visible="False"></asp:GridView>

</asp:Content>
