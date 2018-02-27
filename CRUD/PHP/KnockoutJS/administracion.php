<?php  

include_once("includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: index.php');
}

?>
<!-- Written By Ismael Heredia in the year 2016 -->
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Administracion</title>

<!-- Bootstrap -->
<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
<link href="css/style.css" rel="stylesheet">

<script src="js/jquery2.2.0.js"></script> 
<script src="chart/js/highcharts.js"></script>
<script src="chart/js/modules/exporting.js"></script>

<!-- knockoutJS -->
<script src="js/knockout-3.3.0.js"></script>

<!-- Knockout Mapping plugin-->
<script src="js/knockout.mapping-2.4.1.js"></script>

<script src="dist/sweetalert-dev.js"></script>

<link rel="stylesheet" href="dist/sweetalert.css">

<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
<nav class="navbar navbar-default">
  <div class="container-fluid"> 
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#defaultNavbar1"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
      <a class="navbar-brand" href="#">Administracion</a></div>
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="defaultNavbar1">
      <ul class="nav navbar-nav">
        <li class="active"><a data-bind="click: MostrarInicio">Inicio<span class="sr-only">(current)</span></a></li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Cuenta <span class="caret"></span></a>
          <ul class="dropdown-menu" role="menu">
            <li><a data-bind="click: MostrarCambiarUsuario">Cambiar Usuario</a></li>
            <li><a data-bind="click: MostrarCambiarPassword">Cambiar Password</a></li>
          </ul>
        </li>
        <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Gestionar <span class="caret"></span></a>
          <ul class="dropdown-menu" role="menu">
            <li><a data-bind="click: MostrarProductos">Productos</a></li>
            <li><a data-bind="click: MostrarProveedores">Proveedores</a></li>
            <li><a data-bind="click: MostrarUsuarios">Usuarios</a></li>
          </ul>
        </li>
        <li><a data-bind="click: MostrarEstadisticas">Estadisticas</a></li>
      </ul>
	  <ul class="nav navbar-nav navbar-right">
        <li><a data-bind="click: CerrarSesion">Salir</a></li>
      </ul>
    </div>
    <!-- /.navbar-collapse --> 
  </div>
  <!-- /.container-fluid --> 
</nav>
<div class="container-fluid">
  <div class="row">
    <div class="col-md-6 col-md-offset-3">
      <h1 class="text-center">Administracion</h1>
    </div>
  </div>
  <hr>

<div data-bind="visible: mostrarBienvenida">
  <div data-bind="html: textoBienvenida"></div>
</div>
  
<?php

include_once("templates/FormProductos.php");
include_once("templates/FormProveedores.php");
include_once("templates/FormUsuarios.php");
include_once("templates/FormCambiarUsuario.php");
include_once("templates/FormCambiarPassword.php");

if(verificar_cookie_admin()) {
  include_once("templates/Estadisticas.php");
}

?>

  <br>
  <hr>
</div>

<!-- Include all compiled plugins (below), or include individual files as needed --> 

<script src="bootstrap/js/bootstrap.js"></script>
<script type="text/javascript" src="js/app.js"></script>

<div class="row">
  <div class="text-center col-md-6 col-md-offset-3">
    <h4>Footer </h4>
    <p>Copyright &copy; 2015 &middot; All Rights Reserved &middot; <a href="http://yourwebsite.com/" >My Website</a></p>
  </div>
</div>
</body>
</html>
