<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/AccesoDatos.php");
include_once("../../includes/Funciones.php");
include_once("../../entities/Producto.php");
include_once("../../entities/Proveedor.php");

if(!verificarCookie()) {
  exit;
}
  	
if (isset($_POST["nombre_buscar"])) {

	$patron = $_POST["nombre_buscar"];

	$datos = new AccesoDatos();
			
	$productos = $datos->listarProductos($patron);

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
	<table class="table table-striped table-hover">
	  <thead>
		<tr>
		  <th class="fila_producto">Nombre</th>
		  <th class="fila_producto">Descripción</th>
		  <th class="fila_producto">Precio</th>
		  <th class="fila_producto">Proveedor</th>
		  <th class="fila_producto">Registro</th>
		  <th class="fila_producto">Opción</th>
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
				<td class="filterable-cell fila_producto">'.htmlentities($nombre).'</td>
				<td class="filterable-cell fila_producto">'.htmlentities($descripcion).'</td>
				<td class="filterable-cell fila_producto">'.htmlentities($precio).'</td>
				<td class="filterable-cell fila_producto">'.htmlentities($nombre_proveedor).'</td>
				<td class="filterable-cell fila_producto">'.htmlentities($fecha_registro).'</td>
				<td class="filterable-cell fila_producto">
					<a href="?editar_producto=' . htmlentities($id) . '">
						<img data-toggle="tooltip" src="images/edit.png" title="Editar">
					</a>
					<a href="?borrar_producto=' . htmlentities($id) . '">
						<img data-toggle="tooltip" src="images/delete.png" title="Borrar">
					</a>
				</td>
			  </tr>
			';
		}
		
		echo '
			</tbody>
		  </table> 
		</div> 
		';
		
	}

	echo '
		</div>
	</div>
	';

}

unset($datos);

echo $resultado;

?>