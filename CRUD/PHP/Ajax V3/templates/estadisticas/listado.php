<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/Funciones.php");
include_once("../../entities/Producto.php");
include_once("../../entities/Proveedor.php");
include_once("../../includes/AccesoDatos.php");

if(!verificarCookie()) {
  exit;
}
	
$datos = new AccesoDatos();

$productos = $datos->listarProductos();

$cantidad = count($productos);

?>
<div class="panel contenedor panel-default">
  <div class="panel-heading">Productos encontrados : <?php echo htmlentities($cantidad) ?></div>
  <div class="panel-body">
<?php
	
if ($cantidad == "0") {
	echo "<center><b>No se encontraron productos</b></center>";
} else {
			
	?>
<div class="table-responsive">
<table class="table table-striped table-hover ">
  <thead>
	<tr>
	  <th class="fila_listado_productos">Nombre</th>
	  <th class="fila_listado_productos">Descripción</th>
	  <th class="fila_listado_productos">Precio</th>
	  <th class="fila_listado_productos">Proveedor</th>
	  <th class="fila_listado_productos">Registro</th>
	</tr>
  </thead>
  <tbody>
	<?php
				
	foreach ($productos as $producto) {
		$id      = $producto->getId();
		$nombre  = $producto->getNombre();
		$descripcion      = $producto->getDescripcion();
		$descripcion      = substr($descripcion, 0, 18);
		$precio           = $producto->getPrecio();
		$fecha_registro   = $producto->getFecha_registro();
		$id_proveedor     = $producto->getId_proveedor();
		$nombre_proveedor = $producto->getProveedor()->getNombre();

		echo '
		  <tr>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($nombre).'</td>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($descripcion).'</td>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($precio).'</td>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($nombre_proveedor).'</td>
			<td class="filterable-cell fila_listado_productos">'.htmlentities($fecha_registro).'</td>
		  </tr>
		';
	}
	
	echo '
		</tbody>
	  </table> 
	  </div>
  ';
  
	echo '
	  </div>
	</div>
	';
	
}

unset($datos);

?>