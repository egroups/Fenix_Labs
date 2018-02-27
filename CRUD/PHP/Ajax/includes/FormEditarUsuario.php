<script>
$(document).ready(function(){
		  
  $("form[name='form_usuarios_editar']").submit(function(e) {

	var id_usuario_check = $("input[name='id_usuario']").val();
    var nombre_check = $("input[name='nombre_usuario']").val();
	var tipo_check = $("select[name='tipo']").val();

    if(nombre_check=="") {
      $("input[name='nombre_usuario']").attr("placeholder", "Falta nombre de usuario");
      $("div[name='form-group-nombre']").addClass('has-error');
	  $("input[name='nombre_usuario']").focus();
      e.preventDefault();
      return false;   
	}
			
    else if(tipo_check=="0") {
      $("select[name='tipo']").attr("placeholder", "Seleccione tipo");
      $("div[name='form-group-tipo']").addClass('has-error');
	  $("select[name='tipo']").focus();
      e.preventDefault();
      return false;   
    } else {
	  $("div[name='form-group-nombre']").addClass('has-success');
	  $("div[name='form-group-tipo']").addClass('has-success');
      $.post("includes/ABM.php",{editar_usuario:"",id_usuario:id_usuario_check,tipo:tipo_check}, function(mensaje) {
		  $("#respuesta").html(mensaje);
      });
      e.preventDefault();
      return false; 
	}
  });
  
});
</script>

<?php
     
include_once("Productos.php");
include_once("Proveedores.php");
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
		
		$id_usuario = $_POST["editar_usuario"];
		
		if(!is_numeric($id_usuario)) {
			mensaje("Usuarios","ID invalido","warning","?usuarios");
		} else {
		
			$usuarios = $conexion_now->listarUsuarios();
			$posicion = buscar_posicion_usuario($id_usuario);
		
			$usuario = $usuarios[$posicion];
			
			$id_usuario = $usuario->getId_usuario();
			$nombre_usuario = $usuario->getNombre();
			$clave = $usuario->getPassword();
			$tipo = $usuario->getTipo();
			
			$resultado = $resultado . '
		<div class="panel contenedor panel-default">
		<div class="panel-heading">Editar al usuario '.htmlentities($nombre_usuario).'</div>
		<div class="panel-body">
		<form action="?usuarios" method="POST" name="form_usuarios_editar" class="form-horizontal">
		<input type="hidden" name="id_usuario" value="' . htmlentities($id_usuario) . '">
		<fieldset>
		<legend>Datos</legend>
		<div class="form-group" name="form-group-nombre">
		  <label for="inputNombre" class="col-lg-2 control-label">Nombre usuario</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputNombre" placeholder="Ingrese nombre usuario" type="text" name="nombre_usuario" value="'.htmlentities($nombre_usuario).'" readonly="readonly">
		  </div>
		</div>
		<div class="form-group" name="form-group-password">
		  <label for="inputPrecio" class="col-lg-2 control-label">Password</label>
		  <div class="col-lg-10">
			<input class="form-control" id="inputPassword" placeholder="Ingrese password" type="password" name="password" readonly="readonly">
		  </div>
		</div>
		<div class="form-group" name="form-group-tipo">
		  <label for="select" class="col-lg-2 control-label">Tipo</label>
		  <div class="col-lg-10">
			<select class="form-control" id="select" name="tipo">
		';
		if($tipo=="2") {
			$resultado = $resultado . '<option value="2" selected="true">Usuario</option>';
		} else {
			$resultado = $resultado . '<option value="2">Usuario</option>';
		}
		
		if($tipo=="1") {
			$resultado = $resultado . '<option value="1" selected="true">Administrador</option>';
		} else {
			$resultado = $resultado . '<option value="1">Administrador</option>';
		}
			$resultado = $resultado . '</select>
		  </div>
		</div>
		<div class="form-group">
			<button type="submit" class="btn btn-primary center-block" name="editar_usuario" onclick="return validar_formulario_usuarios();">Editar</button>
		</div>
		</fieldset>
		</form>        
		</div>
		</div>
			';
							
		}
			
		echo $resultado;
	
	} else {
		mensaje_con_redireccion("Notificacion","Acceso Denegado","error","administracion.php");
	}

}
				            
?>