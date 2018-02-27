<script>
$(document).ready(function(){
      
  $("form[name='form_cambiar_usuario']").submit(function(e) {

    var username_check = $("input[name='username']").val();
	var new_username_check = $("input[name='new_username']").val();
	var password_check = $("input[name='password']").val();

    if(username_check=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
	  $("input[name='username']").focus();
      e.preventDefault();
      return false;   
    } 

    else if(new_username_check=="") {
      $("input[name='new_username']").attr("placeholder", "Falta nuevo usuario");
      $("div[name='form-group-new-username']").addClass('has-error');
	  $("input[name='new_username']").focus();
      e.preventDefault();
      return false;   
    } 

    else if(password_check=="") {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").addClass('has-error');
	  $("input[name='password']").focus();
      e.preventDefault();
      return false;   
    } else {
	  	$("div[name='form-group-username']").addClass('has-success');
		$("div[name='form-group-new-username']").addClass('has-success');		
		$("div[name='form-group-password']").addClass('has-success');	
      	$.post("includes/ABM.php",{cambiar_user:"",username:username_check,new_username:new_username_check,password:password_check}, function(mensaje) {
		  	$("#respuesta").html(mensaje);
      	});
      	e.preventDefault();
      	return false; 		
	}
	  	
  });
  

});
</script>
  
<?php

include_once("Conexion.php");

$resultado = "";
    
$conexion_now = new Conexion();

$cortar = base64_decode($_COOKIE['cookie_login']);

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
			  <button type="submit" class="btn btn-primary center-block" name="cambiar_user" onclick="return validar_formulario_cambiar_usuario();">Cambiar</button>
		  </div>
		</fieldset>
	  </form>        
	</div>
	</div>
	';
	
	echo $resultado;

}

?>