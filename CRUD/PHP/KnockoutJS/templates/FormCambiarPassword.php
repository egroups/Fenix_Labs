<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<div data-bind="visible: mostrarFormCambiarPassword">
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Cambiar Contraseña</div>
	  <div class="panel-body">
		<form action="?cambiar_password" method="POST" name="form_cambiar_password" class="form-horizontal">
		  <fieldset>
			<legend>Datos</legend>
			<div class="form-group" name="form-group-username">
			  <label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="username" data-bind="value: $root.nombre_usuario" readonly="readonly">
			  </div>
			</div>
			<div class="form-group" name="form-group-anterior-password">
			  <label for="inputActual" class="col-lg-2 control-label">Actual contraseña</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputAnterior" placeholder="Ingrese password" type="password" name="anterior_password" data-bind="value: $root.actual_contraseña">
			  </div>
			</div>
			<div class="form-group" name="form-group-new-password">
			  <label for="inputActual" class="col-lg-2 control-label">Nueva contraseña</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputNuevo" placeholder="Ingrese nuevo password" type="password" name="new_password" data-bind="value: $root.nueva_contraseña">
			  </div>
			</div>
			<div class="form-group">
				<button type="submit" class="btn btn-primary center-block" name="cambiar_pass" id="cambiar_pass" data-bind="click: CambiarPassword">Cambiar</button>
			</div>
		  </fieldset>
		</form>        
	  </div>
	</div>
</div>