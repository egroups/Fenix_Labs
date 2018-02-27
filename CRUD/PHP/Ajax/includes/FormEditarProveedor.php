<script>
$(document).ready(function(){
		  
  $("form[name='form_proveedores']").submit(function(e) {
	  	
	var id_proveedor_check = $("input[name='id_proveedor']").val();
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
      $.post("includes/ABM.php",{editar_proveedor:"",id_proveedor:id_proveedor_check,nombre_empresa:nombre_check,direccion:direccion_check,telefono:telefono_check}, function(mensaje) {
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
	 
	$resultado = "";
	
	$id_proveedor = $_POST["editar_proveedor"];
	
	if(!is_numeric($id_proveedor)) {
		mensaje("Proveedores","ID invalido","warning","?proveedores");
	} else {
	
		$proveedores = $conexion_now->listarProveedores();
		$posicion = buscar_posicion_proveedor($id_proveedor);
		$proveedor = $proveedores[$posicion];
		
		$id_proveedor = $proveedor->getId_proveedor();
		$nombre_proveedor = $proveedor->getNombre_empresa();
		$direccion = $proveedor->getDireccion();
		$telefono = $proveedor->getTelefono();
		
		$resultado = $resultado . '
	<div class="panel contenedor panel-default">
	<div class="panel-heading">Editando al proveedor '.htmlentities($nombre_proveedor).'</div>
	<div class="panel-body">
	<form action="?proveedores" method="POST" name="form_proveedores" class="form-horizontal">
	<input type="hidden" name="id_proveedor" value="' . htmlentities($id_proveedor) . '"> 
	  <fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text" name="nombre_empresa" value="'.htmlentities($nombre_proveedor).'">
		  </div>
		</div>
		<div class="form-group" name="form-group-direccion">
		  <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text" name="direccion" value="'.htmlentities($direccion).'">
		  </div>
		</div>
		<div class="form-group" name="form-group-telefono">
		  <label for="inputTelefono" class="col-lg-2 control-label">Telefono</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputTelefono" placeholder="Ingrese telefono" type="text" name="telefono" value="'.htmlentities($telefono).'">
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="editar_proveedor">Editar</button>
		</div>
	  </fieldset>
	</form>        
	</div>
	</div>
		';
			
	}
	
	echo $resultado;

}
	    
?>