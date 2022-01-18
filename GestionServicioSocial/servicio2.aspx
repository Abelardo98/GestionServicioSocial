<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="servicio2.aspx.cs" Inherits="GestionServicioSocial.servicio2" %>
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

        .auto-style6 {
            height: 34px;
        }
        
        .auto-style11 {
            width: 1545px;
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
    <header class="titulo">
        <h1 class="titulos">Información Personal</h1>
    </header>

    <section style="width: 1254px">


        <article>

            <table class="auto-style12">
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="Label1" runat="server" Text="Nómbre:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtnombre" runat="server" Width="300px" required ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="Label20" runat="server" Text="Apellido Paterno:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtAp" runat="server" required ReadOnly="True" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="Apellido Materno:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtAm" runat="server" ReadOnly="True" TextMode="Search" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label24" runat="server" Text="Edad:" Width="150px"></asp:Label>

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
                        <asp:Label ID="Label2" runat="server" Text="Género: " Width="150px"></asp:Label>

                         <asp:Label ID="txtGenero" runat="server" Width="300px"></asp:Label>
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
                        <asp:TextBox ID="txtcorreo" runat="server" required Width="300px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="Label7" runat="server" Text="Domicilio:" Width="150px"></asp:Label>
            
                        <asp:TextBox ID="txtDomicilio" runat="server" Width="300px" required placeholder="Calle: Ejemplo # 1, Zacapoaxtla, Puebla" 
                            onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
            
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Código Postal:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtCodigoPostal" runat="server" Width="300px" pattern="[0-9]+" title="Solo ingresa Números" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="Label9" runat="server" Text="Localidad:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtLocalidad" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:Label ID="Label10" runat="server" Text="Municipio:" Width="150px"></asp:Label>
            
                        <asp:TextBox ID="txtMunicipio" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Estado:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtestado" runat="server" Width="300px" pattern="[A-Z,a-z, ]+" title="Solo ingresa letras" required onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label23" runat="server" Text="Teléfono:" Width="150px"></asp:Label>
            
                        <asp:TextBox ID="txttelefono" type="number" runat="server" pattern="[0-9]+" title="Solo ingresa Números" placeholder="233 121 99 48" MaxLength="10" required Width="300px"></asp:TextBox>
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

        <br />
        <br />
        <article>
            <table class="auto-style12">
                <tr>
                    <td class="auto-style18">
                        <asp:Label ID="Label12" runat="server" Text="Número de Control:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtNumeroControl" runat="server" Width="300px" require ReadOnly="True" ></asp:TextBox>
                    </td>
                     <td class="auto-style19">
                         <asp:Label ID="Label13" runat="server" Text="Carrera:" Width="150px"></asp:Label> 
                         <asp:Label ID="TxtCarrera" runat="server" Text="Label" Width="300px"></asp:Label>
                    </td>
                     <td>
                         <asp:Label ID="Label14" runat="server" Text="Periodo:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtPeriodo" runat="server" Width="300px">
                            <asp:ListItem>Enero-Junio</asp:ListItem>
                            <asp:ListItem>Febrero-Julio</asp:ListItem>
                            <asp:ListItem>Julio-Diciembre</asp:ListItem>
                            <asp:ListItem>Agosto-Enero</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label15" runat="server" Text="Semestre:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtSemestre" runat="server" Width="300px">
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
                         <asp:Label ID="Label25" runat="server" Text="Modalidad para el Servicio:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="txtModalidad" runat="server" Height="25px" Width="300px">
                            <asp:ListItem>Presencial</asp:ListItem>
                            <asp:ListItem>Virtual</asp:ListItem>
                            <asp:ListItem>Mixto</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                     <td class="auto-style22">
                         <asp:Label ID="Label5" runat="server" Text="Inscrito:" Width="150px"></asp:Label>
                         <asp:DropDownList ID="txtInscrito" runat="server" Width="300px">
                            <asp:ListItem>SI</asp:ListItem>
                            <asp:ListItem>NO</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style18">
                        <asp:Label ID="Label26" runat="server" Text="Créditos Aprobados:" Width="150px"></asp:Label>
                        <asp:Label ID="txtCreditos" runat="server" Width="300px"></asp:Label>

                    </td>
                     <td class="auto-style19">
                         
                    </td>
                     <td>
                         
                    </td>
                </tr>
               
            </table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Nota: contraseña para iniciar sesión: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtcontraseña" runat="server" required Width="275px" TextMode="Password"></asp:TextBox>
            <br />
        </article>
        <br />
        <br />

        <article id="botones" class="auto-style11">

            <asp:Button ID="BtnContinuar" runat="server" Text="Continuar" Height="38px" Width="165px" OnClick="BtnContinuar_Click" />

        </article>
        <br />
        <br />
        <article>
            <asp:GridView ID="GridView1" runat="server" Visible="False"></asp:GridView>
            <asp:GridView ID="GridView2" runat="server" Visible="False">
            </asp:GridView>
        </article>
    </section>
    <br />

</asp:Content>
