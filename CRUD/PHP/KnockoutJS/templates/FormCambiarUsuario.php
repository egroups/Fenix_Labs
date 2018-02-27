<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<div data-bind="visible: mostrarFormCambiarUsuario">
	<div class="panel contenedor panel-default">
	<div class="panel-heading">Cambiar Usuario</div>
	<div class="panel-body">
	  <form action="?cambiar_usuario" method="POST" name="form_cambiar_usuario" class="form-horizontal">
		<fieldset>
		  <legend>Datos</legend>
		  <div class="form-group" name="form-group-username">
			<label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
			<div class="col-lg-10">
			  <input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="username" data-bind="value: $root.nombre_usuario" readonly="readonly">
			</div>
		  </div>
		  <div class="form-group" name="form-group-new-username">
			<label for="inputNuevo" class="col-lg-2 control-label">Nuevo usuario</label>
			<div class="col-lg-10">
			  <input class="form-control" id="inputNuevoUsuario" placeholder="Ingrese nuevo usuario" type="text" name="new_username" data-bind="value: $root.nuevo_usuario">
			</div>
		  </div>
		  <div class="form-group" name="form-group-password">
			<label for="inputActual" class="col-lg-2 control-label">Actual contraseña</label>
			<div class="col-lg-10">
			  <input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password" data-bind="value: $root.actual_contraseña">
			</div>
		  </div>
		  <div class="form-group">
			  <button type="submit" class="btn btn-primary center-block" name="cambiar_user" id="cambiar_user" data-bind="click: CambiarUsuario">Cambiar</button>
		  </div>
		</fieldset>
	  </form>        
	</div>
	</div>
</div>