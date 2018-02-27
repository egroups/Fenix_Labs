<script>
$(document).ready(function(){

  $("form[name='form_busqueda']").submit(function(e) {
	  e.preventDefault();
	  var texto = $("input[name='nombre_buscar']").val();
      $.post("includes/BusquedaUsuarios.php",{nombre_buscar:texto}, function(mensaje) {
		  $("#busqueda").html(mensaje);
      }); 
  });
  
  $("a").click(function(e) {  
	e.preventDefault();
	var url = this.href;
	var split_string = url.indexOf('='); 
	var id = url.substring(split_string + 1); 
	if (url.toLowerCase().indexOf("editar_usuario") >= 0) {
      $.post("includes/FormEditarUsuario.php",{editar_usuario:id}, function(mensaje) {
		  $("#contenido").html(mensaje);
      }); 
	} 
	if (url.toLowerCase().indexOf("borrar_usuario") >= 0) {
      $.post("includes/ABM.php",{borrar_usuario:id}, function(mensaje) {
		  $("#respuesta").html(mensaje);
      }); 
	} 	
  });
      
});

</script>

<?php

include_once("Usuarios.php");
include_once("Conexion.php");
include_once("Funciones.php");	
  
$conexion_now = new Conexion();
	
$cortar = base64_decode($_COOKIE['cookie_login']);
	
$parte      = explode("@", $cortar);
$user_login = $parte[0];
$pass_login = $parte[1];
	
if ($conexion_now->ingreso_usuario($user_login, $pass_login)) {

	if ($conexion_now->es_admin($user_login)) {

		$resultado = "";
			
		$cantidad_real = "0";
		
		$usuarios = $conexion_now->listarUsuarios();
		
		if (isset($_POST["busqueda"])) {
			$cantidad_real = contar_usuarios($_POST["nombre_buscar"]);
		} else {
			$cantidad_real = count($usuarios);
		}
		
		
		$resultado = $resultado . '
		<div class="panel contenedor panel-default">
		  <div class="panel-heading">Usuarios encontrados : '.htmlentities($cantidad_real).'</div>
		  <div class="panel-body">
			<form action="?usuarios" method="POST" class="form-horizontal" name="form_busqueda">
			  <fieldset>
				<div class="form-group">
				  <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
				  <div class="col-lg-10">
					<input class="form-control" id="inputNombre" placeholder="Nombre" name="nombre_buscar" type="text">
				  </div>
				</div>
				<div class="form-group">
					<button type="submit" name="busqueda" class="btn btn-primary center-block">Buscar</button>
				</div>
			  </fieldset>
			</form>
		  </div>
		</div>
		';
		
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
			<table class="table table-striped table-hover ">
			  <thead>
				<tr>
				  <th>Nombre</th>
				  <th>Tipo</th>
				  <th>Fecha Registro</th>
				  <th>Opción</th>
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
							<td>'.htmlentities($nombre_usuario).'</td>
							<td>'.htmlentities($tipo_usuario).'</td>
							<td>'.htmlentities($fecha_registro).'</td>
							<td><a href=?editar_usuario=' . htmlentities($id_usuario) . '><img src="images/edit.png" title="Editar"></a> <a href=?borrar_usuario=' . htmlentities($id_usuario) . '><img src="images/delete.png" title="Borrar"></a></td>
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
	
	} else {
		mensaje_con_redireccion("Notificacion","Acceso Denegado","error","administracion.php");
	}

}
    
?>