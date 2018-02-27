<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<?php

include_once("Conexion.php");

$resultado = "";
    
$conexion_now = new Conexion();

$cortar = base64_decode($_SESSION['uid']);

$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];

if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {

	$resultado = $resultado . '
	<div class="panel contenedor panel-default">
	<div class="panel-heading">Cambiar Usuario</div>
	<div class="panel-body">
	  <form action="?cambiar_usuario" method="POST" name="form_cambiar_usuario" class="form-horizontal">
		<fieldset>
		  <legend>Datos</legend>
		  <div class="form-group" name="form-group-username">
			<label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
			<div class="col-lg-10">
			  <input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="username"  value="'.htmlentities($user_login).'" readonly="readonly">
			</div>
		  </div>
		  <div class="form-group" name="form-group-new-username">
			<label for="inputNuevo" class="col-lg-2 control-label">Nuevo usuario</label>
			<div class="col-lg-10">
			  <input class="form-control" id="inputNuevoUsuario" placeholder="Ingrese nuevo usuario" type="text" name="new_username">
			</div>
		  </div>
		  <div class="form-group" name="form-group-password">
			<label for="inputActual" class="col-lg-2 control-label">Actual contraseña</label>
			<div class="col-lg-10">
			  <input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password">
			</div>
		  </div>
		  <div class="form-group">
			  <button type="submit" class="btn btn-primary center-block" name="cambiar_user" id="cambiar_user">Cambiar</button>
		  </div>
		</fieldset>
	  </form>        
	</div>
	</div>
	';
	
	echo $resultado;

}

?>