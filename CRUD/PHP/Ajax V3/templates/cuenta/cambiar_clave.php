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
  <div class="panel-heading">Cambiar Clave</div>
  <div class="panel-body">
	<form action="?cambiar_password" method="POST" name="form_cambiar_password" id="cambiarClaveForm" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-username">
		  <label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="usuario"  value="<?php echo htmlentities($user_login) ?>" readonly="readonly">
		  </div>
		</div>
		<div class="form-group" name="form-group-anterior-password">
		  <label for="inputActual" class="col-lg-2 control-label">Actual clave</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputAnterior" placeholder="Ingrese clave" type="password" name="clave">
		  </div>
		</div>
		<div class="form-group" name="form-group-new-password">
		  <label for="inputActual" class="col-lg-2 control-label">Nueva clave</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNuevo" placeholder="Ingrese nueva clave" type="password" name="nueva_clave">
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="cambiar_clave" id="cambiar_clave"><span class="glyphicon glyphicon-pencil right_space"></span>Cambiar</button>
		</div>
	  </fieldset>
	</form>        
  </div>
</div>
