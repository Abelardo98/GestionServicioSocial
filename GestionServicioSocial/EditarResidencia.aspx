
<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="EditarResidencia.aspx.cs" Inherits="GestionServicioSocial.EditarResidencia" %>
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

    </style>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Label29" runat="server" Text="Numero de Control"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtbuscar" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BTN_Buscar" runat="server" Text="Buscar" OnClick="BTN_Buscar_Click" />
    <br />
    <br />
    
    <header class="titulo">
        <h1 class="titulos">Información Personal</h1>
    </header>

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

                         <asp:DropDownList ID="txtEdad" runat="server" Width="300px">
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
                             <asp:ListItem>34</asp:ListItem>
                             <asp:ListItem>35</asp:ListItem>
                             <asp:ListItem>36</asp:ListItem>
                             <asp:ListItem>37</asp:ListItem>
                             <asp:ListItem>38</asp:ListItem>
                             <asp:ListItem>39</asp:ListItem>
                             <asp:ListItem>40</asp:ListItem>
                             <asp:ListItem>41</asp:ListItem>
                             <asp:ListItem>42</asp:ListItem>
                             <asp:ListItem>43</asp:ListItem>
                             <asp:ListItem>44</asp:ListItem>
                             <asp:ListItem>45</asp:ListItem>
                             <asp:ListItem>46</asp:ListItem>
                             <asp:ListItem>47</asp:ListItem>
                             <asp:ListItem>48</asp:ListItem>
                             <asp:ListItem>49</asp:ListItem>
                             <asp:ListItem>50</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style16">
                        <asp:Label ID="Label5" runat="server" Text="Género: " Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtgenero" runat="server" Width="300px">
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
                        <asp:TextBox ID="txtCodigoPostal" runat="server" Width="300px" pattern="[0-9]+" title="Solo ingresa Números" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="Label9" runat="server" Text="Localidad:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtLocalidad" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="Label10" runat="server" Text="Municipio:" Width="150px"></asp:Label>
            
                        <asp:TextBox ID="txtMunicipio" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Estado:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtestado" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label23" runat="server" Text="Teléfono:" Width="150px"></asp:Label>
            
                        <asp:TextBox ID="txttelefono" runat="server" type="number" pattern="[0-9]+" title="Solo ingresa Números" placeholder="233 121 99 48" MaxLength="10" Width="300px"></asp:TextBox>
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
            <h1>Información Escolar</h1>
        </header>

        &nbsp;<br />
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
                         <asp:Label ID="TxtCarrera" runat="server" Text="Label"></asp:Label>
                    </td>
                     <td>
                         <asp:Label ID="Label14" runat="server" Text="Periodo:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtPeriodo" runat="server" Width="300px">
                            <asp:ListItem>Enero-Junio</asp:ListItem>
                            <asp:ListItem>Verano</asp:ListItem>
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
                            <asp:ListItem>13</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <td class="auto-style21">
                         <asp:Label ID="Label17" runat="server" Text="Modalidad para la Residencia:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtModalidad" runat="server" Height="25px" Width="300px">
                            <asp:ListItem>Presencial</asp:ListItem>
                            <asp:ListItem>Virtual</asp:ListItem>
                            <asp:ListItem>Mixto</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <td class="auto-style22">
                         <asp:Label ID="Label26" runat="server" Text="Inscrito" Width="150px"></asp:Label>
                         <asp:DropDownList ID="txtInscrito" runat="server" Width="300px">
                            <asp:ListItem>SI</asp:ListItem>
                            <asp:ListItem>NO</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style18">
                        <asp:Label ID="Label30" runat="server" Text="Número de Seguro Facultativo IMSS:" Width="150px"></asp:Label>

                        <asp:TextBox ID="txtNumeroFacultativo" runat="server" type="number" Width="300px"></asp:TextBox>
                    </td>
                     <td class="auto-style19">
                         <asp:Label ID="Label31" runat="server" Text="Créditos Aprobados: " Width="150px"></asp:Label>

                         <asp:Label ID="txtCreditos" runat="server" Width="300px"></asp:Label>
                    </td>
                     <td>
                         
                    </td>
                </tr>
               
            </table>
            <br />
            <asp:Label ID="Label34" runat="server" Text="Nota: contraseña para iniciar sesión: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtContraseña" runat="server" Width="275px"></asp:TextBox>
            <br />
        </article>
        <br />
        <br />
        <br />
    </section>
    <br />

                                                <!--Division de partes-->


    <header class="titulos">
        <asp:Label ID="Label3" runat="server" Text="N1" Visible="False"></asp:Label>
        <h1 style="width: 1384px; height: 53px;">Datos del Programa de Residencia Profesional</h1>  
    </header>
    <br />
    <br />
    <article style="width: 1379px">
                <asp:Label ID="Label4" runat="server" Text="Realiza la Residencia Profesional en el Instituto Tecnológico Superior de Zacapoaxtla:  "></asp:Label>
                 <asp:DropDownList ID="txtResidencia" runat="server" >
                     <asp:ListItem>NO</asp:ListItem>
                     <asp:ListItem>SI</asp:ListItem>
                 </asp:DropDownList>
    </article>
    <br />

    <section id="contenido">
        
            <table class="auto-style2">
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Nombre del lugar donde vas a realizar residencias profesionales: " Width="300px"></asp:Label>            
                        <asp:TextBox ID="txtRazonSocial" runat="server" Width="1078px" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="Label18" runat="server" Text="Tipo" Width="300px"></asp:Label>
                         <asp:DropDownList ID="txtTipo" runat="server" Width="1078px">
                             <asp:ListItem>Público</asp:ListItem>
                             <asp:ListItem>Privado</asp:ListItem>
                             <asp:ListItem>Social</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="Nombre del titular:" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtTitularDependencia" runat="server" Width="1078px" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="Label24" runat="server" Text="Puesto del titular" Width="300px"></asp:Label>
            
                         <asp:TextBox ID="txtPuestoTitular" required runat="server" Width="1078px" onkeyup="javascript:this.value=this.value.toUpperCase();" Wrap="False"></asp:TextBox>
                    </td>
                </tr>
            
               
            </table>
        
        <table class="auto-style2">
            <tr>
                <td class="auto-style15">
                    <asp:Label ID="Label25" runat="server" Text="Área en donde estará ubicado el residente:" Width="300px"></asp:Label>

                    <asp:TextBox ID="txtAreaAlumno" runat="server" Width="1078px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>
                        <tr>
                <td class="auto-style15">
                    <asp:Label ID="Label27" runat="server" Text="Con copia para (Nombre de la persona):" Width="300px"></asp:Label>

                    <asp:TextBox ID="txtCopiaNombre" runat="server" Width="1078px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>
                        <tr>
                <td class="auto-style15">
                    <asp:Label ID="Label28" runat="server" Text="Puesto de la persona:" Width="300px"></asp:Label>

                    <asp:TextBox ID="txtCopiaPuesto" runat="server" Width="1078px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label32" runat="server" Text="Nombre de la persona con la que prestaras el servicio directamente (Quien será tu asesor externo):" Width="300px"></asp:Label>

                    <asp:TextBox ID="txtNombreAsesorExterno" runat="server" Width="1078px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="Puesto (Quien será tu asesor externo):" Width="300px"></asp:Label>
                    <asp:TextBox ID="txtPuestoAsesorExterno" runat="server" Width="1078px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table class="auto-style2">
              <tr>
                    
                    <td>
                        <asp:Label ID="Label35" runat="server" Text="Correo electrónico del asesor externo:" Width="300px"></asp:Label>              
                        <asp:TextBox ID="txtCorreoAsesorExterno" runat="server" Width="1078px"></asp:TextBox>
                    </td>
                  
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label36" runat="server" Text="Nombre del proyecto:" Width="300px"></asp:Label>
                        <asp:TextBox ID="txtNombreProyecto" runat="server" Width="1078px" onkeyup="javascript:this.value=this.value.toUpperCase();" value=" "></asp:TextBox>
                    </td>
                </tr>
               
        </table>
        <br />
        <br />

        <br />


        <article>
            <article id="botones">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar cambios" OnClick="BtnGuardar_Click1" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegresar" runat="server" Text="Cancelar" OnClick="btnRegresar_Click" />

            </article>
        </article>

        <br />
        <br />
    </section>
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="16px" Width="362px" Visible="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True">
                        <ControlStyle Font-Bold="True" ForeColor="#0066FF" />
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

    


</asp:Content>
