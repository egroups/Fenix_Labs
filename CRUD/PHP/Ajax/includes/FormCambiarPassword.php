<script>
$(document).ready(function(){
        
  $("form[name='form_cambiar_password']").submit(function(e) {

    var username_check = $("input[name='username']").val();
	var anterior_password_check = $("input[name='anterior_password']").val();
	var new_password_check = $("input[name='new_password']").val();
	
    if(username_check=="") {
      $("input[name='username']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-username']").addClass('has-error');
	  $("input[name='username']").focus();
      e.preventDefault();
      return false;   
    } 
	
    else if(anterior_password_check=="") {
      $("input[name='anterior_password']").attr("placeholder", "Falta contraseña actual");
      $("div[name='form-group-anterior-password']").addClass('has-error');
	  $("input[name='anterior_password']").focus();
      e.preventDefault();
      return false;   
    }
	
    else if(new_password_check=="") {
      $("input[name='new_password']").attr("placeholder", "Falta nueva contraseña");
      $("div[name='form-group-new-password']").addClass('has-error');
	  $("input[name='new-password']").focus();
      e.preventDefault();
      return false;   
    } else {
	 	 $("div[name='form-group-username']").addClass('has-success');	
		 $("div[name='form-group-anterior-password']").addClass('has-success');
		 $("div[name='form-group-new-password']").addClass('has-success');
      	 $.post("includes/ABM.php",{cambiar_pass:"",username:username_check,anterior_password:anterior_password_check,new_password:new_password_check}, function(mensaje) {
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
		  <div class="panel-heading">Cambiar Contraseña</div>
		  <div class="panel-body">
			<form action="?cambiar_password" method="POST" name="form_cambiar_password" class="form-horizontal">
			  <fieldset>
				<legend>Datos</legend>
				<div class="form-group" name="form-group-username">
				  <label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
				  <div class="col-lg-10">
					<input class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" name="username"  value="'.htmlentities($user_login).'" readonly="readonly">
				  </div>
				</div>
				<div class="form-group" name="form-group-anterior-password">
				  <label for="inputActual" class="col-lg-2 control-label">Actual contraseña</label>
				  <div class="col-lg-10">
					<input class="form-control" id="inputAnterior" placeholder="Ingrese password" type="password" name="anterior_password">
				  </div>
				</div>
				<div class="form-group" name="form-group-new-password">
				  <label for="inputActual" class="col-lg-2 control-label">Nueva contraseña</label>
				  <div class="col-lg-10">
					<input class="form-control" id="inputNuevo" placeholder="Ingrese nuevo password" type="password" name="new_password">
				  </div>
				</div>
				<div class="form-group">
					<button type="submit" class="btn btn-primary center-block" name="cambiar_pass" onclick="return validar_formulario_cambiar_password();">Cambiar</button>
				</div>
			  </fieldset>
			</form>        
		  </div>
		</div>
	';
	
	echo $resultado;

}

?>