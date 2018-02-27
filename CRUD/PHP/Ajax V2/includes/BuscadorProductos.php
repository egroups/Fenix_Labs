<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<script>
	function funcion_buscar_productos() {
		var texto = $("input[name='nombre_buscar']").val();
		$.post("includes/BusquedaProductos.php",{nombre_buscar:texto}, function(mensaje) {
			$("#tabla").html(mensaje);
		}); 			  
	}
</script>

<?php

include_once("Productos.php");
include_once("Conexion.php");
include_once("Funciones.php");
include_once("Conexion.php");
  
$conexion_now = new Conexion();
	
$cortar = base64_decode($_SESSION['uid']);
	
$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];
	
if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {

	$resultado = "";
		
	$cantidad_real = "0";
	
	$productos = $conexion_now->listarProductos();
	
	if (isset($_POST["nombre_buscar"])) {
		$cantidad_real = contar_productos($_POST["nombre_buscar"]);
	} else {
		$cantidad_real = count($productos);
	}
	
	$resultado = $resultado . '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Productos encontrados : '.htmlentities($cantidad_real).'</div>
	  <div class="panel-body">
		<form method="POST" class="form-horizontal" name="form_busqueda">
		  <fieldset>
			<div class="form-group">
			  <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputBuscar" placeholder="Nombre" name="nombre_buscar" type="text" onKeyUp="funcion_buscar_productos();">
			  </div>
			</div>
			<div class="form-group">
				<button type="submit" name="busqueda" id="buscar_productos" class="btn btn-primary center-block">Buscar</button>
			</div>
		  </fieldset>
		</form>
	  </div>
	</div>';
		
	unset($conexion_now);
	
	echo $resultado;

}

?>