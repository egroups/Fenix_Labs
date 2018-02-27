<script>
$(document).ready(function(){

  $("form[name='form_busqueda']").submit(function(e) {
	  e.preventDefault();
	  var texto = $("input[name='nombre_buscar']").val();
      $.post("includes/BusquedaProveedores.php",{nombre_buscar:texto}, function(mensaje) {
		  $("#busqueda").html(mensaje);
      }); 
  });
  
  $("a").click(function(e) {  
	e.preventDefault();
	var url = this.href;
	var split_string = url.indexOf('='); 
	var id = url.substring(split_string + 1); 
	if (url.toLowerCase().indexOf("editar_proveedor") >= 0) {
      $.post("includes/FormEditarProveedor.php",{editar_proveedor:id}, function(mensaje) {
		  $("#contenido").html(mensaje);
      }); 
	} 
	if (url.toLowerCase().indexOf("borrar_proveedor") >= 0) {
      $.post("includes/ABM.php",{borrar_proveedor:id}, function(mensaje) {
		  $("#respuesta").html(mensaje);
      }); 
	} 	
  });
      
});

</script>

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
	
	$resultado = $resultado . '
	<div class="panel contenedor panel-default">
	  <div class="panel-heading">Proveedores encontrados : '.htmlentities($cantidad_real).'</div>
	  <div class="panel-body">
		<form method="POST" class="form-horizontal" name="form_busqueda">
		  <fieldset>
			<div class="form-group">
			  <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
			  <div class="col-lg-10">
				<input class="form-control" id="inputBuscar" placeholder="Nombre" name="nombre_buscar" type="text">
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