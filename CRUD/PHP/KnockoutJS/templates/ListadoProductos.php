<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<?php

include_once("includes/Productos.php");
include_once("includes/ClaseConexion.php");

$resultado = "";
	
$cantidad_real = "0";

$conexion_now = new Conexion();

$productos = $conexion_now->listarProductos();

$cantidad_real = count($productos);

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
<table class="table table-striped table-hover ">
  <thead>
	<tr>
	  <th class="fila_listado_productos">Nombre</th>
	  <th class="fila_listado_productos">Descripcion</th>
	  <th class="fila_listado_productos">Precio</th>
	  <th class="fila_listado_productos">Proveedor</th>
	  <th class="fila_listado_productos">Registro</th>
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

		$resultado = $resultado . '
		  <tr>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($nombre_producto).'</td>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($descripcion).'</td>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($precio).'</td>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($nombre_proveedor).'</td>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($fecha_registro).'</td>
		  </tr>
		';
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

unset($conexion_now);

echo $resultado;

?>