<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<script>
	function funcion_buscar_usuarios() {
		var texto = $("input[name='nombre_buscar']").val();
		$.post("includes/BusquedaUsuarios.php",{nombre_buscar:texto}, function(mensaje) {
			$("#tabla").html(mensaje);
		}); 
	}
</script> 

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
					<input class="form-control" id="inputNombre" placeholder="Nombre" name="nombre_buscar" type="text" onKeyUp="funcion_buscar_usuarios();">
				  </div>
				</div>
				<div class="form-group">
					<button type="submit" name="busqueda" id="buscar_usuarios" class="btn btn-primary center-block">Buscar</button>
				</div>
			  </fieldset>
			</form>
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