<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/AccesoDatos.php");
include_once("../../includes/Funciones.php");
include_once("../../entities/Proveedor.php");

if(!verificarCookie()) {
  exit;
}
  
if (isset($_POST["nombre_buscar"])) {

	$patron = $_POST["nombre_buscar"];
	
	$datos = new AccesoDatos();
		
	$proveedores = $datos->listarProveedores($patron);

	$cantidad = count($proveedores);

	?>
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Proveedores encontrados : <?php echo htmlentities($cantidad) ?></div>
	  <div class="panel-body">
	<?php
	
	if ($cantidad == "0") {
		echo "<center><b>No se encontraron proveedores</b></center>";
	} else {
		
		?>
	<div class="table-responsive">
	<table class="table table-striped table-hover">
	  <thead>
		<tr>
		  <th class="fila_proveedor">Nombre</th>
		  <th class="fila_proveedor">Dirección</th>
		  <th class="fila_proveedor">Teléfono</th>
		  <th class="fila_proveedor">Registro</th>
		  <th class="fila_proveedor">Opción</th>
		</tr>
	  </thead>
	  <tbody>
		<?php
  
		foreach ($proveedores as $proveedor) {
			$id   = $proveedor->getId();
			$nombre = $proveedor->getNombre();
			$direccion      = $proveedor->getDireccion();
			$telefono       = $proveedor->getTelefono();
			$fecha_registro = $proveedor->getFecha_registro();
			echo '
			  <tr>
				<td class="filterable-cell fila_proveedor">'.htmlentities($nombre).'</td>
				<td class="filterable-cell fila_proveedor">'.htmlentities($direccion).'</td>
				<td class="filterable-cell fila_proveedor">'.htmlentities($telefono).'</td>
				<td class="filterable-cell fila_proveedor">'.htmlentities($fecha_registro).'</td>
				<td class="filterable-cell fila_proveedor">
					<a href=?editar_proveedor=' . htmlentities($id) . '>
						<img data-toggle="tooltip" src="images/edit.png" title="Editar">
					</a>
					<a href=?borrar_proveedor=' . htmlentities($id) . '>
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
	 
?>