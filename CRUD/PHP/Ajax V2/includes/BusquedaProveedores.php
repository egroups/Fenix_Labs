<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<?php

include_once("Proveedores.php");
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
	
	$proveedores = $conexion_now->listarProveedores();
	
	if (isset($_POST["nombre_buscar"])) {
		$cantidad_real = contar_proveedores($_POST["nombre_buscar"]);
	} else {
		$cantidad_real = count($proveedores);
	}
		
	if (isset($_POST["nombre_buscar"])) {
		
		$resultado = $resultado . '
		<div class="panel contenedor panel-default">
		  <div class="panel-heading">Proveedores encontrados : '.htmlentities($cantidad_real).'</div>
		  <div class="panel-body">
				';
		
		if ($cantidad_real == "0") {
			$resultado = $resultado . "<center><b>No se encontraron proveedores</b></center>";
		} else {
			
			$resultado = $resultado . '
		<div class="table-responsive">
		<table class="table table-striped table-hover">
		  <thead>
			<tr>
			  <th class="fila_proveedor">Nombre</th>
			  <th class="fila_proveedor">Direccion</th>
			  <th class="fila_proveedor">Telefono</th>
			  <th class="fila_proveedor">Registro</th>
			  <th class="fila_proveedor">Opción</th>
			</tr>
		  </thead>
		  <tbody>
			';
	  
			foreach ($proveedores as $proveedor) {
				$id_proveedor   = $proveedor->getId_proveedor();
				$nombre_empresa = $proveedor->getNombre_empresa();
				$direccion      = $proveedor->getDireccion();
				$telefono       = $proveedor->getTelefono();
				$fecha_registro = $proveedor->getFecha_registro();
				if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_empresa)) {
					$resultado = $resultado . '
					  <tr>
						<td class="filterable-cell fila_proveedor">'.htmlentities($nombre_empresa).'</td>
						<td class="filterable-cell fila_proveedor">'.htmlentities($direccion).'</td>
						<td class="filterable-cell fila_proveedor">'.htmlentities($telefono).'</td>
						<td class="filterable-cell fila_proveedor">'.htmlentities($fecha_registro).'</td>
						<td class="filterable-cell fila_proveedor"><a href=?editar_proveedor=' . htmlentities($id_proveedor) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_proveedor=' . htmlentities($id_proveedor) . '><img src="images/delete.png" title="Borrar"></a></td>
					  </tr>
					';
				}
			}
		   
			$resultado = $resultado . '
				</tbody>
			  </table> 
			  </div> 
		  ';
			
		}
		
		$resultado = $resultado . '
			</div>
		';
		
		
	} 
	
	$resultado = $resultado . '
	  </div>
	</div>
	';
	
	unset($conexion_now);
	
	echo $resultado;

}
    
?>