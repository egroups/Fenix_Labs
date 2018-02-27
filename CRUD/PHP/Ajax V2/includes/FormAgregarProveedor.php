<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<?php

include_once("Conexion.php");
  
$conexion_now = new Conexion();
	
$cortar = base64_decode($_SESSION['uid']);
	
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
			<button type="submit" class="btn btn-primary center-block" name="agregar_proveedor" id="agregar_proveedor">Agregar</button>
		</div>
	  </fieldset>
	</form>        
	</div>
	</div>
	';
	
	echo $resultado;

}
		    
?>