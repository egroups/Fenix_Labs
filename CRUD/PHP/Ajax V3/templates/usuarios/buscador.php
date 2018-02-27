<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/Funciones.php");
include_once("../../entities/Usuario.php");
include_once("../../includes/Conexion.php");

if(!verificarCookie() || !verificarCookieAdmin()) {
  exit;
}

?>

<script>
	function funcion_buscar_usuarios() {
		var texto = $("input[name='nombre_buscar']").val();
		$.post("templates/usuarios/listar.php",{nombre_buscar:texto}, function(mensaje) {
			$("#tabla").html(mensaje);
		}); 
	}
</script> 

<div class="panel contenedor panel-default">
  <br/>
  <div class="panel-body">
	<form method="POST" class="form-horizontal" name="form_busqueda">
		<fieldset>
		    <div class="form-group">
		        <div class="col-lg-2">
		            <a name="agregar" id="cargar_agregar_usuario" class="btn btn-primary btn-block" role="button"><span class="glyphicon glyphicon-plus right_space"></span>Agregar</a>
		        </div>
		        <div class="col-lg-9">
					<input class="form-control" id="inputBuscar" placeholder="Ingrese nombre a buscar" name="nombre_buscar" type="text" onKeyUp="funcion_buscar_usuarios();">
		        </div>
		        <div class="col-lg-1">
		            <button type="submit" name="busqueda" id="buscar_usuarios" class="btn btn-primary btn-block"><span class="glyphicon glyphicon-search"></button>
		        </div>
		    </div>
		</fieldset>
	</form>
  </div>
</div>