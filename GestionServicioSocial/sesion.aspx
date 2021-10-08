<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sesion.aspx.cs" Inherits="GestionServicioSocial.sesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        form {
            border: 3px solid #f1f1f1;
        }
        
        input[type=text], input[type=password] {
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        #Button1 {
            text-align: center;
        }


        button:hover {
            opacity: 0.8;
        }

        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
            width: 1369px;
        }

        img.avatar {
            width: 27%;
            border-radius: 50%;
            height: 368px;
        }

        .container {
            padding: 16px;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            .cancelbtn {
                width: 100%;
            }

            #form {
                width: 100px;
            }
        }

        #login {
           text-align: center;
        }
        .auto-style1 {
            text-align: center;
            margin: 24px 0 12px 0;
            width: 1395px;
            height: 259px;
        }
        .auto-style2 {
            width: 1149px;
            height: 205px;
        }
        </style>
</head>
<body>
    <!--Cambios definitovos en el repositorio-->  

     <!--Cambios definitovos jajajaja-->  
     <!--Cambios desde el Original-->  

    <section class="auto-style1">
       &nbsp;&nbsp;
       <img src="imagenes/membrete2022.png" class="auto-style2" >
    </section>
    <h2 id="login">INICIO DE SESIÓN </h2>
    <form id="form1" runat="server">
            <div class="imgcontainer" style="text-align:center;">                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                
                <img src="imagenes/img_avatar2.png" alt="Avatar" class="avatar" style="width: 15%; height: 202px">
            </div>
        <br />
        <br />
            <article style="text-align:center">
                <div id="txtDefecto">
                    <h3>
                   <asp:Label ID="Label1" runat="server" Text="Registrate" Font-Bold="True" Font-Italic="False" ForeColor="#28A745" Font-Size="Larger"></asp:Label><br />

                    </h3>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Ingresa tú número de control : "></asp:Label>
                <asp:TextBox ID="numeroControlReg" runat="server" onkeyup="javascript:this.value=this.value.toUpperCase();" placeholder="Número de control"></asp:TextBox>
                <br />
                <asp:Label ID="alertaControl" runat="server" Text=""></asp:Label>
            </div><br/>
                <div>
                 <p>Selecciona el proceso que vas a cursar</p>  
                </div>

            <div id="btns">
                <asp:Button ID="BtnVisitas" runat="server" class="btn btn-success" Text="Visitas Industriales" OnClick="BtnVisitas_Click"/>
                &nbsp;&nbsp;
                <asp:Button ID="btnServicio" runat="server" class="btn btn-success" Text="Servicio Social" onClick="btnServicio_Click"/>
                &nbsp;&nbsp;
                <asp:Button ID="BtnProvicional" runat="server" class="btn btn-success" Text="Carta Provisional (Residencia Profesional) " Width="375px" OnClick="BtnProvicional_Click"/>
                 &nbsp;&nbsp;
                <asp:Button ID="btnResidencia" runat="server" class="btn btn-success" Text="Residencia Profesional" onClick="btnResidencia_Click" Width="334px"/>
            </div>

            <br />
            <br />

            </article>
            <br />
            <section style="text-align:center">
                <h3>
                    <asp:Label ID="Label4" runat="server" Text="Ó" Font-Bold="True" Font-Italic="False" ForeColor="#28A745" Font-Size="Larger"></asp:Label>
                </h3>
            </section>
        <br />
            <section style="text-align:center">
                <h3>

                   <asp:Label ID="Label3" runat="server" Text="Inicia sesión :" Font-Bold="True" Font-Italic="False" ForeColor="#28A745" Font-Size="Larger"></asp:Label><br />

                </h3>

            </section>
        <br />
        <br />
            <div class="container">
                <label for="uname"><b>Usuario&nbsp;&nbsp;(número de control) </b></label>&nbsp;&nbsp;&nbsp;

                <asp:TextBox ID="txtusername" runat="server" placeholder="Ingresa tu número de control" Width="748px" onkeyup="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                <br />
                <label for="psw"><b>Contraseña</b></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtpasword" runat="server" placeholder="Ingresa tu contraseña" TextMode="Password" Width="749px"></asp:TextBox>
                <br />
                <br />
                <label ><b>Tipo</b></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="txtTipo" runat="server">
                    <asp:ListItem>ADMINISTRADORA</asp:ListItem>
                    <asp:ListItem>JEFE CARRERA</asp:ListItem>
                    <asp:ListItem>SERVICIO</asp:ListItem>
                    <asp:ListItem>RESIDENCIA</asp:ListItem>
                </asp:DropDownList>

                
                
            </div>


            <div style="text-align:center;">
                <asp:Button ID="BTN_LOGIN" class="btn btn-success" runat="server" Text="Iniciar sesión" Width="400px" OnClick="BTN_LOGIN_Click" style="height: 33px" />
            </div>

            <br />
            <br />
            
            
        

            <div class="container">
                
                <asp:GridView ID="GridView1" runat="server" Visible="False">
                </asp:GridView>
            </div>

        </form>
    

   
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    
</body>
</html>
