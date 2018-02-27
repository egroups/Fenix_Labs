<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/Funciones.php");

if(!verificarCookie()) {
  exit;
}

$split = base64_decode($_SESSION['uid']);

$result      = explode("@", $split);
$user_login = $result[0];

?>
<div class="panel contenedor panel-default">
<div class="panel-heading">Cambiar Usuario</div>
<div class="panel-body">
  <form action="?cambiar_usuario" method="POST" name="form_cambiar_usuario" id="cambiarUsuarioForm" class="form-horizontal">
	<fieldset>
	  <legend>Datos</legend>
	  <div class="form-group" name="form-group-username">
		<label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
		<div class="col-lg-10">
		  <input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="usuario"  value="<?php echo htmlentities($user_login) ?>" readonly="readonly">
		</div>
	  </div>
	  <div class="form-group" name="form-group-new-username">
		<label for="inputNuevo" class="col-lg-2 control-label">Nuevo usuario</label>
		<div class="col-lg-10">
		  <input class="form-control" id="inputNuevoUsuario" placeholder="Ingrese nuevo usuario" type="text" name="nuevo_usuario">
		</div>
	  </div>
	  <div class="form-group" name="form-group-password">
		<label for="inputActual" class="col-lg-2 control-label">Actual clave</label>
		<div class="col-lg-10">
		  <input class="form-control" id="inputPassword" placeholder="Ingrese clave" type="password" name="clave">
		</div>
	  </div>
	  <div class="form-group">
		  <button type="submit" class="btn btn-primary center-block" name="cambiar_usuario" id="cambiar_usuario"><span class="glyphicon glyphicon-pencil right_space"></span>Cambiar</button>
	  </div>
	</fieldset>
  </form>        
</div>
</div>