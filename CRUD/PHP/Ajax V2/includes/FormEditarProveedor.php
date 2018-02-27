<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<?php

include_once("Productos.php");
include_once("Proveedores.php");
include_once("Conexion.php");
include_once("Funciones.php");

$conexion_now = new Conexion();
	
$cortar = base64_decode($_SESSION['uid']);
	
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
		<div class="text-center">
			<div class="form-group">
				<button type="submit" class="btn btn-default" name="editar_proveedor" id="editar_proveedor">Editar</button>
				<button type="submit" class="btn btn-primary" name="cancelar_proveedor" id="cancelar_proveedor">Cancelar</button>
			</div>
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