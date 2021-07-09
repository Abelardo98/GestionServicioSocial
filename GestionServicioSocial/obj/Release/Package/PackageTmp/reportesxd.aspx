<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="reportesxd.aspx.cs" Inherits="GestionServicioSocial.reportesxd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        header
        {
            text-align:center;
        }
        .auto-style1 {
            height: 33px;
        }
        #tipo
        {

            text-align:center;
        }
        #mensaje
        {

            text-align:center;
        }

        #carga
        {

            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="text-align:right">
        <asp:Button ID="Button2" runat="server" Text="Regresar" OnClick="Button2_Click1" />
    </section>
    <section>
        <header><h2>Cargar Reportes</h2>
            <strong><asp:Label ID="Label2" runat="server" Text="Numero de Control: "></asp:Label></strong>
            <asp:Label ID="txtNc" runat="server" Text=""></asp:Label>
        </header>
        <div id="tipo">
            <h3>
                Evaluación cualitativa del prestador de Servicio Social por parte de la Dependencia
                / Autoevaluación por parte del prestador de Servicio Social</h3>
        </div>
        <div style="text-align: center;">
        <table style="margin: 0 auto;" cellspacing="10" border="1" cellpadding="10">
            <tr>
                <th>Criterios a evaluar</th>
                <th>Calificación Dependencia</th>
                <th>Autoevaluación</th>
            </tr>
            <tr>
                <td class="auto-style9">
                    Cumplí en tiempo y forma con las actividades encomendadas alcanzando los objetivos
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEV1" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="rango1" runat="server"
                        ControlToValidate="txtEV1"
                        MinimumValue="1"
                        ForeColor="Red"
                        MaximumValue="4"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"
                        />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ValidationGroup="rpt" runat="server" ErrorMessage="*" ControlToValidate="txtEV1" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtAU1" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator7" runat="server"
                        ControlToValidate="txtAU1"
                        ForeColor="Red"
                        MinimumValue="1"
                        MaximumValue="4"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="rpt" ErrorMessage="*" ControlToValidate="txtAU1" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    Trabajé en equipo y me adapté a nuevas situaciones
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEV2" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator1" runat="server"
                        ControlToValidate="txtEV2"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4"
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="rpt" ErrorMessage="*" ControlToValidate="txtEV2" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtAU2" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator8" runat="server"
                        ControlToValidate="txtAU2"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4"
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="rpt" ErrorMessage="*" ControlToValidate="txtAU2" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    Mostré liderazgo en las actividades encomendadas
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEV3" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator2" runat="server"
                        ControlToValidate="txtEV3"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="rpt" ErrorMessage="*" ControlToValidate="txtEV3" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtAU3" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator9" runat="server"
                        ControlToValidate="txtAU3"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ValidationGroup="rpt" ControlToValidate="txtAU3" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    Organcé mi tiempo y trabajé de manera proactiva
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEV4" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator3" runat="server"
                        ControlToValidate="txtEV4"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="rpt" ErrorMessage="*" ControlToValidate="txtEV4" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtAU4" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator10" runat="server"
                        ControlToValidate="txtAU4"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ValidationGroup="rpt" ControlToValidate="txtAU4" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    Interpreté la realidad y me sensibilicé aportando soluciones a la problemática que se pretende <br />disminuir o eliminarl con el servicio social
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEV5" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator4" runat="server"
                        ControlToValidate="txtEV5"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ValidationGroup="rpt" ControlToValidate="txtEV5" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtAU5" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator11" runat="server"
                        ControlToValidate="txtAU5"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ValidationGroup="rpt" ControlToValidate="txtAU5" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    Relacé sugerencias innovadoras para beneficio o mejora del programa que participé
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEV6" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator5" runat="server"
                        ControlToValidate="txtEV6"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="rpt" ErrorMessage="*" ControlToValidate="txtEV6" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtAU6" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator12" runat="server"
                        ControlToValidate="txtAU6"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4"
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ValidationGroup="rpt" ControlToValidate="txtAU6" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    Tuve iniciativa para ayudar en las actividades encomendadas y mostré espiritu de servicio
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEV7" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator6" runat="server"
                        ControlToValidate="txtEV7"
                        MinimumValue="1"
                        MaximumValue="4"
                        ForeColor="Red"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ValidationGroup="rpt" ControlToValidate="txtEV7" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtAU7" runat="server"></asp:TextBox>
                    <asp:RangeValidator id="RangeValidator13" runat="server"
                        ControlToValidate="txtAU7"
                        MinimumValue="1"
                        ForeColor="Red"
                        MaximumValue="4"
                        Type="Integer"
                        Text="1 - 4" 
                        ValidationGroup="rpt"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ValidationGroup="rpt" ControlToValidate="txtAU7" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
         </table>
       </div>
        <div id="mensaje">
            <p>* Campos Obligatorios || 1 - 4 es la calificación permitida</p>
        </div>
        <div id="carga">
            <h2>Cargar reportes</h2>
        </div>
        <div style="text-align: center;">
        <table style="margin: 0 auto;" cellspacing="10" border="1" cellpadding="10">
            <tr>
                <td class="auto-style1">
                    Selecciona el reporte que vas a cargar
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="txtReporte" runat="server">
                        <asp:ListItem>Reporte 1</asp:ListItem>
                        <asp:ListItem>Reporte 2</asp:ListItem>
                        <asp:ListItem>Reporte 3</asp:ListItem>
                        <asp:ListItem>Reporte 4</asp:ListItem>
                        <asp:ListItem>Reporte 5</asp:ListItem>
                        <asp:ListItem>Evaluación Final</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button1" runat="server" ValidationGroup="rpt" Text="Subir reportes" OnClick="Button1_Click1"  />
                </td>
            </tr>
        </table>
      </div>
    </section>
</asp:Content>