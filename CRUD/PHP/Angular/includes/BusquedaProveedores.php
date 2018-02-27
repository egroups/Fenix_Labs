<?php

include_once("Proveedores.php");
include_once("Conexion.php");
include_once("Funciones.php");
include_once("Conexion.php");
  
$conexion_now = new Conexion();
	
$cortar = base64_decode($_COOKIE['cookie_login']);
	
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
		<table class="table table-striped table-hover ">
		  <thead>
			<tr>
			  <th>Nombre Empresa</th>
			  <th>Direccion</th>
			  <th>Telefono</th>
			  <th>Fecha Registro</th>
			  <th>Opción</th>
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
						<td>'.htmlentities($nombre_empresa).'</td>
						<td>'.htmlentities($direccion).'</td>
						<td>'.htmlentities($telefono).'</td>
						<td>'.htmlentities($fecha_registro).'</td>
						<td><a href=?editar_proveedor=' . htmlentities($id_proveedor) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_proveedor=' . htmlentities($id_proveedor) . '><img src="images/delete.png" title="Borrar"></a></td>
					  </tr>
					';
				}
			}
		   
			$resultado = $resultado . '
				</tbody>
			  </table> 
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