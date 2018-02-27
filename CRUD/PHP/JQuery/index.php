<!-- Written By Ismael Heredia in the year 2016 -->

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login</title>
    <!-- Bootstrap -->
	<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
	<link href="css/style.css" rel="stylesheet" type="text/css">
	<script src="scripts/jquery-1.5.1.js"></script>
    
    <script src="dist/sweetalert-dev.js"></script>
    <link rel="stylesheet" href="dist/sweetalert.css">
    
<script>
	
$(document).ready(function(){
	
  $("form[name='form_login']").submit(function(e) {

    var username = $("input[name='username']").val();
	var password = $("input[name='password']").val();

    if(username=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
	  $("input[name='username']").focus();
      e.preventDefault();
      return false;   
    } else {
	  $("div[name='form-group-username']").addClass('has-success');
	}
		
    if(password=="") {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").addClass('has-error');
	  $("input[name='password']").focus();
      e.preventDefault();
      return false;   
    } else {
		$("div[name='form-group-password']").addClass('has-success');
	}
	
  });	
	
});
	
</script>

	<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
	<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
	<!--[if lt IE 9]>
		  <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
		  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
		<![endif]-->
  </head>
  <body>
	<div class="container-fluid">
	  <div class="panel login panel-default">
  		<div class="panel-heading">Login</div>
  			<div class="panel-body">
                <form action="" method="POST" class="form-horizontal" name="form_login">
                  <fieldset>
                    <legend>Datos</legend>
                    <div class="form-group" name="form-group-username">
                      <label for="inputTexto1" class="col-lg-2 control-label">Username</label>
                      <div class="col-lg-10">
                        <input class="form-control" id="inputUsername" name="username" placeholder="Ingrese usuario" type="text">
                      </div>
                    </div>
                    <div class="form-group" name="form-group-password">
                      <label for="inputTexto2" class="col-lg-2 control-label">Password</label>
                      <div class="col-lg-10">
                        <input class="form-control" id="inputPassword" name="password" placeholder="Ingrese password" type="password">
                      </div>
                    </div>
                    <div class="form-group">
                      <div class="col-lg-10 col-lg-offset-2">
                        <button type="submit" name="login" class="btn btn-primary" onclick="return validar_formulario_login();">Ingresar</button>
                      </div>
                    </div>
                  </fieldset>
                </form>
        	</div>
	   </div>
    </div>
    
<?php

include_once("includes/Proveedores.php");
include_once("includes/Productos.php");
include_once("includes/Usuarios.php");
include_once("includes/Conexion.php");
include_once("includes/Funciones.php");

$conexion_now = new Conexion();

if (isset($_COOKIE['cookie_login'])) {
    
    $cortar = base64_decode($_COOKIE['cookie_login']);
    
    $parte      = explode("@", $cortar);
    $user_login = $parte[0];
    $pass_login = $parte[1];
    
	if($conexion_now->ingreso_usuario($user_login,$pass_login)) {
    	$archivo = "administracion.php";
    	echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($archivo) . '" />';
	}
}

if(isset($_POST["login"])) {
	
	$username = $_POST["username"];
	$password = $_POST["password"];
	if($username=="" or $password=="") {
		mensaje("Notificacion","Faltan datos","warning","");
	} else {
		$password_encoded = md5($password);
		if($conexion_now->ingreso_usuario($username,$password_encoded)) {
			setcookie("cookie_login", base64_encode($username . "@" . $password_encoded));
			$archivo = "administracion.php";
			if($conexion_now->es_admin($username)) {
				mensaje("Notificacion","Bienvenido administrador ".htmlentities($username),"success",$archivo);
			} else {
				mensaje("Notificacion","Bienvenido usuario ".htmlentities($username),"success",$archivo);
			}
		} else {
			mensaje("Notificacion","Datos incorrectos","error","");
		}
	}
}

unset($conexion_now);

?>
        
	<!-- jQuery (necessary for Bootstrap's JavaScript plugins) --> 
	<script src="bootstrap/js/jquery-1.11.2.min.js"></script>

	<!-- Include all compiled plugins (below), or include individual files as needed --> 
	<script src="bootstrap/js/bootstrap.js"></script>
  </body>
</html>