<!-- Written By Ismael Heredia in the year 2016 -->

<?php

include_once("includes/Proveedores.php");
include_once("includes/Productos.php");
include_once("includes/Usuarios.php");
include_once("includes/Conexion.php");

$conexion_now = new Conexion();

if (isset($_COOKIE['login'])) {
    
    $cortar = base64_decode($_COOKIE['login']);
    
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
		echo "<script>alert('Faltan datos');</script>";
	} else {
		$password_encoded = md5($password);
		if($conexion_now->ingreso_usuario($username,$password_encoded)) {
			setcookie("login", base64_encode($username . "@" . $password_encoded));
			if($conexion_now->es_admin($username)) {
				echo "<script>alert('Bienvenido administrador ".htmlentities($username)."');</script>";
			} else {
				echo "<script>alert('Bienvenido usuario ".htmlentities($username)."');</script>";
			}
   			$archivo = "administracion.php";
   		    echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($archivo) . '" />';
		} else {
			echo "<script>alert('Datos incorrectos');</script>";
		}
	}
}

unset($conexion_now);

?>

<!DOCTYPE html>
<!--[if lt IE 7]> <html class="lt-ie9 lt-ie8 lt-ie7" lang="en"> <![endif]-->
<!--[if IE 7]> <html class="lt-ie9 lt-ie8" lang="en"> <![endif]-->
<!--[if IE 8]> <html class="lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]><!-->
<html lang="en"><!--<![endif]--><head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <title>Login</title>
  <link rel="stylesheet" href="css/style.css">
  <!--[if lt IE 9]><script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
</head>
<body>
  <form method="post" action="" class="login">
    <p>
      <label for="username">Usuario :</label>
      <input name="username" id="username" type="text">
    </p>

    <p>
      <label for="password">Password :</label>
      <input name="password" id="password" type="password">
    </p>

    <p class="login-submit">
      <button type="submit" name="login" class="login-button">Login</button>
    </p>

</form>

  
</body></html>