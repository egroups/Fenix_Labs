<?php

// Written by Ismael Heredia in the year 2017

error_reporting(1);

include_once("AccesoDatos.php");

function verificarCookie() {

	session_start();

	$datos = new AccesoDatos();

	if(isset($_SESSION["uid"])) {
		$contenido = $_SESSION["uid"];
		$contenido = base64_decode($contenido);

		$split = explode("@", $contenido);

		$username = $split[0];
		$password = $split[1];

		if($datos->ingreso_usuario($username,$password)) {
			return true;
		} else {
			return false;
		}
	} else {
		return false;
	}

}

function verificarCookieAdmin() {

	session_start();

	$datos = new AccesoDatos();

	if(isset($_SESSION["uid"])) {
		$contenido = $_SESSION["uid"];
		$contenido = base64_decode($contenido);

		$split = explode("@", $contenido);

		$username = $split[0];
		$password = $split[1];

		if($datos->ingreso_usuario($username,$password)) {
			if($datos->es_admin($username)) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	} else {
		return false;
	}

}

function getUsernameInCookie() {

	session_start();
	$contenido = $_SESSION["uid"];
	$contenido = base64_decode($contenido);

	$split = explode("@", $contenido);

	$username = $split[0];
	
	return $username;
}

function mensaje($titulo,$contenido,$tipo) {
	echo "
	<script>
	swal({
			title: '".$titulo."',
			text: '".$contenido."',
			type:'".$tipo."',
			html:true,
			animation: false
     });
	</script>
	";
}

function mensaje_con_redireccion($titulo,$contenido,$tipo,$ruta) {
	echo "
	<script>
	swal({
			title: '".$titulo."',
			text: '".$contenido."',
			type:'".$tipo."',
			html:true,
			animation: false
     },function() {
        window.location.href = '".$ruta."';  
     });
	</script>
	";
}

function redireccion($pagina) {
	echo '<meta http-equiv="refresh" content="0; url=' . htmlentities($pagina) . '" />'; 
}

function fecha_actual() {
	date_default_timezone_set("America/Argentina/Cordoba");
	$fecha = date("d/m/Y", time());
	return $fecha;
}

?>