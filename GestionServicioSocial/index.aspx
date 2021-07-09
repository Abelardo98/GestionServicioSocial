<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GestionServicioSocial.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Servicio Social ITSZ</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="css/animate.css"/>
    <link rel="stylesheet" href="css/font-awesome.min.css"/>
    <link rel="stylesheet" href="css/jquery.bxslider.css"/>
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/set1.css" />
    <link href="css/overwrite.css" rel="stylesheet"/>
    <link href="css/style.css" rel="stylesheet"/>
  




    <style type="text/css">
        .auto-style1 {
            width: 1152px;
            height: 620px;
        }
    </style>
  




</head>

<body>
  <nav class="navbar navbar-default navbar-fixed-top" role="navigation" style="background-color:orange;">
    <div class="container">
      <!-- Brand and toggle get grouped for better mobile display -->
      <div class="navbar-header">
        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target=".navbar-collapse.collapse" style="background-color:orange;">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
        <a class="navbar-brand"><span>Depto. Residencies Profesionales y Servicio Social</span></a>
      </div>
      <div class="navbar-collapse collapse">
        <div class="menu">
          <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="sesion.aspx">Iniciar Sesión</a><br />
              
            
          </ul>
        </div>
      </div>
    </div>
  </nav>


  <div class="container">
    <div class="row">
      <div class="slider">
        <div class="img-responsive">
          <ul class="bxslider">
            <li><img src="imagenes/ITSZ.jpg" alt="" class="auto-style1" /></li>

          </ul>
        </div>
      </div>
    </div>
  </div>
    <br />
    <br />
    <br />

  <div class="container">
    <div class="row">
      <div class="box">
        

        <div class="col-md-4">
          <div class="wow bounceIn" data-wow-offset="0" data-wow-delay="1.0s">
            <h4>Servicio Social</h4>
            
            <div class="ficon">
              <a href="sesion.aspx" class="btn btn-default" role="button">Iniciar proceso  </a>
            </div>
          </div>
        </div>

        <div class="col-md-4">
          <div class="wow bounceIn" data-wow-offset="0" data-wow-delay="1.6s">
            <h4>Residencias Profesionales </h4>
            
            <div class="ficon">
              <a href="sesion.aspx" class="btn btn-default" role="button">Iniciar proceso </a>
            </div>
          </div>

        </div>

        <div class="col-md-4">
          <div class="wow bounceIn" data-wow-offset="0" data-wow-delay="0.4s">
            <h4>Permisos Escolares </h4>
            
            <div class="ficon">
              <a href="sesion.aspx" class="btn btn-default" role="button">Iniciar proceso </a>
            </div>
          </div>
        </div>

      </div>
    </div>
  </div>

  <footer>


    <div class="last-div" style="background-color:orange;">
      <div class="container">
        <div class="row">
          <div class="copyright" style="text-align:center">
              Carretera Acuaco-Zacapoaxtla Km. 8, Col. Totoltepec, 73680 Zacapoaxtla, Puebla<br />
                                              Teléfono y Fax: 01 233 317 5000<br />
                                              <a href="mailto:webmaster@live.itsz.edu.mx">webmaster@live.itsz.edu.mx</a>  
            
          </div>
        </div>
      </div>
        <br />
        <br />
        <br />

      <div class="container">
        <div class="row">
          <ul class="social-network">
            <li><a href="#" data-placement="top" title="Facebook"><i class="fa fa-facebook fa-1x"></i></a></li>
            <li><a href="#" data-placement="top" title="Twitter"><i class="fa fa-twitter fa-1x"></i></a></li>
            <li><a href="#" data-placement="top" title="Linkedin"><i class="fa fa-linkedin fa-1x"></i></a></li>
            <li><a href="#" data-placement="top" title="Pinterest"><i class="fa fa-pinterest fa-1x"></i></a></li>
            <li><a href="#" data-placement="top" title="Google plus"><i class="fa fa-google-plus fa-1x"></i></a></li>
          </ul>
        </div>
      </div>

      <a href="#" class="scrollup"><i class="fa fa-chevron-up"></i></a>


    </div>
  </footer>

  <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
  <script src="js/jquery-2.1.1.min.js"></script>
  <!-- Include all compiled plugins (below), or include individual files as needed -->
  <script src="js/bootstrap.min.js"></script>
  <script src="js/wow.min.js"></script>
  <script src="js/jquery.easing.1.3.js"></script>
  <script src="js/jquery.isotope.min.js"></script>
  <script src="js/jquery.bxslider.min.js"></script>
  <script type="text/javascript" src="js/fliplightbox.min.js"></script>
  <script src="js/functions.js"></script>
  <script type="text/javascript">
    $('.portfolio').flipLightBox()
  </script>

</body>



</html>
