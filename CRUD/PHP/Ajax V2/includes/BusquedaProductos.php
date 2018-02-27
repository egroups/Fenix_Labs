<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

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
		
	if (isset($_POST["nombre_buscar"])) {
		
		$resultado = $resultado . '
		<div class="panel contenedor panel-default">
		  <div class="panel-heading">Productos encontrados : '.htmlentities($cantidad_real).'</div>
		  <div class="panel-body">
				';
			
		if ($cantidad_real == "0") {
			$resultado = $resultado . "<center><b>No se encontraron productos</b></center>";
		} else {
					
			$resultado = $resultado . '
		<div class="table-responsive">
		<table class="table table-striped table-hover">
		  <thead>
			<tr>
			  <th class="fila_producto">Nombre</th>
			  <th class="fila_producto">Descripcion</th>
			  <th class="fila_producto">Precio</th>
			  <th class="fila_producto">Proveedor</th>
			  <th class="fila_producto">Registro</th>
			  <th class="fila_producto">Opción</th>
			</tr>
		  </thead>
		  <tbody>
			';
						
			foreach ($productos as $producto) {
				$id_producto      = $producto->getId_producto();
				$nombre_producto  = $producto->getNombre_producto();
				$descripcion      = $producto->getDescripcion();
				$descripcion      = substr($descripcion, 0, 18);
				$precio           = $producto->getPrecio();
				$fecha_registro   = $producto->getFecha_registro();
				$id_proveedor     = $producto->getId_proveedor();
				$nombre_proveedor = $conexion_now->cargarNombreProveedor($id_proveedor);
				if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_producto)) {
					$resultado = $resultado . '
					  <tr>
						<td class="filterable-cell fila_producto">'.htmlentities($nombre_producto).'</td>
						<td class="filterable-cell fila_producto">'.htmlentities($descripcion).'</td>
						<td class="filterable-cell fila_producto">'.htmlentities($precio).'</td>
						<td class="filterable-cell fila_producto">'.htmlentities($nombre_proveedor).'</td>
						<td class="filterable-cell fila_producto">'.htmlentities($fecha_registro).'</td>
						<td class="filterable-cell fila_producto"><a href="?editar_producto=' . htmlentities($id_producto) . '"><img src="images/edit.png" title="Editar"></a> <a href="?borrar_producto=' . htmlentities($id_producto) . '"><img src="images/delete.png" title="Borrar"></a></td>
					  </tr>
					';
				}
			}
			
			$resultado = $resultado . '
				</tbody>
			  </table> 
			  </div>
		  ';
		  
			$resultado = $resultado . '
			  </div>
			</div>
			';
			
		}
	}
	
	unset($conexion_now);
	
	echo $resultado;

}

?>