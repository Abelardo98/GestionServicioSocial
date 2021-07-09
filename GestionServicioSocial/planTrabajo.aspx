<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="planTrabajo.aspx.cs" Inherits="GestionServicioSocial.planTrabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
          
            text-align:center;
        }
        .auto-style2 {            height: 38px;
        }
        .auto-style3 {
           
            text-align:center;
        }
        .auto-style4 {
            height: 38px;
            width: 742px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <article style="text-align:right">
            <asp:Button ID="BtnRegresar" runat="server" Text="Regresar" OnClick="BtnRegresar_Click1" />
        </article>
        
        <header class="auto-style3"><h2>Cargar plan de trabajo
            </h2>
            
            <asp:Label ID="Label2" runat="server" Text="Numero de Control: "></asp:Label>
            <asp:Label ID="txtNc" runat="server" Text=""></asp:Label>
        </header>
        <br />
        <br />
        <article style="text-align:center">
            <asp:Label ID="Label1" runat="server" Text="Ingresa el correo de tu asesor externo (Obligatorio):   " Width="319px"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="Correo" runat="server" Width="460px"></asp:TextBox>
        </article>

        <br />
        <article style="text-align:center">
             <asp:Label ID="Label4" runat="server" Text="Plan de trabajo" Width="200px"></asp:Label>
             <asp:FileUpload ID="FileUpload1" runat="server" Width="379px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Subir plan de trabajo" OnClick="Button1_Click" Width="200px" />
        </article>

        <br />

       
        <br />
        <br />
        
    </section>
</asp:Content>
