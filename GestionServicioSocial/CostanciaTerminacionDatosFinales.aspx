<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="CostanciaTerminacionDatosFinales.aspx.cs" Inherits="GestionServicioSocial.CostanciaTerminacionDatosFinales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style16 {
            width: 1311px;
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <section style="text-align: center">
        <h2>Datos finales, constancia de terminación de servicio social </h2>
    </section>
    <br />

    <section style="text-align: center">
        <asp:Label ID="txtNumeroControl" runat="server"></asp:Label>
        <table class="auto-style16">
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Numero de oficio: " Width="400px"></asp:Label>
                    <asp:TextBox ID="txtNumeroOficio" runat="server" Width="400px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>

            </tr>


            <tr>
                <td class="auto-style21">
                    <asp:Label ID="Label12" runat="server" Text="Fecha expedición documento: " Width="400px"></asp:Label>
                    <asp:DropDownList ID="txtDia" runat="server" Width="133.3px">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="txtMes" runat="server" Width="133.3px">
                        <asp:ListItem>enero</asp:ListItem>
                        <asp:ListItem>febrero</asp:ListItem>
                        <asp:ListItem>marzo</asp:ListItem>
                        <asp:ListItem>abril</asp:ListItem>
                        <asp:ListItem>mayo</asp:ListItem>
                        <asp:ListItem>junio</asp:ListItem>
                        <asp:ListItem>julio</asp:ListItem>
                        <asp:ListItem>agosto</asp:ListItem>
                        <asp:ListItem>septiembre</asp:ListItem>
                        <asp:ListItem>octubre</asp:ListItem>
                        <asp:ListItem>noviembre</asp:ListItem>
                        <asp:ListItem>diciembre</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="txtAnio" runat="server" Width="133.3px">
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                        <asp:ListItem>2025</asp:ListItem>
                        <asp:ListItem>2026</asp:ListItem>
                        <asp:ListItem>2027</asp:ListItem>
                        <asp:ListItem>2028</asp:ListItem>
                        <asp:ListItem>2029</asp:ListItem>
                        <asp:ListItem>2030</asp:ListItem>
                    </asp:DropDownList><br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Horas servicio social: " Width="400px"></asp:Label>
                    <asp:TextBox ID="txtHorasServicio" runat="server" Width="400px" value=" "></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Municipio de la dependencia: " Width="400px"></asp:Label>
                    <asp:TextBox ID="txtMunicipioDependencia" runat="server" Width="400px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Estado de la dependencia: " Width="400px"></asp:Label>
                    <asp:TextBox ID="txtEstadoDependencia" runat="server" Width="400px" value=" " onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br /><br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar y Generar constancia de terminación" OnClick="btnGuardar_Click"/>   
        &nbsp;&nbsp;&nbsp;&nbsp;   
        </section>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" Visible="False"></asp:GridView>
</asp:Content>
