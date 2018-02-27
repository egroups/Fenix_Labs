<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<?php

include_once("Usuarios.php");
include_once("Conexion.php");
include_once("Funciones.php");	
  
$conexion_now = new Conexion();
	
$cortar = base64_decode($_SESSION['uid']);
	
$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];
	
if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {

	if ($conexion_now->es_admin($user_login)) {

		$resultado = "";
			
		$cantidad_real = "0";
		
		$usuarios = $conexion_now->listarUsuarios();
		
		if (isset($_POST["nombre_buscar"])) {
			$cantidad_real = contar_usuarios($_POST["nombre_buscar"]);
		} else {
			$cantidad_real = count($usuarios);
		}
				
		if (isset($_POST["nombre_buscar"])) {
			
			$resultado = $resultado . '
			<div class="panel contenedor panel-default">
			  <div class="panel-heading">Usuarios encontrados : '.htmlentities($cantidad_real).'</div>
			  <div class="panel-body">
					';
			
			if ($cantidad_real == "0") {
				$resultado = $resultado . "<center><b>No se encontraron usuarios</b></center>";
			} else {
						
					$resultado = $resultado . '
			<div class="table-responsive">
			<table class="table table-striped table-hover">
			  <thead>
				<tr>
				  <th class="fila_usuario">Nombre</th>
				  <th class="fila_usuario">Tipo</th>
				  <th class="fila_usuario">Registro</th>
				  <th class="fila_usuario">Opción</th>
				</tr>
			  </thead>
			  <tbody>
					';
				
					
					foreach ($usuarios as $usuario) {
						$id_usuario     = $usuario->getId_usuario();
						$nombre_usuario = $usuario->getNombre();
						$clave          = $usuario->getPassword();
						$tipo           = $usuario->getTipo();
						$fecha_registro = $usuario->getFecha_registro();
						$tipo_usuario   = "";
						if ($tipo == "1") {
							$tipo_usuario = "Administrador";
						} else {
							$tipo_usuario = "Usuario";
						}
						if (preg_match('/' . $_POST["nombre_buscar"] . '/', $nombre_usuario)) {
							
							$resultado = $resultado . '
						  <tr>
							<td class="filterable-cell fila_usuario">'.htmlentities($nombre_usuario).'</td>
							<td class="filterable-cell fila_usuario">'.htmlentities($tipo_usuario).'</td>
							<td class="filterable-cell fila_usuario">'.htmlentities($fecha_registro).'</td>
							<td class="filterable-cell fila_usuario"><a href=?editar_usuario=' . htmlentities($id_usuario) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_usuario=' . htmlentities($id_usuario) . '><img src="images/delete.png" title="Borrar"></a></td>
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
	
	} else {
		mensaje_con_redireccion("Notificacion","Acceso Denegado","error","administracion.php");
	}

}
    
?>