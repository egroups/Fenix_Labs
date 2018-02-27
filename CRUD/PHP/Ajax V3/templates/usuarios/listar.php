<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/AccesoDatos.php");
include_once("../../includes/Funciones.php");
include_once("../../entities/Usuario.php");
include_once("../../entities/TipoUsuario.php");

if(!verificarCookie() || !verificarCookieAdmin()) {
  exit;
}
  		
if (isset($_POST["nombre_buscar"])) {

	$patron = $_POST["nombre_buscar"];

	$datos = new AccesoDatos();
					
	$usuarios = $datos->listarUsuarios($patron);

	$cantidad = count($usuarios);
	
	?>
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Usuarios encontrados : <?php echo htmlentities($cantidad) ?></div>
	  <div class="panel-body">
	<?php
	
	if ($cantidad == "0") {
		echo "<center><b>No se encontraron usuarios</b></center>";
	} else {
				
			?>
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
			<?php
		
			
			foreach ($usuarios as $usuario) {
				$id     = $usuario->getId();
				$nombre = $usuario->getNombre();
				$clave          = $usuario->getClave();
				$id_tipo        = $usuario->getId_Tipo();
				$fecha_registro = $usuario->getFecha_registro();
				$tipo = $usuario->getTipo()->getNombre();
				echo '
			  <tr>
				<td class="filterable-cell fila_usuario">'.htmlentities($nombre).'</td>
				<td class="filterable-cell fila_usuario">'.htmlentities($tipo).'</td>
				<td class="filterable-cell fila_usuario">'.htmlentities($fecha_registro).'</td>
				<td class="filterable-cell fila_usuario">
					<a href=?editar_usuario=' . htmlentities($id) . '>
						<img data-toggle="tooltip" src="images/edit.png" title="Editar">
					</a>
					<a href=?borrar_usuario=' . htmlentities($id) . '>
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