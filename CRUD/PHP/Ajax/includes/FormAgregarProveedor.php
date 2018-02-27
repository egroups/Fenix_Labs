<script>
$(document).ready(function(){
		  
  $("form[name='form_proveedores']").submit(function(e) {

    var nombre_check = $("input[name='nombre_empresa']").val();
	var direccion_check = $("input[name='direccion']").val();
	var telefono_check = $("input[name='telefono']").val();

    if(nombre_check=="") {
      $("input[name='nombre_empresa']").attr("placeholder", "Falta nombre de empresa");
      $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_empresa']").focus();
      e.preventDefault();
      return false;   
    } 
    else if(direccion_check=="") {
      $("input[name='direccion']").attr("placeholder", "Falta direccion");
      $("div[name='form-group-direccion']").addClass('has-error');
	  $("input[name='direccion']").focus();
      e.preventDefault();
      return false;   
    } 
    else if(telefono_check=="") {
      $("input[name='telefono']").attr("placeholder", "Falta telefono");
      $("div[name='form-group-telefono']").addClass('has-error');
	  $("input[name='telefono']").focus();
      e.preventDefault();
      return false;   
    } else {
      $("div[name='form-group-nombre']").addClass('has-success');
      $("div[name='form-group-direccion']").addClass('has-success');
      $("div[name='form-group-telefono']").addClass('has-success');
      $.post("includes/ABM.php",{agregar_proveedor:"",nombre_empresa:nombre_check,direccion:direccion_check,telefono:telefono_check}, function(mensaje) {
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
  
$conexion_now = new Conexion();
	
$cortar = base64_decode($_COOKIE['cookie_login']);
	
$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];
	
if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {
	 
	$resultado = "";
		
	$resultado = $resultado . '
	<div class="panel contenedor panel-default">
	<div class="panel-heading">Agregar Proveedor</div>
	<div class="panel-body">
	<form action="?proveedores" method="POST" name="form_proveedores" class="form-horizontal">
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text" name="nombre_empresa">
		  </div>
		</div>
		<div class="form-group" name="form-group-direccion">
		  <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text" name="direccion">
		  </div>
		</div>
		<div class="form-group" name="form-group-telefono">
		  <label for="inputTelefono" class="col-lg-2 control-label">Telefono</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputTelefono" placeholder="Ingrese telefono" type="text" name="telefono">
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="agregar_proveedor">Agregar</button>
		</div>
	  </fieldset>
	</form>        
	</div>
	</div>
	';
	
	echo $resultado;

}
		    
?>