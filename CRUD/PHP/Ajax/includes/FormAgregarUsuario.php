<script>
$(document).ready(function(){
		  
  $("form[name='form_usuarios']").submit(function(e) {

    var nombre_check = $("input[name='nombre_usuario']").val();
	var password_check = $("input[name='password']").val();
	var tipo_check = $("select[name='tipo']").val();

    if(nombre_check=="") {
      $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_usuario']").focus();
      e.preventDefault();
      return false;   
    } 
    else if(password_check=="") {
      $("input[name='password']").attr("placeholder", "Falta password");
      $("div[name='form-group-password']").addClass('has-error');
	  $("input[name='password']").focus();
      e.preventDefault();
      return false;   
    } 
    else if(tipo_check=="0") {
      $("select[name='tipo']").attr("placeholder", "Seleccione tipo");
      $("div[name='form-group-tipo']").addClass('has-error');
	  $("select[name='tipo']").focus();
      e.preventDefault();
      return false;   
    } else {
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-password']").addClass('has-success');
	  $("div[name='form-group-tipo']").addClass('has-success');
      $.post("includes/ABM.php",{agregar_usuario:"",nombre_usuario:nombre_check,password:password_check,tipo:tipo_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
      });
      e.preventDefault();
      return false; 
	}
  });
  
});
</script>

<?php
     
include_once("Productos.php");
include_once("Proveedores.php");
include_once("Conexion.php");
include_once("Funciones.php");	
  
$conexion_now = new Conexion();
	
$cortar = base64_decode($_COOKIE['cookie_login']);
	
$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];
	
if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {
	
	if ($conexion_now->es_admin($user_login)) {
	 
		$resultado = "";
			
		$resultado = $resultado . '
		<div class="panel contenedor panel-default">
		  <div class="panel-heading">Agregar usuario</div>
		  <div class="panel-body">
			<form action="?usuarios" method="POST" name="form_usuarios" class="form-horizontal">
			  <fieldset>
				<legend>Datos</legend>
				<div class="form-group" name="form-group-nombre">
				  <label for="inputNombre" class="col-lg-2 control-label">Nombre usuario</label>
				  <div class="col-lg-10">
					<input class="form-control" id="inputNombre" placeholder="Ingrese nombre usuario" type="text" name="nombre_usuario">
				  </div>
				</div>
				<div class="form-group" name="form-group-password">
				  <label for="inputPrecio" class="col-lg-2 control-label">Password</label>
				  <div class="col-lg-10">
					<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password">
				  </div>
				</div>
				<div class="form-group" name="form-group-tipo">
				  <label for="select" class="col-lg-2 control-label">Tipo</label>
				  <div class="col-lg-10">
					<select class="form-control" id="select" name="tipo">
						<option value="2">Usuario</option>
						<option value="1">Administrador</option>
					</select>
				  </div>
				</div>
				<div class="form-group">
					<button type="submit" class="btn btn-primary center-block" name="agregar_usuario" onclick="return validar_formulario_usuarios();">Agregar</button>
				</div>
			  </fieldset>
			</form>        
		  </div>
		</div>
				';
			
		echo $resultado;
	
	} else {
		mensaje_con_redireccion("Notificacion","Acceso Denegado","error","administracion.php");
	}

}
		            
?>